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
using System.Xml.Linq;

namespace StateDashbord.Application.Service
{
    public class ProgramMasterService : IProgramMasterService
    {
        private readonly IProgramMasterRepo  _programMasterRepo;    
       
        public ProgramMasterService(IProgramMasterRepo programMasterRepo)
        {
            _programMasterRepo = programMasterRepo;
        }

        public async Task<Result<after_program_masterViewDto>> getafterProgramMasterById(int id, int userid, int userposition, int rollid)
        {
            var result = await _programMasterRepo.getafterProgramMasterById(id, userid, userposition, rollid);
            if (result.sucess_code != 0)
            {

                var afterprogrammasterViewDto = new after_program_masterViewDto
                {
                    recid = result.data.recid,
                    progid = result.data.progid,
                    ifprogramapproved = result.data.ifprogramapproved,
                    ifprogramapproved_text = result.data.ifprogramapproved == true ? "હા" : result.data.ifprogramapproved == false ? "ના" : "-",
                    programapprovedinfo = result.data.programapprovedinfo,
                    peoplecount = result.data.peoplecount,
                    ifprobleminprogram = result.data.ifprobleminprogram,
                    ifprobleminprogram_text = result.data.ifprobleminprogram == true ? "હા" : result.data.ifprobleminprogram == false ? "ના" : "-",
                    probleminprograminfo = result.data.probleminprograminfo,
                    peoplecomeprogramprogram = result.data.peoplecomeprogramprogram,
                    peoplecomeprogramprogram_text = result.data.peoplecomeprogramprogram == true ? "હા" : result.data.peoplecomeprogramprogram == false ? "ના" : "-",
                    peoplecomeprogramprograminfo = result.data.peoplecomeprogramprograminfo,
                    ifanyprecautionstaken = result.data.ifanyprecautionstaken,
                    ifanyprecautionstaken_text = result.data.ifanyprecautionstaken == true ? "હા" : result.data.ifanyprecautionstaken == false ? "ના" : "-",
                    precautionstakeninfo = result.data.precautionstakeninfo,
                    ifcomplaintbeenfiled = result.data.ifcomplaintbeenfiled,
                    ifcomplaintbeenfiled_text = result.data.ifcomplaintbeenfiled == true ? "હા" : result.data.ifcomplaintbeenfiled == false ? "ના" : "-",
                    complaintbeenfileinfo = result.data.complaintbeenfileinfo,
                    ifthereanysuspension = result.data.ifthereanysuspension,
                    ifthereanysuspension_text = result.data.ifthereanysuspension == true ? "હા" : result.data.ifthereanysuspension == false ? "ના" : "-",
                    ifanysuspectsyettobecaught = result.data.ifanysuspectsyettobecaught,
                    ifanysuspectsyettobecaught_text = result.data.ifanysuspectsyettobecaught == true ? "હા" : result.data.ifanysuspectsyettobecaught == false ? "ના" : "-",

                    dtlprogramsuspension = result.data.dtlprogramsuspension?.Select(x => new dtl_program_suspensionDto
                    {
                        p_name = x.p_name,
                        p_number = x.p_number,
                        p_adress = x.p_adress
                    }).ToList(),
                    dtlprogramnotcaughtsuspension = result.data.dtlprogramnotcaughtsuspension?.Select(x => new dtl_program_notcaught_suspensionDto
                    {
                        p_name = x.p_name,
                        p_number = x.p_number,
                        p_adress = x.p_adress
                    }).ToList(),
                };

                return Result<after_program_masterViewDto>.SuccessResult(afterprogrammasterViewDto, "fechdata succesfull", 1);
            }
            else
            {
               
                return Result<after_program_masterViewDto>.FailureResult(result.message, 0);
            }
        }
        public async Task<Result<program_masterViewDto>> getProgramMasterById(int id, int userid, int userposition, int rollid)
        {
            var result = await _programMasterRepo.getProgramMasterById(id, userid, userposition, rollid);

            if (result.sucess_code != 0)
            {

                var programmasterData = new program_masterViewDto
                {
                    recid = result.data.recid,
                    districtid = result.data.districtid,
                    district_name = result.data.district_name,
                    policestationid = result.data.policestationid,
                    policestation_name = result.data.policestation_name,
                    categoryid = result.data.categoryid,
                    categoryname = result.data.categoryname,
                    programdetails = result.data.programdetails,
                    organizers_name = result.data.organizers_name,
                    organizers_designation = result.data.organizers_designation,
                    organizers_organizationname = result.data.organizers_organizationname,
                    organizers_mobile = result.data.organizers_mobile,
                    organizers_address = result.data.organizers_address,
                    if_program_approved = result.data.if_program_approved,
                    if_program_approved_text = result.data.if_program_approved == true ? "હા" : result.data.if_program_approved == false ? "ના" : "-",
                    approver_name = result.data.approver_name,
                    approver_designation = result.data.approver_designation,
                    approver_datetime = result.data.approver_datetime,
                    program_subject = result.data.program_subject,
                    program_place = result.data.program_place,
                    program_routeinfo = result.data.program_routeinfo,
                    programsensitiveroute_pointsinto = result.data.programsensitiveroute_pointsinto,
                    if_affectlaw_sensitiveroute = result.data.if_affectlaw_sensitiveroute,
                    if_affectlaw_sensitiveroute_text = result.data.if_affectlaw_sensitiveroute == true ? "હા" : result.data.if_affectlaw_sensitiveroute == false ? "ના" : "-",
                    program_number = result.data.program_number,
                    if_arrestperson = result.data.if_arrestperson,
                    if_arrestperson_text = result.data.if_arrestperson == true ? "હા" : result.data.if_arrestperson == false ? "ના" : "-",

                    program_date = result.data.program_date,
                    remarks = result.data.remarks,
                    dtl_Program_ArrestpersonDto = result.data.dtl_Program_Arrestpeople?.Select(x => new dtl_program_arrestpersonDto
                    {
                        arrestperson_designation = x.arrestperson_designation,
                        arrestperson_mobile = x.arrestperson_mobile,
                        arrestperson_name = x.arrestperson_name,
                        arrestperson_organizationname = x.arrestperson_organizationname,
                    }).ToList()
                };



                return Result<program_masterViewDto>.SuccessResult(programmasterData, "fechdata succesfull", 1);
            }
            else
            {
                return Result<program_masterViewDto>.FailureResult(result.message, 0);
            }
        }

