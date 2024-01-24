using System;
using System.Collections.Generic;
using System.Reflection;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Wcf
{
    public class ServiceNameMap
    {
        private const string OltAssemblyPrefix = "Com.Suncor.Olt";
        private const string OltReportingAssembly = "Com.Suncor.Olt.Reporting";
        private const string OltClientAssembly = "Operator Log Tool";

        private static readonly ILog logger = GenericLogManager.GetLogger<ServiceNameMap>();

        private static readonly ServiceNameMap instance = new ServiceNameMap();

        private readonly Dictionary<string, Type> nameToServiceType = new Dictionary<string, Type>();

        public static ServiceNameMap Instance
        {
            get { return instance; }
        }

        public Type GetServiceType(string name)
        {
            var serviceType = GetServiceTypeReturnNullIfDoesNotExist(name);
            if (serviceType == null)
            {
                var message = "Service type cannot be found for: " + name;
                logger.Error(message);
                throw new Exception(message);
            }
            return serviceType;
        }

        public Type GetServiceInterfaceType(string name)
        {
            logger.DebugFormat("Getting interface type for the service {0}", name);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            logger.DebugFormat("Found {0} assemblies to search.", assemblies.Length);

            foreach (var assembly in assemblies)
            {
                logger.DebugFormat("Found assembly {0}", assembly.FullName);

                if (IsOltAssemblyToSearch(assembly))
                {
                    logger.DebugFormat("Searching OLT assembly {0} for {1}", assembly.FullName, name);
                    foreach (var type in AssemblyUtil.GetTypes(assembly))
                    {
                        if (type.Name == name)
                        {
                            logger.DebugFormat("Found {0} in {1}", type.Name, assembly.FullName);
                            return type;
                        }
                    }
                }
            }

            return null;
        }

        public bool ServiceExists(string name)
        {
            var serviceType = GetServiceTypeReturnNullIfDoesNotExist(name);
            return serviceType != null;
        }

        private Type GetServiceTypeReturnNullIfDoesNotExist(string name)
        {
            logger.DebugFormat("Attempting to find cached Service type {0}", name);
            if (!nameToServiceType.ContainsKey(name))
            {
                logger.DebugFormat("Attempting to find Service type {0} in Assemblies", name);
                var serviceTypes = new List<Type>();

                var interfaceType = GetServiceInterfaceType(name);
                if (interfaceType != null)
                {
                    logger.DebugFormat("Attempting to class that implements {0} in Assemblies", name);
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                    logger.DebugFormat("Found {0} assemblies to search for service implementation", assemblies.Length);

                    foreach (var assembly in assemblies)
                    {
                        logger.DebugFormat("Found assembly {0}", assembly.FullName);
                        if (IsOltAssemblyToSearch(assembly))
                        {
                            logger.DebugFormat("Searching OLT assembly {0} for {1}", assembly.FullName, name);
                            foreach (var type in AssemblyUtil.GetTypes(assembly))
                            {
                                if (interfaceType.IsAssignableFrom(type) &&
                                    interfaceType != type &&
                                    !type.IsInterface)
                                {
                                    serviceTypes.Add(type);
                                    logger.DebugFormat("Found {0} implementing {1} in {2}", type.FullName,
                                        interfaceType.FullName, assembly.FullName);
                                }
                            }
                        }
                    }
                }
                else
                {
                    logger.Error(String.Format("Interface for {0} was not found.", name));
                }

                if (serviceTypes.Count == 1)
                {
                    nameToServiceType[name] = serviceTypes[0];
                }
                else
                {
                    if (serviceTypes.Count == 0)
                    {
                        logger.Error(String.Format("A service that implements {0} was not found.", name));
                    }
                    else
                    {
                        var implementations = "";
                        foreach (var serviceType in serviceTypes)
                        {
                            implementations = implementations + serviceType.FullName + ", ";
                        }
                        logger.Error(String.Format("More than one service that implements {0} was found {1}.", name,
                            implementations));
                    }
                }
            }

            return nameToServiceType.ContainsKey(name) ? nameToServiceType[name] : null;
        }

        private static bool IsOltAssemblyToSearch(Assembly assembly)
        {
            return (assembly.FullName.Contains(OltAssemblyPrefix) || assembly.FullName.Contains(OltClientAssembly)) &&
                   !assembly.FullName.Contains(OltReportingAssembly);
        }
    }
}