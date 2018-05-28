namespace DesignPatterns.DP.Singleton.Standard
{ 
    /* The Singleton pattern ensures that a class has only one instance and provides a 
     * global point of access to it. */

/* THIS IS A STANDARD IMPLEMENTATION.
 * WORKS FINE IN A SINGLE THREADED ENVIRONMENT. */
    public class Singleton
    {
        // Static variable that will hold the instance of the class.
        private static Singleton instance;

        /* To ensure the class has only one instance, we mark the constructor as private. 
         * So, we can only instantiate this class from within the class. */
        private Singleton()
        {
        }

        /*  We create a static method that provides the instance of the singleton class. 
         *  This method checks if an instance of the singleton class is available. It creates 
         *  an instance, if its not available; Otherwise, it returns the available instance. */
        // THIS METHOD WILL BREAK IN MULTITHREADED ENVIRONMENT.
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
