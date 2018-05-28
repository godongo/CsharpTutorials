using System;
using System.Linq;
using System.Reflection;
using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Demos
{
    class UsingReflection
    {
        internal static void Execute()
        {
            //if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute))) { }

            int i = 42;

            Type type = i.GetType();

            Console.WriteLine($"The type is: {type}");
        }

        internal static void GetPlugin()
        {
            Assembly pluginAssembly = Assembly.Load("CreateAndUseTypes");

            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach (Type pluginType in plugins)
            {
                // Remember we can always assign subtypes to base.
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;

                Console.WriteLine($" Plugin Details: {plugin.Name}");
            }
        }
    }
}
