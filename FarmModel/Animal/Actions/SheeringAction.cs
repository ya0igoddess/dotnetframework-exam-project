using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{
    public abstract class SheeringAction : RefreshableAction
    {
        public void PerformSheering()
        {
            PerformAction();
        }
    }

    class SheeringWithSheepWool : SheeringAction
    {
        protected override void DoAction()
        {
            //TODO add sheep wool
        }
    }

    class SheeringNoWool : SheeringAction
    {
        protected override void DoAction()
        {
            //do nothing
        }
    }
}
