using CreateAndUseTypes.Concretes;

namespace CreateAndUseTypes.Abstracts
{
    interface IPlugin
    {
        string Name { get; }

        string Description { get; }

        bool Load(MyApp app);
    }
}
