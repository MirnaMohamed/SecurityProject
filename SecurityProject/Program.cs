using SecurityProject.algorithms;
using SecurityProject.algorithms.Interfaces;
using SecurityProject.Exceptions;
using System.Text;

namespace SecurityProject
{
    public class Program
    {
        public static string text;
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to do?");
            Console.Write("Type 1 to encrypt and 2 to decrypt: ");
            string isCiphered = Console.ReadLine();
            switch (isCiphered)
            {
                case "1":
                    Console.Write("Enter your text (alphabetic only): ");
                    text = Console.ReadLine();
                    EncryptionMethod(MessageToCode(text));
                    break;
                case "2":
                    Console.Write("Enter your text (alphabetic only): ");
                    text = Console.ReadLine();
                    DecryptionMethod(MessageToCode(text));
                    break;
                default:
                    throw new OptionNotFoundException("Please select 1 or 2 only");
            }
        }
        public static int[] MessageToCode(string message)
        {
            int[] codeList = new int[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsLetter(message[i]))
                {
                    if (char.IsLower(message[i]))
                    {
                        codeList[i] = message[i] - 96;
                    }
                    else if (char.IsUpper(message[i]))
                    {
                        codeList[i] = message[i] - 64 + 26;
                    }
                }
                else if (char.IsNumber(message[i]))
                {
                    codeList[i] = 53 + (message[i] - '0');
                }
                else //symbols
                {
                    switch (message[i])
                    {
                        case ' ':
                            codeList[i] = 0;
                            break;
                        case '!':
                            codeList[i] = 63;
                            break;
                        case '\"':
                            codeList[i] = 64;
                            break;
                        case '#':
                            codeList[i] = 65;
                            break;
                        case '$':
                            codeList[i] = 66;
                            break;
                        case '%':
                            codeList[i] = 67;
                            break;
                        case '&':
                            codeList[i] = 68;
                            break;
                        case '\'':
                            codeList[i] = 69;
                            break;
                        case '(':
                            codeList[i] = 70;
                            break;
                        case ')':
                            codeList[i] = 71;
                            break;
                        case '*':
                            codeList[i] = 72;
                            break;
                        case '+':
                            codeList[i] = 73;
                            break;
                        case ',':
                            codeList[i] = 74;
                            break;
                        case '-':
                            codeList[i] = 75;
                            break;
                        case '.':
                            codeList[i] = 76;
                            break;
                        case '/':
                            codeList[i] = 77;
                            break;
                        case ':':
                            codeList[i] = 78;
                            break;
                        case ';':
                            codeList[i] = 79;
                            break;
                        case '<':
                            codeList[i] = 80;
                            break;
                        case '=':
                            codeList[i] = 81;
                            break;
                        case '>':
                            codeList[i] = 82;
                            break;
                        case '?':
                            codeList[i] = 83;
                            break;
                        case '@':
                            codeList[i] = 84;
                            break;
                        case '[':
                            codeList[i] = 85;
                            break;
                        case '\\':
                            codeList[i] = 86;
                            break;
                        case ']':
                            codeList[i] = 87;
                            break;
                        case '^':
                            codeList[i] = 88;
                            break;
                        case '_':
                            codeList[i] = 89;
                            break;
                        case '`':
                            codeList[i] = 90;
                            break;
                        case '{':
                            codeList[i] = 91;
                            break;
                        case '|':
                            codeList[i] = 92;
                            break;
                        case '}':
                            codeList[i] = 93;
                            break;
                        case '~':
                            codeList[i] = 94;
                            break;
                    }
                }
            }
            return codeList;
        }
        public static string CodeToMessage(int[] codeList)
        {
            StringBuilder message = new StringBuilder();
            for(int i=0; i< codeList.Length; i++)
            {
                char character;
                if (codeList[i] > 0 && codeList[i] <= 26)
                    message.Append( Convert.ToChar(codeList[i] + 96));
                else if (codeList[i] >26 && codeList[i] <=52)
                    message.Append(Convert.ToChar(codeList[i] + 64 -26));
                else if (codeList[i] >52 && codeList[i] <=62)
                    message.Append(Convert.ToChar((codeList[i] + '0') - 53));
                else // symbols
                {
                    switch (codeList[i])
                    {
                        case 0:
                            message.Append(' ');
                            break;
                        case 63:
                            message.Append('!');
                            break;
                        case 64:
                            message.Append('\"');
                            break;
                        case 65:
                            message.Append('#');
                            break;
                        case 66:
                            message.Append('$');
                            break;
                        case 67:
                            message.Append('%');
                            break;
                        case 68:
                            message.Append('&');
                            break;
                        case 69:
                            message.Append('\'');
                            break;
                        case 70:
                            message.Append('(');
                            break;
                        case 71:
                            message.Append(')');
                            break;
                        case 72:
                            message.Append('*');
                            break;
                        case 73:
                            message.Append('+');
                            break;
                        case 74:
                            message.Append(',');
                            break;
                        case 75:
                            message.Append('-');
                            break;
                        case 76:
                            message.Append('.');
                            break;
                        case 77:
                            message.Append('/');
                            break;
                        case 78:
                            message.Append(':');
                            break;
                        case 79:
                            message.Append(';');
                            break;
                        case 80:
                            message.Append('<');
                            break;
                        case 81:
                            message.Append('=');
                            break;
                        case 82:
                            message.Append('>');
                            break;
                        case 83:
                            message.Append('?');
                            break;
                        case 84:
                            message.Append('@');
                            break;
                        case 85:
                            message.Append('[');
                            break;
                        case 86:
                            message.Append('\\');
                            break;
                        case 87:
                            message.Append(']');
                            break;
                        case 88:
                            message.Append('^');
                            break;
                        case 89:
                            message.Append('_');
                            break;
                        case 90:
                            message.Append('`');
                            break;
                        case 91:
                            message.Append('{');
                            break;
                        case 92:
                            message.Append('|');
                            break;
                        case 93:
                            message.Append('}');
                            break;
                        case 94:
                            message.Append('~');
                            break;
                    }
                }
            }
            return message.ToString();
        }
        static string EncryptionMethod(int[] codeList)
        {
            Console.WriteLine("Select the type of algorithm you want to encode your message with ");
            Console.Write("Choose 1 for Affine, 2 for Autokey, 3 for Vigenere, or 4 for Caeser: ");
            string method = Console.ReadLine().ToLower();
            ICipher encrypt = null;
            switch (method)
            {
                case "affine":
                case "1":
                    Console.Write("Enter a: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Enter b: ");
                    int b = int.Parse(Console.ReadLine());
                    encrypt = new AffineCipher(a,b);
                    break;
                case "autokey":
                case "2": //autokey
                    Console.Write("Enter key: ");
                    string Akey = Console.ReadLine();
                    encrypt = new AutoKey(Akey);
                    break;
                case "vigenere":
                case "3": //vigenere
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();
                    encrypt = new VigenereCipher(key);
                    break;
                case "caeser":
                case "4": //caeser
                    break;
                default:
                    throw new OptionNotFoundException("Please select one of the following options:\n" +
                        "1.Affine 2.Autokey 3.Vigenere 4.Caeser");
                    EncryptionMethod(MessageToCode(text));

            }
            string cipherText = encrypt.Encrypt(codeList);
            Console.Write("The encrypted message is: \"" );
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(cipherText);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"\n");
            return cipherText;
        }
        static string DecryptionMethod(int[] codeList)
        {
            Console.WriteLine("Select the type of algorithm you want to decode your message with ");
            Console.Write("Choose 1 for Affine, 2 for Autokey, 3 for Vigenere, or 4 for Caeser: ");
            string method = Console.ReadLine().ToLower();
            ICipher decrypt = null;
            switch (method)
            {
                case "affine":
                case "1":
                    Console.Write("Enter a: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Enter b: ");
                    int b = int.Parse(Console.ReadLine());
                    decrypt = new AffineCipher(a, b);
                    break;
                case "autokey":
                case "2": //autokey
                    Console.Write("Enter key: ");
                    string Akey = Console.ReadLine();
                    decrypt = new AutoKey(Akey);
                    break;
                case "vigenere":
                case "3": //vigenere
                    Console.Write("Enter key: ");
                    string key = Console.ReadLine();
                    decrypt = new VigenereCipher(key);
                    break;
                case "caeser":
                case "4": //caeser
                    break;
                default:
                    throw new OptionNotFoundException("Please select one of the following options:\n" +
                        "1.Affine 2.Autokey 3.Vigenere 4.Caeser");
                    DecryptionMethod(MessageToCode(text));

            }
            string plainText = decrypt.Decrypt(codeList);
            Console.Write("The encrypted message is: \"");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(plainText);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\"\n");
            return plainText;
        }
    }
}