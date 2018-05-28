using System;
using System.IO;

namespace ImplementDataAccess.Demos
{
    // Remember class default access modifier is internal.
    class DirectoryAndFolders
    {
        // Remember that class members default access modifier is private
        internal static void ExecuteDriveInfo()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drivesInfo)
            {
                Console.WriteLine($"Drive { driveInfo.Name }");
                Console.WriteLine($" File type: { driveInfo.DriveType }");

                if (driveInfo.IsReady == true)
                {
                    Console.WriteLine($" Volume label: { driveInfo.VolumeLabel }");
                    Console.WriteLine($" File system: { driveInfo.DriveFormat }");
                    //Console.WriteLine($" Available space to current user:{ 0, 15} bytes", driveInfo.AvailableFreeSpace);
                    Console.WriteLine($" Available space to current user: { driveInfo.AvailableFreeSpace} bytes");
                    //Console.WriteLine($" Total available space: { 0, 15} bytes", driveInfo.TotalFreeSpace);
                    Console.WriteLine($" Total available space: { driveInfo.TotalFreeSpace } bytes");
                    //Console.WriteLine($" Total size of drive: { 0, 15} bytes ", driveInfo.TotalSize);
                    Console.WriteLine($" Total size of drive: { driveInfo.TotalSize } bytes ");
                }
            }
        }

        internal static void ExecuteDirectory()
        {
            var directory = Directory.CreateDirectory(@"C:\GeeCentral\Dev\C#\TempFileTutorial\ProgrammingInCSharp\Directory");
            directory.Create();

            if (!string.IsNullOrEmpty(directory.Name))
            {
                Console.WriteLine($"{ directory.Name } successfuly created!");
            }

            //var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            //directoryInfo.Create();

            if (Directory.Exists(@"C:\Temp\ProgrammingInCSharp\Directory"))
            {
                Directory.Delete(@"C:\GeeCentral\Dev\C#\TempFileTutorial\ProgrammingInCSharp\Directory");

                Console.WriteLine($"{ directory.Name } successfuly deleted!");
            }
        }

        internal static void ExecuteSearechDirectory()
        {
            // List the subdirectories for Program Files containing the character ‘a’ with a maximum depth of 5
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");
            ListDirectories(directoryInfo, "*a *", 0, 5);
        }
        
        private static void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int currentLevel, int maxLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }

            string indent = new string('-', currentLevel);

            try
            {
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // You don’t have access to this folder.
                Console.WriteLine(indent + "Can’t access: " + directoryInfo.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                // The folder is removed while iterating
                Console.WriteLine(indent + "Can’t find: " + directoryInfo.Name);
                return;
            }
        }

        internal static void ExecuteFileAndFolderPaths()
        {
            string folder = @"C:\GeeCentral\Dev\C#\TempFileTutorial";
            string fileName = "test.text";

            string fullPath = Path.Combine(folder, fileName);
            Console.WriteLine($"Fullpath:  {fullPath}");

            string path = @"C:\GeeCentral\Dev\C#\TempFileTutorial\subdir\file.txt";

            // Manipulate path examples.
            Console.WriteLine($"Directory Name:  {Path.GetDirectoryName(path)}");
            Console.WriteLine($"File Extension:  {Path.GetExtension(path)}");
            Console.WriteLine($"File Name:  {Path.GetFileName(path)}");
            Console.WriteLine($"Root Path:  {Path.GetPathRoot(path)}");
        }
    }
}
