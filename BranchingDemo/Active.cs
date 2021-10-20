using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class Active : IAccountState
    {
        public Action OnUnFreez { get; }

        public Active(Action onUnFreez)
        {
            OnUnFreez = onUnFreez;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen(OnUnFreez);

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(Action subtractFormBalance)
        {
            subtractFormBalance();
            return this;
        }
    }
}
