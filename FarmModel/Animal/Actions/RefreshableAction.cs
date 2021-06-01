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

        public string PerformAction()
        {
            if (isAbleToPerform)
            {
                isAbleToPerform = false;
                return DoAction();
            }
            return "Action can\'t be done";
        }

        /// <summary>
        /// An action that could be done
        /// </summary>
        /// <returns>Text result of action</returns>
        protected abstract string DoAction();
    }
}
