namespace DesignPatterns.DP.Singleton.Multithreading
{
    /* This solves the multithreading issue. But it is slow since only one thread 
     * can access GetInstance() method at a time. */
    public sealed class Singleton
    {
        private static Singleton instance = null;

        // For synchronization
        private static readonly object Instancelock = new object();

        private Singleton() { }

        public static Singleton GetInstance
        {
            get
            {
                // Will be accessed by one thread at a time.
                lock (Instancelock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}
