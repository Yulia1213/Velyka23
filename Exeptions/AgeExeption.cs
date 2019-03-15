using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velyka23.Exeptions
{
    class AgeExeption : ArgumentException
    {
        public int Value { get; }
        public AgeExeption(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
    
}
