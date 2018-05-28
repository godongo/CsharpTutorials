using System;

namespace ManageProgramFlow.Concretes
{
    internal class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}
