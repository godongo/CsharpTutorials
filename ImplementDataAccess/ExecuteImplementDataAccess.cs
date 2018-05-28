using ImplementDataAccess.Demos;
using System;

namespace ImplementDataAccess
{
    class ExecuteImplementDataAccess
    {
        static void Main(string[] args)
        {
            //DirectoryAndFolders.ExecuteDriveInfo();
            //DirectoryAndFolders.ExecuteDirectory();
            //DirectoryAndFolders.ExecuteSearechDirectory();
            //DirectoryAndFolders.ExecuteFileAndFolderPaths();

            //UsingStreams.CreateAndWriteToFile_FileStream();
            //UsingStreams.CreateAndWriteToFile_StreamWriter();
            //UsingStreams.ReadDataFromFile_FileStream();
            //UsingStreams.ReadFromFile_StreamReader();

            //UsingStreams.HandleReadFileExceptions();

            //NetworkCommunication.SimpleWebRequest();

            // DbConnection
            //ConsumingDataAdoDotNet.GetConnectionStringFromConfiguration();

            //ConsumeInterface.Execute();
            //UsingLINQ.SimpleDelegate();
            //UsingLINQ.SimpleAnonymousType();

            //ExecuteLinqOperators();

            //Serialization.XmlSerializeAndDeserialize();
            //Serialization.BinarySerializeAndDeserialize();
            //Serialization.WcfDataContractSerializeAndDeserialize();
            //Serialization.JSONSerializeAndDeserialize();

            //UsingCollections.Array();
            //UsingCollections.Two_Dimensional_Array();
            //UsingCollections.Jagged_Array();
            //UsingCollections.List();
            //UsingCollections.Dictionary();
            //UsingCollections.HashSet();
            //UsingCollections.Queue();
            //UsingCollections.Stack();
            UsingCollections.CustomCollection();

            Console.ReadKey();
        }

        private static void ExecuteLinqOperators()
        {
            //UsingLINQ.SelectOperator();
            //UsingLINQ.WhereOperator();
            //UsingLINQ.OrderbyOperator();
            //UsingLINQ.CombiningDataSources();
            //UsingLINQ.AverageOperator();
            //UsingLINQ.GroupingAndProjectionOperators();
            //UsingLINQ.JoinOperator();
            //UsingLINQ.CustomWhereOperator();
        }
    }    
}
