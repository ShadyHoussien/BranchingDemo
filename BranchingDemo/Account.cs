using System;

namespace BranchingDemo
{
    class Account
    {
        public decimal Balance { get; private set; }
        private Action OnUnfreez { get; }
        private IAccountState AccountState { get; set; }

        public Account(Action onUnfreez)
        {
            this.OnUnfreez = onUnfreez;
            this.AccountState = new FrozenAccount(OnUnfreez);
        }

        public void Deposit (decimal amount)
        {
            this.AccountState = AccountState.Deposit(amount);
        }
        public void Withdraw(decimal amount)
        {
            this.AccountState = AccountState.Withdraw(amount);
        }

        public void HolderVerified()
        {
            this.AccountState = AccountState.HolderVerified();
        }
        public void Close()
        {
            this.AccountState = AccountState.Close();
        }
        public void Freeze()
        {
            this.AccountState = AccountState.Freeze();
        }

    }
}
