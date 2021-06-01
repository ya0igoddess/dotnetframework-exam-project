using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{
    public abstract class EggsCollectingAction : RefreshableAction
    {
        public string PerformEggsCollectin()
        {
            return PerformAction();
        }
    }

    class CollectingWithHenEggs : EggsCollectingAction
    {
        protected override string DoAction()
        {
            return "Collectes some hen eggs";
        }
    }

    class CollectingNoEggs : EggsCollectingAction
    {
        protected override string DoAction()
        {
            return "Collecting eggs from this animal is unable";
        }
    }
}
