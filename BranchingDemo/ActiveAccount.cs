using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class ActiveAccount : IAccountState
    {
        public decimal Balance { get; private set; }
        public Action OnUnFreez { get; }

        public ActiveAccount(Action onUnFreez)
        {
            OnUnFreez = onUnFreez;
        }
        public IAccountState Close()
        {
            return new ClosedAccount();
        }

        public IAccountState Deposit(decimal amount)
        {
            this.Balance += amount;
            return this;
        }

        public IAccountState Freeze()
        {
            return new FrozenAccount(OnUnFreez);
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return this;
        }
    }
}
