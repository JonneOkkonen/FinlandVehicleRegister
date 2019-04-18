using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinlandVehicleRegister.Core
{
    public class IncorrectAPIKeyException : Exception
    {
        public IncorrectAPIKeyException(string message) : base(message)
        {
        }
    }

    public class QueryEmptyException : Exception
    {
        public QueryEmptyException(string message) : base(message)
        {
        }
    }

    public class ZeroResultsFromQueryException : Exception
    {
        public ZeroResultsFromQueryException(string message) : base(message)
        {
        }
    }

    public class MySQLErrorException : Exception
    {
        public MySQLErrorException(string message) : base(message)
        {
        }
    }
}
