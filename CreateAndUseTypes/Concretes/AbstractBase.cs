namespace CreateAndUseTypes.Concretes
{
    /* Use an abstract class to expose info required by subtypes to facilitate encapsulation */
    // GeeNote: REMEMBER CANNOT BE DIRECTLY INSTANTIATED.
    abstract class AbstractBase
    {
        // Can contain full implementations.
        public virtual void MethodWithImplementation()
        {
            /*Method with implementation*/
        }

        /* Deriving types must provide implementation for abstract types otherwise the 
         * derived types will be abstract as well. */
        public abstract void AbstractMethod();
    }
}
