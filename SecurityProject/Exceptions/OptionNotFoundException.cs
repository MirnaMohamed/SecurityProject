using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProject.Exceptions
{
    public class OptionNotFoundException : Exception
    {
        public OptionNotFoundException(string v) : base(v) 
        {
        }
    }
}
