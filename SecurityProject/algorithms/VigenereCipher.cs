using SecurityProject.algorithms.Interfaces;
using System.CodeDom.Compiler;

namespace SecurityProject.algorithms
{
    public class VigenereCipher : ICipher
    {
        private int[] key;
        public VigenereCipher(string key)
        {
            this.key = Program.MessageToCode(key);
        }
        private int[] generateKey(string plainText)
        {
            int[] finalKey = new int[plainText.Length];
            if (key.Length == plainText.Length)
            {
                return key;
            }
            else
            {
                Array.Copy(key, key.GetLowerBound(0), finalKey, finalKey.GetLowerBound(0), key.Length);
                for (int i = 0; i < plainText.Length - key.Length; i++)
                {
                    finalKey[i + key.Length] = key[i % key.Length];

                }

                return finalKey;
            }
        }


        public string Encrypt(int[] textCode)
        {
            int[] FinalKey = generateKey(Program.CodeToMessage(textCode));
            int[] EncryptedList = new int[textCode.Length];
            for (int i = 0; i < textCode.Length; i++)
            {
                // converting in range 0-94
                int EncryptedCode;

                // convert into alphabets(ASCII)
                //x += 'A';
                if (textCode[i] == 0)
                {
                    EncryptedCode = 0;
                }
                else
                {
                    // converting in range 0-94
                    EncryptedCode = (textCode[i] + FinalKey[i]) % 95;
                }

                EncryptedList[i] = EncryptedCode;
            }
            return Program.CodeToMessage(EncryptedList);
        }

        public string Decrypt(int[] textCode)
        {
            int[] FinalKey = generateKey(Program.CodeToMessage(textCode));
            int[] DecryptedList = new int[textCode.Length];
            for (int i = 0; i < textCode.Length; i++)
            {
                int DecryptedCode;


                // convert into alphabets(ASCII)
                //x += 'A';
                if (textCode[i] == 0)
                {
                    DecryptedCode = 0;
                }
                else
                {
                    // converting in range 0-94 in case negative numbers
                    DecryptedCode = (textCode[i] - FinalKey[i] + 95) % 95;
                }

                DecryptedList[i] = DecryptedCode;


            }
            return Program.CodeToMessage(DecryptedList);

        }
    }
}
