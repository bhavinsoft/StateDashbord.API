﻿using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IService
{
    public interface IUserService
    {
        Task<Result<usermasterDto>> GetUserdatabyusernanepassword(string username, string password);
    }
   
}
