using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class Frozen : IAccountState
    {
        public Action OnUnFreez { get; }

        public Frozen(Action onUnFreez)
        {
            OnUnFreez = onUnFreez;
        }
        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            this.OnUnFreez();
            addToBalance();
            return new Active(OnUnFreez);
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            this.OnUnFreez();
            subtractFromBalance();
            return new Active(OnUnFreez);
        }
    }
}
