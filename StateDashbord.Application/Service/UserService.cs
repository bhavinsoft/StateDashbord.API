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

        public async Task<Result<usermasterDto>> GetUserdatabyusernanepassword(string username, string password)
        {
            var userdto= await _usermasterRepo.GetUserdatabyusernanepassword(username, password);
            if (userdto?.data == null)
            {
                  return Result<usermasterDto>.FailureResult($"user data not found", 0); // or handle appropriately
            }

            var token = _jwtTokenGenerator.GenerateToken(userdto.data);
            var userdata = new usermasterDto
            {
                recid = userdto.data.recid,
                username = userdto.data.username,
                token = token,
                emilid = userdto.data.emilid,
                mobileno = userdto.data.mobileno,
                rollid = userdto.data.rollid
                
            };

            return Result<usermasterDto>.SuccessResult(userdata, "fechdata succesfull", 1);


        }
    }
}
