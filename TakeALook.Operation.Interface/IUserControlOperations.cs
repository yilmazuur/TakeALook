﻿using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface IUserControlOperations
    {
        IUserControlDto LoadUserControl(IUserControlRequest request);
    }
}