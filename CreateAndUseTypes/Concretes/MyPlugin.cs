using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Concretes
{
    class MyPlugin : IPlugin
    {
        //private static string name = "";
        //public string Name => throw new System.NotImplementedException();
        //public string Name { get; } = name;

        public string Name
        {
            get { return "MyPlugin"; }
        }
        public string Description
        {
            get { return "My Sample Plugin"; }
        }

        public bool Load(MyApp app)
        {
            return true;
        }
    }
}