        public async Task<Result<List<program_masterViewDto>>> getProgramMasterList(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            var result = await _programMasterRepo.getProgramMasterList(id,userid, userposition, rollid, from_date, to_date);

            var programmasterViewDtoList = result.data.Select(x => new program_masterViewDto
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
               
                program_date = x.program_date,
                remarks = x.remarks,
                afterproid = x.afterproid
            }).ToList();
           


            return Result<List<program_masterViewDto>>.SuccessResult(programmasterViewDtoList, "fechdata succesfull", 1);
        }

        public async Task<Result<int>> PostAfterProgramMaster(after_program_masterDto afterprogrammasterDto)
        {
            postafterprogrammaster postafterprogrammaster = new postafterprogrammaster();

            postafterprogrammaster.afterprogrammaster = new after_program_master
            {
                recid = afterprogrammasterDto.recid,
                progid = afterprogrammasterDto.progid,
                ifprogramapproved = afterprogrammasterDto.ifprogramapproved,
                programapprovedinfo = afterprogrammasterDto.programapprovedinfo,
                peoplecount = afterprogrammasterDto.peoplecount,
                ifprobleminprogram = afterprogrammasterDto.ifprobleminprogram,
                probleminprograminfo = afterprogrammasterDto.probleminprograminfo,
                peoplecomeprogramprogram = afterprogrammasterDto.peoplecomeprogramprogram,
                peoplecomeprogramprograminfo = afterprogrammasterDto.peoplecomeprogramprograminfo,
                ifanyprecautionstaken = afterprogrammasterDto.ifanyprecautionstaken,
                precautionstakeninfo =afterprogrammasterDto.precautionstakeninfo,
                ifcomplaintbeenfiled = afterprogrammasterDto.ifcomplaintbeenfiled,
                complaintbeenfileinfo=afterprogrammasterDto.complaintbeenfileinfo,
                ifthereanysuspension =afterprogrammasterDto.ifthereanysuspension,
                ifanysuspectsyettobecaught=afterprogrammasterDto.ifanysuspectsyettobecaught
            };
            if(afterprogrammasterDto.dtlprogramsuspension != null)
            {
                postafterprogrammaster.dtlprogramsuspension = afterprogrammasterDto.dtlprogramsuspension?.Select(x => new dtl_program_suspension
                {
                    p_name = x.p_name,
                    p_number = x.p_number,
                    p_adress = x.p_adress
                   
                }).ToList();
            }
            if (afterprogrammasterDto.dtlprogramnotcaughtsuspension != null)
            {
                postafterprogrammaster.dtlprogramnotcaughtsuspension = afterprogrammasterDto.dtlprogramnotcaughtsuspension?.Select(x => new dtl_program_notcaught_suspension
                {
                    p_name = x.p_name,
                    p_number = x.p_number,
                    p_adress = x.p_adress

                }).ToList();
            }

            var result = await _programMasterRepo.PostAfterProgramMaster(postafterprogrammaster);
            if (result.sucess)
            {
                return Result<int>.SuccessResult(result.data, $"Data Save Successfully", 1);
            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);
            }
        }

        public async Task<Result<int>> PostProgramMaster(program_masterDto programMaster)
        {


            Postprogram_master postprogram_Master = new Postprogram_master();
            postprogram_Master.program_Master = new program_master
            {
                recid = programMaster.recid,
                districtid = programMaster.districtid,
                policestationid = programMaster.policestationid,
                categoryid = programMaster.categoryid,
                programdetails = programMaster.programdetails,
                organizers_name = programMaster.organizers_name,
                organizers_designation = programMaster.organizers_designation,
                organizers_organizationname = programMaster.organizers_organizationname,
                organizers_mobile = programMaster.organizers_mobile,
                organizers_address = programMaster.organizers_address,
                if_program_approved = programMaster.if_program_approved,
                approver_name = programMaster.approver_name,
                approver_designation = programMaster.approver_designation,
                approver_datetime = programMaster.approver_datetime,
                program_subject = programMaster.program_subject,
                program_place = programMaster.program_place,
                program_routeinfo = programMaster.program_routeinfo,
                programsensitiveroute_pointsinto = programMaster.programsensitiveroute_pointsinto,
                if_affectlaw_sensitiveroute = programMaster.if_affectlaw_sensitiveroute,
                program_number = programMaster.program_number,
                if_arrestperson = programMaster.if_arrestperson,
              
                program_date = programMaster.program_date,
                remarks = programMaster.remarks
            };
           if(programMaster.dtl_Program_ArrestpersonDto != null )
           {
                postprogram_Master.dtl_Program_Arrestpeople = programMaster.dtl_Program_ArrestpersonDto?.Select( x => new dtl_program_arrestperson
                { 
                  
                    arrestperson_name   = x.arrestperson_name,
                    arrestperson_designation = x.arrestperson_designation,
                    arrestperson_mobile = x.arrestperson_mobile,
                    arrestperson_organizationname=x.arrestperson_organizationname

                }).ToList();
           }

           var result =await _programMasterRepo.PostProgramMaster(postprogram_Master);
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
