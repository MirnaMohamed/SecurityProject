namespace SecurityProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
        Console.Write("Enter the plaintext (alphabetic only): ");
        string plaintext = Console.ReadLine().ToUpper();

        int a, b;

        do
        {
            Console.Write("Enter the value of 'a' (must be coprime to 26): ");
        } while (!int.TryParse(Console.ReadLine(), out a) || !IsCoprime(a, 26));

        Console.Write("Enter the value of 'b': ");
        while (!int.TryParse(Console.ReadLine(), out b)) ;

        // Encryption
        string ciphertext = AffineEncrypt(plaintext, a, b);
        Console.WriteLine("Encrypted text: " + ciphertext);

        // Decryption
        string decryptedText = AffineDecrypt(ciphertext, a, b);
        Console.WriteLine("Decrypted text: " + decryptedText);
    }

    static string AffineEncrypt(string plaintext, int a, int b)
    {
        if (!IsAlphabetic(plaintext))
        {
            throw new ArgumentException("Plaintext must contain alphabetic characters only.");
        }

        string encryptedText = "";

        foreach (char ch in plaintext)
        {
            char encryptedChar;

            if (char.IsLetter(ch))
            {
                encryptedChar = (char)(((a * (ch - 'A') + b) % 26) + 'A');
            }
            else
            {
                encryptedChar = ch;
            }

            encryptedText += encryptedChar;
        }

        return encryptedText;
    }

    static string AffineDecrypt(string ciphertext, int a, int b)
    {
        if (!IsAlphabetic(ciphertext))
        {
            throw new ArgumentException("Ciphertext must contain alphabetic characters only.");
        }

        int aInverse = ModInverse(a, 26);
        string decryptedText = "";

        foreach (char ch in ciphertext)
        {
            char decryptedChar;

            if (char.IsLetter(ch))
            {
                decryptedChar = (char)(((aInverse * (ch - 'A' - b + 26)) % 26) + 'A');
            }
            else
            {
                decryptedChar = ch;
            }

            decryptedText += decryptedChar;
        }

        return decryptedText;
    }

    static int ModInverse(int a, int m)
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

    static bool IsCoprime(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a == 1;
    }

    static bool IsAlphabetic(string text)
    {
        foreach (char ch in text)
        {
            if (!char.IsLetter(ch))
            {
                return false;
            }
        }
        return true;
        }
    }
}
}