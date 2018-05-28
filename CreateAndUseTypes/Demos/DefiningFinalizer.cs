using System.IO;

namespace CreateAndUseTypes.Demos
{
    /// <summary>
    /// Manage the object life cycles centres on how to deal with unmanaged resources
    /// For example database/newtwork connections, file handle, window handle etc...
    /// </summary>
    class DefiningFinalizer
    {
        // Body of the type here

        // Shoud now how GC works.
        // Remember IDisposable interface and Using statement.
        // NONE DETERMINISTIC - CAN ONLY BE CALLED BY THE GABAGE COLLECTOR.
        ~DefiningFinalizer()
        {
            // This code is called when the finalize method executes
        }

        static void WriteToFile()
        {
            // The using statement ensures that Dispose is always called.
            // Every type that implements IDisposable should be used in a using statement whenever possible
            using (StreamWriter sw = File.CreateText("temp.dat"))
            {
                // Write to file code here
            }
        } 


    }
}
