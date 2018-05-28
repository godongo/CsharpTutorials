using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Transactions;

namespace ImplementDataAccess.Demos
{
    class ConsumingDataAdoDotNet
    {
        // Typical connection string format.
        // Remember 4 properties.
        static string connectionString =
            @"Persist Security Info=False;
              Integrated Security=true;
              Initial Catalog=Northwind;
              server=(local)";


        static void SqlConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Execute operations against the database

            } // Connection is automatically closed.
        }

        static void DynamicallyBuildConnectionString()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";

            string connectionString = sqlConnectionStringBuilder.ToString();

            Console.WriteLine(connectionString);
        }

        internal static void GetConnectionStringFromConfiguration()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //connection.Open();
            //}

            Console.WriteLine(connectionString);
        }

        internal async Task SelectDataFromTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Remember cmdText can also be a name of a store procedure.
                SqlCommand command = new SqlCommand("SELECT * FROM People", connection);

                await connection.OpenAsync();

                // Execute command
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    string formatStringWithMiddleName = "Person ({0}) is named {1} {2} {3}";
                    string formatStringWithoutMiddleName = "Person ({0}) is named {1} {3}";
                    if ((dataReader["middlename"] == null))
                    {
                        Console.WriteLine(formatStringWithoutMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["lastname"]);
                    }
                    else
                    {
                        Console.WriteLine(formatStringWithMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["middlename"],
                        dataReader["lastname"]);
                    }
                }

                dataReader.Close();
            }
        }

        public async Task UpdateRows_ExecuteNonQuery()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE People SET FirstName =’John’", connection);

                await connection.OpenAsync();

                int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();

                Console.WriteLine("Updated { 0} rows", numberOfUpdatedRows);
            }
        }

        // Use prepared statements (with parameterized queries).
        static async Task InsertRowWithParameterizedQuery()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand
                    ("INSERT INTO People([FirstName], [LastName], [MiddleName]) VALUES(@firstName, @lastName, @middleName)",
                    connection);

                await connection.OpenAsync();

                // User inputs mapped to variables.
                command.Parameters.AddWithValue("@firstName", "John");
                command.Parameters.AddWithValue("@lastName", "Doe");
                command.Parameters.AddWithValue("@middleName", "Little");

                int numberOfInsertedRows = await command.ExecuteNonQueryAsync();

                Console.WriteLine("Inserted {0} rows", numberOfInsertedRows);
            }
        }

        // If an exception occurs inside the TransactionScope, the whole transaction is rolled back.
        static void UsingTransactionScope()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1 = new SqlCommand
                        ("INSERT INTO People ([FirstName], [LastName], [MiddleInitial]) VALUES('John', 'Doe', null)", connection);

                    SqlCommand command2 = new SqlCommand
                        ( "INSERT INTO People ([FirstName], [LastName], [MiddleInitial]) VALUES('Jane', 'Doe', null)", connection);

                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();                    
                }

                transactionScope.Complete();
            }
        }
        

        static void AnotherMethod()
        {
        }
    }
}
