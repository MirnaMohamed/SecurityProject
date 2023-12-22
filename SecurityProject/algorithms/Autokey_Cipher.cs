

// A C# program to illustrate
// Autokey Cipher Technique
using SecurityProject.algorithms;
using SecurityProject.algorithms.Interfaces;
using SecurityProject.Exceptions;
using System.Text;



 namespace SecurityProject.algorithms
{
public class AutoKey:ICipher
{

  
   private int[] key;
    public AutoKey(string key)
    {
        
         this.key = Program.MessageToCode(key);

        // This if statement is all about C# regular
        // expression
        // [] for range
        // // Extra \ is used to escape one \
        // \\d acts as delimiter
        // ? once or not at all
        // . Any character (may or may not match line
        // terminators)
    
    }

        public string Decrypt(int[] textCode)
        {
            throw new NotImplementedException();
        }

        public  string Encrypt(int[] message)
    {
        int len = message.Length;
        
        // generating the keystream
        int[] newKey =new int[message.Length];
        Array.Copy(key, key.GetLowerBound(0), newKey , newKey .GetLowerBound(0), key.Length);
        Array.Copy(message, message.GetLowerBound(0), newKey , newKey .GetLowerBound(key.Length), message.Length-key.Length);
       // newKey = newKey.Substring(0, newKey.Length  - key.Length);
        int[] encryptMsg = new int[message.Length];

        // applying encryption algorithm
        for (int x = 0; x < len; x++)
        {
            int first = message[x];
            int second = newKey[x];
            int total = (first + second) % 94;
            encryptMsg [x]= total;
        }
        return  Program.CodeToMessage(encryptMsg);
    }

    // public static string Decrypt(string message,
    //                                     string key)
    // {
    //     string currentKey = key;
    //     string decryptMsg = "";

        // applying decryption algorithm
    //     for (int x = 0; x < message.Length; x++)
    //     {
    //         int get1 = codeList.IndexOf(message[x]);
    //         int get2 = codeList.IndexOf(currentKey[x]);
    //         int total = (get1 - get2) % 94;
    //         total = (total < 0) ? total + 94 : total;
    //         decryptMsg += codeList[total];
    //         currentKey += codeList[total];
    //     }
    //     return decryptMsg;
    // }
}

}