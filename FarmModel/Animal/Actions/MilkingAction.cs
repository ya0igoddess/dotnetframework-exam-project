using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{
    public abstract class MilkingAction : RefreshableAction
    {
        public string PerformMilkin()
        {
           return PerformAction();
        }
    }

    class MilkingWithCowMilk : MilkingAction
    {
        protected override string DoAction()
        {
            return "Milked some cow milk";
        }
    }

    class MilkingWithGoatMilk : MilkingAction
    {
        protected override string DoAction()
        {
            return "Milked some goat milk";
        }
    }

    class MilkingNoMilk : MilkingAction
    {
        protected override string DoAction()
        {
            return "Milking this animal is unable";
        }
    }
}
