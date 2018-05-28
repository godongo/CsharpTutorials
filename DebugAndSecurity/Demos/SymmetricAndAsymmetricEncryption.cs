using DebugAndSecurity.Concretes;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DebugAndSecurity.Demos
{
    class SymmetricAndAsymmetricEncryption
    {
        // Symmetric encryption and decrypiong.
        internal static void EncryptAndDecryptText()
        {
            string original = "My secret data!";

            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
                // Displays: My secret data!
                Console.WriteLine($"Original: {original}");
                Console.WriteLine($"Round Trip: {roundtrip}");
            }
        }

        private static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        private static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        /* Both sender and reciever will generate pairs of public and private keys.
         * 1. Public key: for Encryption.
         * 2. Private key: for Decryption.
         */
        /* How it works
         * 1. Sender and Reciever exchange public keys.
         * 2. Sender uses the public key they got from reciever to encrypt the data 
         *    and sends it off to the reciever.
         * 3. Reciever uses the corresponding private key to decrypt the data.
         */
        internal static void ExportingPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            Console.WriteLine($"Public Key:{"\n"}{publicKeyXML}{"\n"}");
            Console.WriteLine($"Private Key:{"\n"}{privateKeyXML}");
        }

        internal static void UsingPublicAndPrivatekeyToEncryptAndDecryptData()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string secretData = "My Secret Data!";
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(secretData);

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }

            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!
        }

        /* GeeNote: Loading the key from the key container is the exact same process. 
         *          You can securely store your asymmetric key without malicious users 
         *          being able to read it.
         *          */
        internal static void UsingKeyContainerForStoringAsymmetricKey()
        {
            string containerName = "SecretContainer";
            string secretData = "My Secret Data!";

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(secretData);

            CspParameters csp = new CspParameters()
            {
                KeyContainerName = containerName
            };

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            {
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
        }

        
    }    
}
