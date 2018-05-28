using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ManageProgramFlow.Demos
{
    class ExceptionHandling
    {
        internal static void UnhandledException()
        {
            string s = "NaN";
            int i = int.Parse(s);
        }

        internal static void HandleExeption()
        {
            while (true)
            {
                Console.WriteLine("Please enter a valid number then press enter.");
                string s = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(s)) break;

                try
                {
                    int i = int.Parse(s);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("{s} is not a valid number. Please try again");
                }
            }
        }

        internal static void CatchingDifferentExceptionTypes()
        {
            //string s = null;
            string s = "a";

            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You need to enter a value");
            }
            catch (FormatException)
            {
                Console.WriteLine($"{s} is not a valid number. Please try again");
            }
        }

        internal static void FinallyBlock()
        {
            Console.WriteLine("Please enter a valid number then press enter.");
            string s = Console.ReadLine();

            try
            {
                int i = int.Parse(s);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You need to enter a value");
            }
            catch (FormatException)
            {
                Console.WriteLine("{s} is not a valid number. Please try again");
            }
            finally
            {
                Console.WriteLine("Program complete.");
            }
        }

        internal static void InspectException()
        {
            try
            {
                int i = ReadAndParse();
                Console.WriteLine($"Parsed: {i}");
            }

            catch (FormatException e)
            {
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"StackTrace: {e.StackTrace}");
                Console.WriteLine($"HelpLink: {e.HelpLink}");
                Console.WriteLine($"InnerException: {e.InnerException}");
                Console.WriteLine($"TargetSite: {e.TargetSite}");
                Console.WriteLine($"Source: {e.Source}");
            }
        }

        private static int ReadAndParse()
        {
            Console.WriteLine("Please enter a valid number then press enter.");
            string s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }

        /*
         * Rethrows the exception without modifying the call stack. This option 
         * should be used when you don’t want any modifications to the exception
         */
        internal static void ThrowkeywordWithoutAnIdentifier()
        {
            try
            {
                //SomeOperation();
            }
            catch (Exception logEx)
            {
                //Log(logEx);
                Console.Write(logEx.Message);
                throw; // rethrow the original exception
            }
        }

        /*
         * Can be useful when you want to raise another exception to the caller 
         * of your code. The original exception is preserved, including the stack trace, 
         * and a new exception with extra information is added.
         */
        internal static void ThrowkeywordWithANewException()
        {
            try
            {
                //ProcessOrder();
            }
            //catch (MessageQueueException ex) // CUSTOM EXCEPTION.
            catch (Exception ex)
            {
                //
                Console.Write(ex.Message);
                // THROWS A CUSTOM EXCEPTION AND ALSO PASSING THE ORIGINAL EXEPTION.
                //throw new OrderProcessingException("Error while processing order", ex);
            }        
        }

        /*
         * ExceptionDispatchInfo.Throw method
         * This method can be used to throw an exception and preserve the original stack trace.
         * THIS FEATURE CAN BE USED WHEN YOU WANT TO CATCH AN EXCEPTION IN ONE THREAD 
         * AND THROW IT ON ANOTHER THREAD.
         */
        internal static void Csharp5ExceptionDispatchInfoDotThrow()
        {
            ExceptionDispatchInfo possibleException = null;

            try
            {
                Console.WriteLine("Please enter a valid number then press enter.");
                string s = Console.ReadLine();
                int.Parse(s);
            }
            catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }
            if (possibleException != null)
            {
                possibleException.Throw();
            }
        }
    }    
}
