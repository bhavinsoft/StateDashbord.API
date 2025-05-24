using Microsoft.Extensions.Logging;
using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class ProgramMasterRepo : IProgramMasterRepo
    {
        private readonly IGenericServices<program_master> _programmaster;
        private readonly IGenericServices<program_masterView> _programmasterview;

        private readonly ILogger<UserMasterRepo> _logger;

        public ProgramMasterRepo(IGenericServices<program_master> programmaster
            ,IGenericServices<program_masterView> programmasterview
            , ILogger<UserMasterRepo> logger)
        {
         _programmaster = programmaster;
            _programmasterview = programmasterview;
            _logger = logger;
        }

        public async Task<Result<List<program_masterView>>> getProgramMasterList(int id, int userid, int userposition, int rollid, DateOnly? from_date, DateOnly? to_date)
        {
            try
            {
                Dictionary<string, object> programMasterdis = new Dictionary<string, object>();

                programMasterdis.Add("id", id);
                programMasterdis.Add("userid", userid);
                programMasterdis.Add("userposition", userposition);
                programMasterdis.Add("rollid", rollid);
                programMasterdis.Add("from_date", from_date?.ToString("yyyy-MM-dd"));
                programMasterdis.Add("to_date", to_date?.ToString("yyyy-MM-dd"));
                var resultlist = await _programmasterview.GetAsync("getprogrammasterlist", programMasterdis);
                return Result<List<program_masterView>>.SuccessResult(resultlist, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<List<program_masterView>>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }

        public async Task<Result<int>> PostProgramMaster(program_master programMaster)
        {
            Dictionary<string, object> program_master = new Dictionary<string, object>();
            program_master.Add("id", programMaster.recid);
            program_master.Add("districtid", programMaster.districtid);
            program_master.Add("policestationid", programMaster.policestationid);
            program_master.Add("categoryid", programMaster.categoryid);
            program_master.Add("programdetails", programMaster.programdetails);
            program_master.Add("organizers_name", programMaster.organizers_name);
            program_master.Add("organizers_designation", programMaster.organizers_designation);
            program_master.Add("organizers_organizationname", programMaster.organizers_organizationname);
            program_master.Add("organizers_mobile", programMaster.organizers_mobile);
            program_master.Add("organizers_address", programMaster.organizers_address);
            program_master.Add("if_program_approved", programMaster.if_program_approved);
            program_master.Add("approver_name", programMaster.approver_name);
            program_master.Add("approver_designation", programMaster.approver_designation);
            program_master.Add("approver_datetime", programMaster.approver_datetime);
            program_master.Add("program_subject", programMaster.program_subject);
            program_master.Add("program_place", programMaster.program_place);
            program_master.Add("program_routeinfo", programMaster.program_routeinfo);
            program_master.Add("programsensitiveroute_pointsinto", programMaster.programsensitiveroute_pointsinto);
            program_master.Add("if_affectlaw_sensitiveroute", programMaster.if_affectlaw_sensitiveroute);
            program_master.Add("program_number", programMaster.program_number);
            program_master.Add("if_arrestperson", programMaster.if_arrestperson);
            program_master.Add("arrestperson_name", programMaster.arrestperson_name);
            program_master.Add("arrestperson_designation", programMaster.arrestperson_designation);
            program_master.Add("arrestperson_organizationname", programMaster.arrestperson_organizationname);
            program_master.Add("arrestperson_mobile", programMaster.arrestperson_mobile);
            program_master.Add("program_date", programMaster.program_date);
            program_master.Add("remarks", programMaster.remarks);


            var result = await _programmaster.Add(program_master, "InsertProgramMaster");
            if (result > 0)
            {
                return Result<int>.SuccessResult(result, $"Data Save Successfully", 1);

            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);

            }


        }
    }
}
