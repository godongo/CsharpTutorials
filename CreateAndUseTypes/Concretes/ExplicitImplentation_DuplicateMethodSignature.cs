using CreateAndUseTypes.Abstracts;

namespace CreateAndUseTypes.Concretes
{
    class ExplicitImplentation_DuplicateMethodSignature : ILeft, IRight
    {
        void ILeft.Move() { }
        void IRight.Move() { }
    }
}
