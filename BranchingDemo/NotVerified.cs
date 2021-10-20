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

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze() => new Frozen(OnUnFreez);

        public IAccountState HolderVerified() => new Active(OnUnFreez);

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
