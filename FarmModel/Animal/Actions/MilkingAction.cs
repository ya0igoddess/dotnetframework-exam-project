﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{
    public abstract class MilkingAction : RefreshableAction
    {
        public void PerformMilkin()
        {
            PerformAction();
        }
    }

    class MilkingWithCowMilk : MilkingAction
    {
        protected override void DoAction()
        {
            //TODO addcowmilk
        }
    }

    class MilkingWithGoatMilk : MilkingAction
    {
        protected override void DoAction()
        {
            //TODO addgoatmilk
        }
    }

    class MilkingNoMilk : MilkingAction
    {
        protected override void DoAction()
        {
            //do nothing
        }
    }
}
