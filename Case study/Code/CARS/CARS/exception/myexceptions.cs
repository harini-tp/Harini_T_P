using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS.exception
{
    public class IncidentNumberNotFound : Exception
    {
        public IncidentNumberNotFound(string Message) : base(Message) { }
        
    }
}
