using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    public interface IUserControlRequest
    {
        string NameOfControl { get; set; }
        object Inputs { get; set; }
    }
}
