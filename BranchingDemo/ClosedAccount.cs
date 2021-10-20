﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    class ClosedAccount : IAccountState
    {
        public IAccountState Close() => this;
        public IAccountState Deposit(Action addToBalance) => this;
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
        public IAccountState Withdraw(Action subtractFormBalance) => this;
    }
}
