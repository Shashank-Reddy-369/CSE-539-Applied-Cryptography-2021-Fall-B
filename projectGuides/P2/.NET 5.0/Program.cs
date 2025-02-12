using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace P2
{
    class Program
    {
        // This function will help us get the input from the command line
        public static string GetInputFromCommandLine(string[] args)
        {
            // get the input from the command line
            string input = "";
            if (args.Length == 1)
            {
                input = args[0]; // Gets the first string after the 'dotnet run' command
            }
            else
            {
                Console.WriteLine("Not enough or too many inputs provided after 'dotnet run' ");
            }
            return input;
        }
        
        public static string P2(string[] args)
        {
            // Some helpful hints:
            // The main idea is to concateneate the salt to a random string, 
            // then feed that into the hashFunction, 
            // then keep track of those salted hashes until you find a matching pair of salted hashes, 
            // then print the solution which is the two strings that gave the matching salted hashes
            // NOTE: When I say salted hashes, I mean that you salted the password and then fed it into the hashFunction. So it is the hash of the password+salt (in this case "+" means concatenated together into one)

            // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netcore-3.1
            // hint: what does Create() do?

            // optional hint: review converting a string into a byte array (byte[]) and the reverse, converting a byte array (byte[]) into a string BitConverter.ToString(exampleByteArray).Replace("-", " ");

            // This code will convert a string to a byte array
            //string example = "Edward Snowden";
            //byte[] exampleByteArray = Encoding.UTF8.GetBytes(example);

            // passwords have to be made only using alphanumeric characters, so you can make random passwords using any of the characters in the string provided below (note: The starter code doesn't include lowercase just for simplicity but you can include lowercase as well. )
            string alphanumeric_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            // optional hint: What data structure can you use to store the salted hashes that has a really fast lookup time of O(1) (constant) ?
            // You don't have to use this data structure, but it will make your code run fast. The System.Collections.Generic libary is a good place to start

            // TODO: Employ the Birthday Paradox to find a collision in the MD5 hash function

            // These were given as en example, you are going to have to find two passwords that have matching salted hashes with your code and then output them for the autograder to see
            string salt = GetInputFromCommandLine(args);
            string password1 = "AQJCMW0DGL";
            string password2 = "I95ORWB1A7";
            int size = 10;
            bool found = false;
            var saltHashPT = new Dictionary<string, string>();
            while(!found)
            {
                var newText = GetRandomText(alphanumeric_characters, size);
                var newHash = ComputeHash(newText, salt);
                if (!saltHashPT.ContainsKey(newHash))
                    saltHashPT.Add(newHash, newText);
                else if(saltHashPT[newHash] != newText)
                {
                    password1 = saltHashPT[newHash];
                    password2 = newText;
                    break;
                }

            }    
            string P2_answer = password1 + "," + password2;
            Console.WriteLine(P2_answer); // you can still print things to the console. The autograder will ignore this, it will only test the return value of this function
            // return the solution to the autograder
            return P2_answer; // autograder will grade this value to see if it is correct
        }

        static void Main(string[] args)
        {
            // args is the array that contains the command line inputs
            P2(args); // This will run your project code. The autograder will grade the return value of the P1_2 function
        }

        public static string GetRandomText(string alphanumeric_characters, int size)
        {
            string output = "";
            for (int i = 0; i < size; i++)
            {
                Random rand = new Random();
                int num = rand.Next(0, 62);
                output += alphanumeric_characters[num];
            }
            return output;
        }

        public static string ComputeHash(string plainText, string salt)
        {
            string output;
            var oldData = Encoding.UTF8.GetBytes(plainText);
            var computedData = new byte[oldData.Length + 1];
            for (int i = 0; i < oldData.Length; i++)
                computedData[i] = oldData[i];
            computedData[oldData.Length] = Convert.ToByte(salt, 16);
            MD5 md5 = MD5.Create();
            var hashed = md5.ComputeHash(computedData);
            output = BitConverter.ToString(hashed).Replace("-", " ").Substring(0, 14);
            return output;
        }

    }
}
