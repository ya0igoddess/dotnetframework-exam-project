using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{
    abstract class EggsCollectingAction : RefreshableAction
    {
        public void PerformEggsCollectin()
        {
            PerformAction();
        }
    }

    class CollectingWithHenEggs : EggsCollectingAction
    {
        protected override void DoAction()
        {
            //TODO add hens eggs
        }
    }

    class CollectingNoEggs : EggsCollectingAction
    {
        protected override void DoAction()
        {
            //do nothing
        }
    }
}
