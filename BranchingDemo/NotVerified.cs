using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class NotVerified : IAccountState
    {
        public Action OnUnFreez { get; }

        public NotVerified(Action onUnFreez)
        {
            OnUnFreez = onUnFreez;
        }

        public IAccountState Close()
        {
            return new ClosedAccount();
        }

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze()
        {
            return new Frozen(OnUnFreez);
        }

        public IAccountState HolderVerified()
        {
            return new Active(OnUnFreez);
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
