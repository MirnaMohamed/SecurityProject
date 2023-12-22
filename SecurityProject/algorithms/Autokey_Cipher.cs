using SecurityProject.algorithms.Interfaces;


 namespace SecurityProject.algorithms
{
public class AutoKey:ICipher
{

  
   private int[] key;
    public AutoKey(string key)
    {
        
         this.key = Program.MessageToCode(key);
    
    }
        public string Encrypt(int[] message)
        {
            int len = message.Length;

            // generating the keystream
            int[] newKey = new int[message.Length];
            Array.Copy(key, key.GetLowerBound(0), newKey, newKey.GetLowerBound(0), key.Length);
            Array.Copy(message, message.GetLowerBound(0), newKey, key.Length, message.Length - key.Length);
            int[] encryptMsg = new int[message.Length];

            // applying encryption algorithm
            for (int x = 0; x < len; x++)
            {
                int first = message[x];
                int second = newKey[x];
                int total = (first + second) % 95;
                encryptMsg[x] = total;
            }
            return Program.CodeToMessage(encryptMsg);
        }
        public string Decrypt(int[] encryptedMsg)
        {
            int[] currentKey = new int[encryptedMsg.Length];
            int[] decryptMsg = new int[encryptedMsg.Length];
            Array.Copy(key, key.GetLowerBound(0), currentKey, currentKey.GetLowerBound(0), key.Length);
            //applying decryption algorithm
            for (int x = 0; x < encryptedMsg.Length; x++)
            {
                int encryptedChar = encryptedMsg[x];
                int keyChar;
                if (x == 0)
                    keyChar = currentKey[x];
                else
                    keyChar = currentKey[x - 1];
                int total = (encryptedChar - keyChar) % 95;
                total = (total < 0) ? total + 95 : total;
                decryptMsg[x] = total;
                currentKey[x] = total;
            }
            return Program.CodeToMessage(decryptMsg);
        }
    }

}