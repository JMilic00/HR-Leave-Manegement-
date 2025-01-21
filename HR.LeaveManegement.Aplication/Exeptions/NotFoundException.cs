using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Exeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, Object key) : base($"{name} ({key}) was not found")
        {
            
        }
    }
}
