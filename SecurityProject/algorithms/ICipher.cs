using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProject.algorithms
{
    public interface ICipher
    {
        public string Encrypt(int[] textCode);
        public string Decrypt(int[] textCode);
    }
}
