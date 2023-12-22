using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityProject;

namespace SecurityProject.algorithms
{
    public class AffineCipher : ICipher
    {
        int a, b;
        public AffineCipher(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public string Encrypt(int[] codeList)
        {
            bool check = false;
            if (a > 94)
            {
                check = GCD(a, 94);
            }
            else
                check = GCD(94, a);
            if (check == true)
            {
                int[] encryptedCode = new int[codeList.Length];
                int i = 0;
                foreach (int ch in codeList)
                {
                    int encryptedChar = ((a * ch) + b) % 94;
                    encryptedCode[i++] = encryptedChar;
                }
                string encryptedText = Program.CodeToMessage(encryptedCode);
                return encryptedText;
            }
            else
                return null; //if GCD(1,0) is False, then you can't encrypt this text
        }

        public string Decrypt(int[] ciphertext)
        {
            int aInverse = ModInverse(a, 94);
            int[] decryptedCodeList = new int[ciphertext.Length];
            int i = 0;
            foreach (int ch in ciphertext)
            {
                int decryptedCode;
                int x = ch - b; //to check that it's not negative before calculating the mode
                if(x >= 0)
                    decryptedCode = aInverse * x % 94;
                else
                    decryptedCode = aInverse * (x+94) %94;

                decryptedCodeList[i++] = decryptedCode;
            }
            string decryptedText = Program.CodeToMessage(decryptedCodeList);
            return decryptedText;
        }

        static int ModInverse(int a, int m) //gets the modular inverse of a^-1
        {
            for (int i = 0; i < m; i++)
            {
                if ((a * i) % m == 1)
                {
                    return i;
                }
            }
            throw new ArgumentException("Modular inverse does not exist.");
        }

        static bool GCD(int N, int a)
        {
            while (a != 0)
            {
                int remainder = a;
                a = N % a;
                N = remainder;
            }
            //check if GCD(1,0)
            return N == 1;
        }
    }
}
    
