using System;

namespace BranchingDemo
{
    class Account
    {
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        private bool IsFrozen { get; set; }
        public decimal Balance { get; private set; }
        private Action OnUnfreez { get; }

        public Account(Action onUnfreez)
        {
            this.OnUnfreez = onUnfreez;
        }
        public void Deposit (decimal amount)
        {
            if (IsClosed)
                return;
            if(this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreez();
            }
            //deposit money
            this.Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;

            if (IsClosed)
                return;

            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreez();
            }
            //withdraw money
            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }
        public void Close()
        {
            this.IsClosed = true;
        }
        public void Freeze()
        {
            if (IsClosed)
                return;
            if (!IsVerified)
                return;

            this.IsFrozen = true;
        }

    }
}
