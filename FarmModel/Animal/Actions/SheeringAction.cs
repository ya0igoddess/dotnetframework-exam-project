using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{
    public abstract class SheeringAction : RefreshableAction
    {
        public string PerformSheering()
        {
           return PerformAction();
        }
    }

    class SheeringWithSheepWool : SheeringAction
    {
        protected override string DoAction()
        {
            return "Sheered some sheep wool";
        }
    }

    class SheeringNoWool : SheeringAction
    {
        protected override string DoAction()
        {
            return "Sheering this animal is unable";
        }
    }
}
