using System;

namespace CreateAndUseTypes.Demos
{
    class GenericClass<T>
    {
        T _value;

        public GenericClass(T t)
        {
            // The field has the same type as the parameter.
            this._value = t;
        }

        public void Write()
        {
            Console.WriteLine(this._value);
        }
    }
}
