using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    interface IActionProvider
    {
        List<IAction> GetActiveActions();
    }
}
