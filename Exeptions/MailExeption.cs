using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velyka23.Exeptions
{
    class MailExeption : ArgumentException
    {
        public MailExeption(string message)
            : base(message)
        {
       
        }
    }
}
