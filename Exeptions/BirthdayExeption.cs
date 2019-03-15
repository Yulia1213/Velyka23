using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velyka23.Exeptions
{
    class BirthdayExeption : ArgumentException
    {
        public int Value { get; }
        public BirthdayExeption(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
}
