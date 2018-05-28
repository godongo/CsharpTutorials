using NBitcoin;
using System;

namespace ProgrammingBlockchain.Chapters
{
    class Chapter1
    {
        internal static void Lesson1()
        {
            Key key = new Key(); //generates a new private key.

            PubKey pubKey = key.PubKey; //gets the matching public key.
            Console.WriteLine("Public Key: {0}", pubKey);

            KeyId hash = pubKey.Hash; //gets a hash of the public key.
            Console.WriteLine("Hashed public key: {0}", hash);

            BitcoinPubKeyAddress address = pubKey.GetAddress(Network.Main); //retrieves the bitcoin address.
            Console.WriteLine("Address: {0}", address);

            Script scriptPubKeyFromAddress = address.ScriptPubKey;
            Console.WriteLine("ScriptPubKey from address: {0}", scriptPubKeyFromAddress);

            Script scriptPubKeyFromHash = hash.ScriptPubKey;
            Console.WriteLine("ScriptPubKey from hash: {0}", scriptPubKeyFromHash);
        }
    }
}
