using System;
using System.Security.Cryptography; // Aes
using System.Numerics; // BigInteger
using System.IO;

namespace P3
{
    class Program
    {
        public static string P3(string[] args)
        {
            // Make sure you are familiar with the System.Numerics.BigInteger class and how to use some of the functions it has (Parse, Pow, ModPow, Subtract, ToByteArray, etc.)

            // optional hint: for encryptiong/ decryption with AES, use google or another search engine to find the microsoft documentation on Aes (google this--> System.Security.Cryptography.Aes)

            // optional hint: here is an example of how to convert the IV input string to a byte array https://gist.github.com/GiveThanksAlways/df9e0fa9e7ea04d51744df6a325f7530

            // you will be using BigInteger functions for almost all, if not all mathmatical operations. (Pow, ModPow, Subtract)
            // N = 2^(N_e) - N_c (this calculation needs to be done using BigInteger.Pow and BigInteger.Subtract)

            // Diffie-Hellman key is g^(xy) mod N. In the input you are given g_y which is g^y. So to make the key you need to perform g_y^(x) using the BigInteger class
            // key = g_y^(x) mod N (this calculation needs to be done using BigInteger.ModPow)

            // you can convert a BigInteger into a byte array using the BigInteger.ToByteArray() function/method

            var initializationVector = ExtractInput(args[0]);
            var n_e = Convert.ToInt32(args[3]);
            var n_c = Convert.ToInt32(args[4]);
            var x = Convert.ToInt32(args[5]);
            var gy = BigInteger.Parse(args[6]);
            var c = ExtractInput(args[7]);
            var p = args[8];
            var n = BigInteger.Subtract(BigInteger.Pow(2, n_e), n_c);
            var key = BigInteger.ModPow(gy, x, n);
            var decrypted = DecryptText(c, key.ToByteArray(), initializationVector);
            byte[] encryptedPT = EncryptText(p, key.ToByteArray(), initializationVector);
            string P3_answer = decrypted + "," + BitConverter.ToString(encryptedPT).Replace("-", " ");
            Console.WriteLine(P3_answer);
            return P3_answer;
            /*

            dotnet run "A2 2D 93 61 7F DC 0D 8E C6 3E A7 74 51 1B 24 B2" 251 465 255 1311 2101864342 8995936589171851885163650660432521853327227178155593274584417851704581358902 "F2 2C 95 FC 6B 98 BE 40 AE AD 9C 07 20 3B B3 9F F8 2F 6D 2D 69 D6 5D 40 0A 75 45 80 45 F2 DE C8 6E C0 FF 33 A4 97 8A AF 4A CD 6E 50 86 AA 3E DF" AfYw7Z6RzU9ZaGUloPhH3QpfA1AXWxnCGAXAwk3f6MoTx

            */
            //string P3_answer = "Edward Snowden"; 
            //return P3_answer;

        }

        private static byte[] ExtractInput(string input)
        {
            int count = 0;
            var splitArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var byteArray = new byte[splitArray.Length];
            foreach (string value in splitArray)
            {
                byteArray.SetValue(Convert.ToByte(value, 16), count);
                count++;
            }
            return byteArray;
        }

        private static byte[] EncryptText(string plain, byte[] key, byte[] initializationVector)
        {
            byte[] cipherText;
            using (var aesAlgorithm = new AesManaged())
            {
                //TODO: This algorithm is not working as expected. Should look into
                // CreateEncryptor class (MSDN Documentation)
                var encryptor = aesAlgorithm.CreateEncryptor(key, initializationVector);
                using var memoryStream = new MemoryStream();
                    using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                        using (var writer = new StreamWriter(cryptoStream))
                            writer.Write(plain);
                    cipherText = memoryStream.ToArray();
            }
            return cipherText;
        }

        private static string DecryptText(byte[] cipher, byte[] key, byte[] initializationVector)
        {
            string original = null;
            using (var aesAlgorithm = new AesManaged())
            {
                //TODO: This algorithm is not working as expected. Should look into
                // CreateDecryptor class (MSDN Documentation)
                var decryptor = aesAlgorithm.CreateDecryptor(key, initializationVector);
                using var memoryStream = new MemoryStream(cipher);
                    using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                        using var read = new StreamReader(cryptoStream);
                            original = read.ReadToEnd();
            }
            return original;
        }

        static void Main(string[] args)
        {
            // args is the array that contains the command line inputs
            P3(args); // This will run your project code. The autograder will grade the return value of the P1_2 function
        }
    }
}
