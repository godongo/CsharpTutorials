using static System.Console;
using static CSharpVersions.Helpers.SomeStaticClass;
using CSharpVersions.Entities;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace CSharpVersions.Demos
{
    class CSharp6
    {
        internal static void Execute()
        {
            //Using_Static();   
            //Using_Custom_Static_Class();
            //Auto_Property_Initializers();
            //Dictionary_Initializers();
            //String_Interpolation();
            //Name_Of_Expression();
            //Expression_Bodied_Function_And_Property();
            //Exception_Filters();
            //Await_In_Catch_And_Finally_Block();
            //Null_Conditional_Operator();
        }
        internal static void Using_Static()          
        {
            // GeeNote: Note using statment above: using static System.Console;
            WriteLine($"Demo using Console.WriteLine in C# 6.");
        }

        internal static void Using_Custom_Static_Class()
        {
            // This method resides inside my static class.
            StaticMethod();
        }

        internal static void Auto_Property_Initializers()
        {
            // Look at how custmer entity has been initialized with new guid.
            Customer cust = new Customer();

            WriteLine($"CustomerID: {cust.customerID}");
        }

        internal static void Dictionary_Initializers()
        {
            // Original initialization.
            var stars1 = new Dictionary<string, string>()
            {
                 { "Michael Jordon", "Basketball" },
                 { "Peyton Manning", "Football" },
                 { "Babe Ruth", "Baseball" }
            };

            // New initialization.
            var stars2 = new Dictionary<string, string>()
            {
                ["Michael Jordan"] = "Basketball",
                ["Peyton Manning"] = "Football",
                ["Babe Ruth"] = "Baseball"
            };

            foreach (KeyValuePair<string, string> keyValuePair in stars2)
            {
                WriteLine($"{keyValuePair.Key} : {keyValuePair.Value}");
            }            
        }

        internal static void String_Interpolation()
        {
            string firstName = "Michael";
            string lastName = "Crump";

            WriteLine($"{firstName} {lastName} is my name!");
        }

        /*
         * This feature was designed due to the large amounts of code that many enterprise level applications 
         * have. One common error is using hard-coded name strings with an error message. Due to the nature of 
         * the apps in general and re-factoring, sometimes the names change and the string representation is 
         * left alone – thus breaking the app. Here is one example.
         */
        internal static void Name_Of_Expression()
        {
            //DoSomething1(null);
            //DoSomething2(null);
        }

        // If the input parameter name is changed (e.g newName) the exception will still the showing N
        private static void DoSomething1(string name)
        {
            if (name == null) throw new Exception("Name is null");
        }

        // Now regardless of the name change exception will show the correct name with the message
        private static void DoSomething2(string newName)
        {
            if (newName == null) throw new Exception(nameof(newName) + " is null");
        }

        /* Functions and properties in lambda expressions save you from defining your function and 
         * property statement block. Take note of the MultipleNumbers function below: */
        private static double MultiplyNumbers(double num1, double num2) => num1 * num2;

        internal static void Expression_Bodied_Function_And_Property()
        {
            double num1 = 5;
            double num2 = 10;
                        
            WriteLine($"Product: {MultiplyNumbers(num1, num2)}");
        }

        /* They allow you to specify a condition for a catch block. */
        internal static void Exception_Filters()
        {
            Exception_Filters_OldImplementation();
            Exception_Filters_NewImplementation();

        }

        private static void Exception_Filters_OldImplementation()
        {
            var httpStatusCode = 404;
            Write("HTTP Error: ");

            try
            {
                throw new Exception(httpStatusCode.ToString());
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("500"))
                    Write("Bad Request");
                else if (ex.Message.Equals("401"))
                    Write("Unauthorized");
                else if (ex.Message.Equals("402"))
                    Write("Payment Required");
                else if (ex.Message.Equals("403"))
                    Write("Forbidden");
                else if (ex.Message.Equals("404"))
                    Write("Not Found");
            }

            ReadLine();
        }

        /* Rather than entering the catch block and checking to see which condition met our exception, 
         * we can now decide if we even want to enter the specific catch block. */
        private static void Exception_Filters_NewImplementation()
        {
            var httpStatusCode = 404;
            Write("HTTP Error: ");

            try
            {
                throw new Exception(httpStatusCode.ToString());
            }
            // when keywords - Does a check before entering the catch block
            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Write("Bad Request");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Write("Unauthorized");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                Write("Payment Required");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                Write("Forbidden");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                Write("Not Found");
                ReadLine();
            }

            ReadLine();
        }

        /* Brand new to C# 6, you can write asynchronous code inside in a catch/finally block. This will 
         * help developers as they often need to log exceptions to a file or database without blocking the 
         * current thread.  */
        internal static void Await_In_Catch_And_Finally_Block()
        {
            Task.Factory.StartNew(() => GetPage());
            ReadLine();
        }

        private async static Task GetPage()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync("http://www.telerik.com");
                WriteLine(result);
            }
            catch (Exception exception)
            {
                try
                {
                    //This asynchronous request will run if the first request failed. 
                    var result = await client.GetStringAsync("http://www.progress.com");
                    WriteLine(result);
                }
                catch
                {
                    WriteLine("Entered Catch Block");
                }
                finally
                {
                    WriteLine("Entered Finally Block");
                }
            }
        }

        internal static void Null_Conditional_Operator()
        {
            //Null_Conditional_Operator_OldImplementation();
            Null_Conditional_Operator_NewImplementation();
        }
        
        /* This returns “Field is null”. If we enter some data into name, then the console prints out 
         * whatever is contained in the name. */
        private static void Null_Conditional_Operator_OldImplementation()
        {
            Person person = new Person();

            if (person.Name == String.Empty)
            {
                person = null;
            }

            WriteLine(person != null ? person.Name : "Field is null.");

            ReadLine();
        }

        private static void Null_Conditional_Operator_NewImplementation()
        {
            Person person = new Person();
            //person.Name = "George Odongo";

            if (person.Name == String.Empty)
            {
                person = null;
            }
            
            WriteLine(person?.Name ?? "Field is null.");

            ReadLine();
        }
    }
}
