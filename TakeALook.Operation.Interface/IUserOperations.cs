using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface IUserOperations : IDisposable
    {
        IUser CreateUser(IUser user);
    }
}
