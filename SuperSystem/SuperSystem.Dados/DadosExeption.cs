using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSystem.Dados
{
    public class DadosException : Exception
    {
        public DadosException(string message) : base(message)
        {

        }
        public static void when(bool hasError, string message)
        {
            if (hasError)
            {
                throw new DadosException(message);
            }
        }
    }
}
