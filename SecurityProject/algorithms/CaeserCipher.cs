using SecurityProject.algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProject.algorithms
{
    public class CaeserCipher : ICipher
    {
        int key;
        public CaeserCipher(string key)
        {
            this.key = Convert.ToInt32(key);
        }
        public string Decrypt(int[] cipherText)
        {
            int[] plainText = new int[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                int charCode = ((cipherText[i] - key) +95 )% 95; 
                while (charCode < 0) //to ensure it's not negative
                {
                    charCode = (charCode + 95) % 95;
                }
                plainText[i] = charCode;
            }
            return Program.CodeToMessage(plainText);
        }

        public string Encrypt(int[] plainText)
        {
            int[] cipherText = new int[plainText.Length];
            for(int i=0; i< plainText.Length; i++)
            {
                int charCode = ((plainText[i] + key) +95 )% 95;
                while (charCode < 0)
                {
                    charCode = (charCode + 95) %95;
                }
                cipherText[i] = charCode;
            }
            return Program.CodeToMessage(cipherText);
        }
    }
}
