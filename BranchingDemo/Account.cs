﻿using System;

namespace BranchingDemo
{
    class Account
    {
        public decimal Balance { get; private set; }
        private IAccountState AccountState { get; set; }

        public Account(Action onUnfreez)
        {
            this.AccountState = new NotVerified(onUnfreez);
        }

        public void Deposit (decimal amount)
        {
            this.AccountState = AccountState.Deposit(() => { Balance += amount; });
        }
        public void Withdraw(decimal amount)
        {
            this.AccountState = AccountState.Withdraw(() => { Balance -= amount; });
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
