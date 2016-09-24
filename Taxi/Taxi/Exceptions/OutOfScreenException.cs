using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.Exceptions
{
    class OutOfScreenException:Exception
    {
        public override string Message
        {
            get
            {
                return "Выход за пределы экрана";
            }
        }
    }
}
