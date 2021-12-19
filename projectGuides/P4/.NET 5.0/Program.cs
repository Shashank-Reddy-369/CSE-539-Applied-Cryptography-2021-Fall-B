using System;
using System.Numerics; // BigInteger
using System.Collections.Generic;

namespace P4
{
    class Program
    {
        public static string P4(string[] args)
        {
            /*
            * useful help for RSA encrypt/decrypt: https://www.di-mgt.com.au/rsa_alg.html
            * help with extended euclidean algorithm: https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm
            * 
            */
            BigInteger e = 65537;
            int p_e = int.Parse(args[0]);
            int p_c = int.Parse(args[1]);
            int q_e = int.Parse(args[2]);
            int q_c = int.Parse(args[3]);
            BigInteger cipherText = BigInteger.Parse(args[4]);
            BigInteger plainText = BigInteger.Parse(args[5]);

            BigInteger q = 0, p = 0;
            q = BigInteger.Subtract(BigInteger.Pow(2, q_e), q_c);
            p = BigInteger.Subtract(BigInteger.Pow(2, p_e), p_c);
            BigInteger pi = BigInteger.Multiply(p - 1, q - 1);
            BigInteger d = Program.Compute(e, pi);
            BigInteger out1 = BigInteger.ModPow(cipherText, d, p * q);
            BigInteger out2 = BigInteger.ModPow(plainText, e, p * q);
            var ans = out1.ToString() + "," + out2.ToString();
            Console.WriteLine(ans);
            return ans;

            // Some other helpful links: https://gist.github.com/GiveThanksAlways/00a5c4e911795992268b0c998e2ec487
        }

        public static BigInteger Compute(BigInteger int1, BigInteger int2)
        {
            BigInteger output = 0, var1 = 1;
            BigInteger var2 = 1, var3 = 0;
            BigInteger a = 0, b = 0;
            BigInteger c = 0, d = 0;
            while (int1 != 0)
            {
                a = int2 / int1;
                b = int2 % int1;
                c = output - var2 * a;
                d = var1 - var3 * a;
                int2 = int1;
                int1 = b;
                output = var2;
                var1 = var3;
                var2 = c;
                var3 = d;
            }
            return output;
        }

        static void Main(string[] args)
        {
            // args is the array that contains the command line inputs
            P4(args); // This will run your project code. The autograder will grade the return value of the P1_2 function
        }
    }
}