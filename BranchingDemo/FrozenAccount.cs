using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public class FrozenAccount : IAccountState
    {
        public decimal Balance { get; private set; }
        public Action OnUnFreez { get; }

        public FrozenAccount(Action onUnFreez)
        {
            OnUnFreez = onUnFreez;
        }
        public IAccountState Close()
        {
            return new ClosedAccount();
        }

        public IAccountState Deposit(decimal amount)
        {
            this.OnUnFreez();
            this.Balance += amount;
            return new ActiveAccount(OnUnFreez);
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(decimal amount)
        {
            this.OnUnFreez();
            this.Balance -= amount;
            return new ActiveAccount(OnUnFreez);
        }
    }
}
