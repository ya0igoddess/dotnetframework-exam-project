using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmModel.Actions
{   
    public abstract class RefreshableAction
    {
        private bool isAbleToPerform = true;

        public void Refresh()
        {
            isAbleToPerform = true;
        }

        public void PerformAction()
        {
            if (isAbleToPerform)
            {
                DoAction();
            }
            isAbleToPerform = false;
        }

        protected abstract void DoAction();
    }
}
