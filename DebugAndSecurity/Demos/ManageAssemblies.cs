using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugAndSecurity.Demos
{
    class ManageAssemblies
    {
        /*
         * Reference Page: 211
         * 1. Use Developer command prompt to generate a new key pair file:
         *    sn -k myKey.snk
         *  
         * 2. An easier way is to use Visual Studio to generate the key pair file for you. 
         *    You can open the property page of the project you want to sign and then navigate 
         *    to the Signing tab
         */
        internal static void Inspecting_The_Public_Key_Of_A_Signed_Sssembly()
        {
            // Reference Page: 213

            // System.Data is a stongly named assembly.

            // C:\>sn -Tp C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Data.dll
        }
    }
}
