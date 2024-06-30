using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS_dan
{
    public class Database
    {
        public readonly string connectionString;

        public Database()
        {
            connectionString = @"Server=localhost;Database=dan-ims;Integrated Security=True;";
        }
    }
}