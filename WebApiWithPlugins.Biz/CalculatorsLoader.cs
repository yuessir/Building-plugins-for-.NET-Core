﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;


namespace WebApiWithPlugins.Biz
{
    public static class CalculatorsLoader
    {
        private static IList<Type> _calculatorTypes;

        public static IList<Type> CalculatorTypes
        {
            get
            {
                if(_calculatorTypes == null)
                {
                    LoadCalculatorTypes();
                }

                return _calculatorTypes.ToList();
            }            
        }

        private static void LoadCalculatorTypes()
        {
            if (_calculatorTypes != null)
            {
                return;
            }

            var calcs = from a in GetReferencingAssemblies()
                        from t in a.GetLoadableTypes()
                        where t.GetTypeInfo().GetCustomAttribute<CalculatorAttribute>() != null
                              && t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(ICalculator))
                        select t;

            _calculatorTypes = calcs.OrderBy(t => t.GetTypeInfo().GetCustomAttribute<CalculatorAttribute>().Order).ToList();
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var asm  = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName("WebApiWithPlugins.Biz"));
            //var dependencies = DependencyContext.Load(asm);
            assemblies.Add(asm);
            //foreach (var library in dependencies)
            //{
            //    try
            //    {
            //        if (library.Name== "WebApiWithPlugins.Biz")
            //        {
            //            var assembly = Assembly.Load(new AssemblyName(library.Name));
            //            assemblies.Add(assembly);
            //        }

            //    }
            //    catch (FileNotFoundException)
            //    { }
            //}
            return assemblies;
        }
    }
}