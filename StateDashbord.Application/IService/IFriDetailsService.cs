﻿using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Application.IService
{
    public interface IFriDetailsService
    {
        Task<Result<string>> sysFriDetails(FriRequest friRequest);
        Task<Result<List<FridataListDto>>> getFriDataByType(int id, int userid, int userposition, int rollid,int addinfo, DateOnly? from_date, DateOnly? to_date);
        Task<Result<List<FridataListDto>>> getFriDataByTypeformap(int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date);
        Task<Result<FRIDetailDto>> getFriDataByid(int id, int userid, int userposition, int rollid);
        Task<Result<additional_informationDto>> getAdditionalInformationByid(int id, int userid, int userposition, int rollid);
        Task<Result<int>> Postadditionalinformation(additionalinformationDto additionalinformationDto);

    }
}
