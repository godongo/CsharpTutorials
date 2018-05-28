using System;
using System.Security;

namespace DebugAndSecurity.Demos
{
    class SecuringStringData
    {
        internal static void InitializingSecureString()
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter password: ");

                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;
                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                ss.MakeReadOnly();
            }
        }
    }
}
