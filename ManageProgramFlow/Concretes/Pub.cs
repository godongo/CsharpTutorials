using System;

namespace ManageProgramFlow.Concretes
{
    internal class Pub
    {
        public event EventHandler<MyArgs> onChange = delegate { };
        
        // Custom event accessor.
        // Put lock around ADD and REMOVE for thread safe operations.
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {           
            onChange(this, new MyArgs(42));
        }
    }
}
