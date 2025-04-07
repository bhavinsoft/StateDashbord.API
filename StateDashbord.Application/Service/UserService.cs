using StateDashbord.Application.IRepository;
using StateDashbord.Application.IService;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateDashbord.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserMasterRepo _usermasterRepo;    
        private  readonly IJwtTokenGenerator _jwtTokenGenerator;
        public UserService(IUserMasterRepo userMasterRepo,IJwtTokenGenerator jwtTokenGenerator)
        {
            _usermasterRepo = userMasterRepo;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<User>> GetUserdatabyusernanepassword(string username, string password)
        {
            var userdto= await _usermasterRepo.GetUserdatabyusernanepassword(username, password);
            if (userdto?.data == null)
            {
                  return Result<User>.FailureResult($"user data not found", 0); // or handle appropriately
            }

            var token = _jwtTokenGenerator.GenerateToken(userdto.data);
            var userdata = new User
            {
                recid = userdto.data.recid,
                username = userdto.data.username,
                token = token,
                emilid = userdto.data.emilid,
                mobileno = userdto.data.mobileno,
                rollid = userdto.data.rollid
                
            };

            return Result<User>.SuccessResult(userdata, "fechdata succesfull", 1);


        }
    }
}
