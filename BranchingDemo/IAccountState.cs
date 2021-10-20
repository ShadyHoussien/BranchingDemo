using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchingDemo
{
    public interface IAccountState
    {
        IAccountState Deposit(decimal amount);
        IAccountState Withdraw(decimal amount);
        IAccountState HolderVerified();
        IAccountState Close();
        IAccountState Freeze();
    }
}
