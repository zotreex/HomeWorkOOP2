using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOOP2
{
    class ActionProvider : IActionProvider
    {
        public List<IAction> GetActiveActions()
        {
            var actions = new List<IAction>
            {
                new TwoPaperForOneElectronicBook(),
                new PaperDelivery()
            };

            return actions;
        }
    }
}
