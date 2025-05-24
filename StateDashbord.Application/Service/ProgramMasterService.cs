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
    public class ProgramMasterService : IProgramMasterService
    {
        private readonly IProgramMasterRepo  _programMasterRepo;    
       
        public ProgramMasterService(IProgramMasterRepo programMasterRepo)
        {
            _programMasterRepo = programMasterRepo;
        }

        public async Task<Result<List<program_masterViewDto>>> getProgramMasterList(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _programMasterRepo.getProgramMasterList(id,userid, userposition, rollid, from_date, to_date);

            var festivalDtoList = result.data.Select(x => new program_masterViewDto
            {
                recid = x.recid,
                districtid = x.districtid,
                district_name = x.district_name,
                policestationid = x.policestationid,
                policestation_name = x.policestation_name,
                categoryid = x.categoryid,
                categoryname = x.categoryname,
                programdetails = x.programdetails,
                organizers_name = x.organizers_name,
                organizers_designation = x.organizers_designation,
                organizers_organizationname = x.organizers_organizationname,
                organizers_mobile = x.organizers_mobile,
                organizers_address = x.organizers_address,
                if_program_approved = x.if_program_approved,
                if_program_approved_text = x.if_program_approved == true ? "હા" : x.if_program_approved == false ? "ના" : "-",
                approver_name = x.approver_name,
                approver_designation = x.approver_designation,
                approver_datetime = x.approver_datetime,
                program_subject = x.program_subject,
                program_place = x.program_place,
                program_routeinfo = x.program_routeinfo,
                programsensitiveroute_pointsinto = x.programsensitiveroute_pointsinto,
                if_affectlaw_sensitiveroute = x.if_affectlaw_sensitiveroute,
                if_affectlaw_sensitiveroute_text = x.if_affectlaw_sensitiveroute == true ? "હા" : x.if_affectlaw_sensitiveroute == false ? "ના" : "-",
                program_number = x.program_number,
                if_arrestperson = x.if_arrestperson,
                if_arrestperson_text = x.if_arrestperson == true ? "હા" : x.if_arrestperson == false ? "ના" : "-",
                arrestperson_name = x.arrestperson_name,
                arrestperson_designation = x.arrestperson_designation,
                arrestperson_organizationname = x.arrestperson_organizationname,
                arrestperson_mobile = x.arrestperson_mobile,
                program_date = x.program_date,
                remarks = x.remarks,
            }).ToList();
           


            return Result<List<program_masterViewDto>>.SuccessResult(festivalDtoList, "fechdata succesfull", 1);
        }

        public async Task<Result<int>> PostProgramMaster(program_masterDto programMaster)
        {
            program_master program_Master = new program_master();
            program_Master.recid = programMaster.recid;
            program_Master.districtid = programMaster.districtid;
            program_Master.policestationid = programMaster.policestationid;
            program_Master.categoryid = programMaster.categoryid;
            program_Master.programdetails = programMaster.programdetails;
            program_Master.organizers_name = programMaster.organizers_name;
            program_Master.organizers_designation = programMaster.organizers_designation;
            program_Master.organizers_organizationname = programMaster.organizers_organizationname;
            program_Master.organizers_mobile = programMaster.organizers_mobile;
            program_Master.organizers_address = programMaster.organizers_address;
            program_Master.if_program_approved = programMaster.if_program_approved;
            program_Master.approver_name = programMaster.approver_name;
            program_Master.approver_designation = programMaster.approver_designation;
            program_Master.approver_datetime = programMaster.approver_datetime;
            program_Master.program_subject = programMaster.program_subject;
            program_Master.program_place = programMaster.program_place;
            program_Master.program_routeinfo = programMaster.program_routeinfo;
            program_Master.programsensitiveroute_pointsinto = programMaster.programsensitiveroute_pointsinto;
            program_Master.if_affectlaw_sensitiveroute = programMaster.if_affectlaw_sensitiveroute;
            program_Master.program_number = programMaster.program_number;
            program_Master.if_arrestperson = programMaster.if_arrestperson;
            program_Master.arrestperson_name = programMaster.arrestperson_name;
            program_Master.arrestperson_designation = programMaster.arrestperson_designation;
            program_Master.arrestperson_organizationname = programMaster.arrestperson_organizationname;
            program_Master.arrestperson_mobile = programMaster.arrestperson_mobile;
            program_Master.program_date = programMaster.program_date;
            program_Master.remarks = programMaster.remarks;

            var result =await _programMasterRepo.PostProgramMaster(program_Master);
            if (result.sucess)
            {
                return Result<int>.SuccessResult(result.data, $"Data Save Successfully", 1);
            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
            }
        }
    }
}
