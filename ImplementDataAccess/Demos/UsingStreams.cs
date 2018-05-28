using System.Text;
using System.IO;
using System;

namespace ImplementDataAccess.Demos
{
    class UsingStreams
    {
        internal static void WriteToFile_FileStream()
        {
            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\test.dat";

            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "MyValue";
                // Convert myValue to bytes.
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }

        internal static void ReadFromFile_FileStream()
        {
            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\test.dat";

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];

                for (int index = 0; index < fileStream.Length; index++)
                {
                    // Loop through and add bytes to array.
                    data[index] = (byte)fileStream.ReadByte();
                }

                // Bytes decoded into strings.
                Console.WriteLine(Encoding.UTF8.GetString(data)); // Displays: MyValue
            }
        }

        internal static void WriteToFile_StreamWriter()
        {
            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\test.dat";

            // Good for working with text.
            // Will under the hood create a file with UTF-8.
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "MyValue";

                streamWriter.Write(myValue);
            }
        }

        internal static void ReadFromFile_StreamReader()
        {
            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\test.dat";

            using (StreamReader streamWriter = File.OpenText(path))
            {
                Console.WriteLine(streamWriter.ReadLine()); // Displays: MyValue
            }
        } 
        
        // REMEMBER TO APPLY LOCKS WHERE THERE IS MULTIPLE ACCESS
        // HANDLE EXCEPTIONS AS WELL
        internal static string HandleReadFileExceptions()
        {
            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\test.dat";

            try
            {
                return File.ReadAllText(path);
            }
            catch (DirectoryNotFoundException)
            {
                // Write to log.
            }
            catch (FileNotFoundException)
            {
                // Write to log.
            }

            return string.Empty;
        }
    }
}
