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
        private readonly IGenericServices<dtl_program_arrestperson> _dtlprogramarrestperson;
        private readonly IGenericServices<program_masterView> _programmasterview;
        private readonly IGenericServices<after_program_master> _afterprogrammaster;
        private readonly IGenericServices<dtl_program_suspension> _dtlprogramsuspension;
        private readonly IGenericServices<dtl_program_notcaught_suspension> _dtlprogramnotcaughtsuspension;
        private readonly IGenericServices<afterprogrammasterview> _afterprogrammasterview;


        private readonly ILogger<UserMasterRepo> _logger;

        public ProgramMasterRepo(IGenericServices<program_master> programmaster
            ,IGenericServices<program_masterView> programmasterview
            , IGenericServices<dtl_program_arrestperson> dtlprogramarrestperson
            , IGenericServices<after_program_master> afterprogrammaster
            , IGenericServices<dtl_program_suspension> dtlprogramsuspension
            , IGenericServices<dtl_program_notcaught_suspension> dtlprogramnotcaughtsuspension
            , IGenericServices<afterprogrammasterview> afterprogrammasterview
            , ILogger<UserMasterRepo> logger)
        {
         _programmaster = programmaster;
            _programmasterview = programmasterview;
            _dtlprogramarrestperson = dtlprogramarrestperson;
            _afterprogrammaster = afterprogrammaster;
            _dtlprogramsuspension = dtlprogramsuspension;
            _dtlprogramnotcaughtsuspension = dtlprogramnotcaughtsuspension;
            _afterprogrammasterview = afterprogrammasterview;
            _logger = logger;
        }

        public async Task<Result<afterprogrammasterview>> getafterProgramMasterById(int id, int userid, int userposition, int rollid)
        {
            try
            {
                Dictionary<string, object> programMasterdis = new Dictionary<string, object>();

                programMasterdis.Add("id", id);
                programMasterdis.Add("userid", userid);
                programMasterdis.Add("userposition", userposition);
                programMasterdis.Add("rollid", rollid);
                var resultlist = await _afterprogrammasterview.GetFirstOrDefaultAsync("getafterprogrammasterprogid", programMasterdis);
                if (resultlist != null)
                {
                    Dictionary<string, object> dtlpdis = new Dictionary<string, object>();
                    dtlpdis.Add("id", id);
                    resultlist.dtlprogramsuspension = await _dtlprogramsuspension.GetAsync("getdtlprogramsuspensionprogid", dtlpdis);
                    resultlist.dtlprogramnotcaughtsuspension = await _dtlprogramnotcaughtsuspension.GetAsync("getddtlprogramnotcaughtsuspensionprogid", dtlpdis);
                }

                return Result<afterprogrammasterview>.SuccessResult(resultlist, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<afterprogrammasterview>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
        }

        public async Task<Result<program_masterView>> getProgramMasterById(int id, int userid, int userposition, int rollid)
        {
            try
            {
                Dictionary<string, object> programMasterdis = new Dictionary<string, object>();

                programMasterdis.Add("id", id);
                programMasterdis.Add("userid", userid);
                programMasterdis.Add("userposition", userposition);
                programMasterdis.Add("rollid", rollid);
                var resultlist = await _programmasterview.GetFirstOrDefaultAsync("getprogrammasterById", programMasterdis);
                if(resultlist != null)
                {
                    Dictionary<string, object> dtlpdis = new Dictionary<string, object>();
                    dtlpdis.Add("id", id);
                    resultlist.dtl_Program_Arrestpeople = await _dtlprogramarrestperson.GetAsync("Getdtlprogramarrestperson", dtlpdis);
                }

                return Result<program_masterView>.SuccessResult(resultlist, "fechdata succesfull", 1);
            }
            catch (Exception ex)
            {

                return Result<program_masterView>.FailureResult($"An error occurred: {ex.Message}", 0);
            }
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

        public async Task<Result<int>> PostAfterProgramMaster(postafterprogrammaster postafterprogrammaster)
        {
            Dictionary<string, object> program_master = new Dictionary<string, object>();
            program_master.Add("id", postafterprogrammaster.afterprogrammaster.recid);
            program_master.Add("progid", postafterprogrammaster.afterprogrammaster.progid);
            program_master.Add("ifprogramapproved", postafterprogrammaster.afterprogrammaster.ifprogramapproved);
            program_master.Add("programapprovedinfo", postafterprogrammaster.afterprogrammaster.programapprovedinfo);
            program_master.Add("peoplecount", postafterprogrammaster.afterprogrammaster.peoplecount);
            program_master.Add("ifprobleminprogram", postafterprogrammaster.afterprogrammaster.ifprobleminprogram);
            program_master.Add("probleminprograminfo", postafterprogrammaster.afterprogrammaster.probleminprograminfo);
            program_master.Add("peoplecomeprogramprogram", postafterprogrammaster.afterprogrammaster.peoplecomeprogramprogram);
            program_master.Add("peoplecomeprogramprograminfo", postafterprogrammaster.afterprogrammaster.peoplecomeprogramprograminfo);
            program_master.Add("ifanyprecautionstaken", postafterprogrammaster.afterprogrammaster.ifanyprecautionstaken);
            program_master.Add("precautionstakeninfo", postafterprogrammaster.afterprogrammaster.precautionstakeninfo);
            program_master.Add("ifcomplaintbeenfiled", postafterprogrammaster.afterprogrammaster.ifcomplaintbeenfiled);
            program_master.Add("complaintbeenfileinfo", postafterprogrammaster.afterprogrammaster.complaintbeenfileinfo);
            program_master.Add("ifthereanysuspension", postafterprogrammaster.afterprogrammaster.ifthereanysuspension);
            program_master.Add("ifanysuspectsyettobecaught", postafterprogrammaster.afterprogrammaster.ifanysuspectsyettobecaught);
            var result = await _afterprogrammaster.Add(program_master, "InsertAfterProgramMaster");

            if (result > 0)
            {

                if (postafterprogrammaster.dtlprogramsuspension != null)
                {
                    foreach (var dtl_Program in postafterprogrammaster.dtlprogramsuspension)
                    {
                        Dictionary<string, object> dtl_Program_dic = new Dictionary<string, object>();
                        dtl_Program_dic.Add("dtlproid", result);
                        dtl_Program_dic.Add("p_name", dtl_Program.p_name);
                        dtl_Program_dic.Add("p_number", dtl_Program.p_number);
                        dtl_Program_dic.Add("p_adress", dtl_Program.p_adress);
                       
                        await _dtlprogramsuspension.Add(dtl_Program_dic, "Insertdtlprogramsuspension");
                    }
                }
                if (postafterprogrammaster.dtlprogramnotcaughtsuspension != null)
                {
                    foreach (var dtl_Program in postafterprogrammaster.dtlprogramnotcaughtsuspension)
                    {
                        Dictionary<string, object> dtl_Program_dic = new Dictionary<string, object>();
                        dtl_Program_dic.Add("dtlproid", result);
                        dtl_Program_dic.Add("p_name", dtl_Program.p_name);
                        dtl_Program_dic.Add("p_number", dtl_Program.p_number);
                        dtl_Program_dic.Add("p_adress", dtl_Program.p_adress);

                        await _dtlprogramnotcaughtsuspension.Add(dtl_Program_dic, "Insertdtlprogramnotcaughtsuspension");
                    }
                }

                return Result<int>.SuccessResult(result, $"Data Save Successfully", 1);

            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);

            }
        }

        public async Task<Result<int>> PostProgramMaster(Postprogram_master programMaster)
        {
            Dictionary<string, object> program_master = new Dictionary<string, object>();
            program_master.Add("id", programMaster.program_Master.recid);
            program_master.Add("districtid", programMaster.program_Master.districtid);
            program_master.Add("policestationid", programMaster.program_Master.policestationid);
            program_master.Add("categoryid", programMaster.program_Master.categoryid);
            program_master.Add("programdetails", programMaster.program_Master.programdetails);
            program_master.Add("organizers_name", programMaster.program_Master.organizers_name);
            program_master.Add("organizers_designation", programMaster.program_Master.organizers_designation);
            program_master.Add("organizers_organizationname", programMaster.program_Master.organizers_organizationname);
            program_master.Add("organizers_mobile", programMaster.program_Master.organizers_mobile);
            program_master.Add("organizers_address", programMaster.program_Master.organizers_address);
            program_master.Add("if_program_approved", programMaster.program_Master.if_program_approved);
            program_master.Add("approver_name", programMaster.program_Master.approver_name);
            program_master.Add("approver_designation", programMaster.program_Master.approver_designation);
            program_master.Add("approver_datetime", programMaster.program_Master.approver_datetime);
            program_master.Add("program_subject", programMaster.program_Master.program_subject);
            program_master.Add("program_place", programMaster.program_Master.program_place);
            program_master.Add("program_routeinfo", programMaster.program_Master.program_routeinfo);
            program_master.Add("programsensitiveroute_pointsinto", programMaster.program_Master.programsensitiveroute_pointsinto);
            program_master.Add("if_affectlaw_sensitiveroute", programMaster.program_Master.if_affectlaw_sensitiveroute);
            program_master.Add("program_number", programMaster.program_Master.program_number);
            program_master.Add("if_arrestperson", programMaster.program_Master.if_arrestperson);
           
            program_master.Add("program_date", programMaster.program_Master.program_date);
            program_master.Add("remarks", programMaster.program_Master.remarks);


            var result = await _programmaster.Add(program_master, "InsertProgramMaster");




            if (result > 0)
            {

                if (programMaster.dtl_Program_Arrestpeople != null)
                {
                    foreach (var dtl_Program in programMaster.dtl_Program_Arrestpeople)
                    {
                        Dictionary<string, object> dtl_Program_dic = new Dictionary<string, object>();
                        dtl_Program_dic.Add("programid", result);
                        dtl_Program_dic.Add("arrestperson_name", dtl_Program.arrestperson_name);
                        dtl_Program_dic.Add("arrestperson_designation", dtl_Program.arrestperson_designation);
                        dtl_Program_dic.Add("arrestperson_organizationname", dtl_Program.arrestperson_organizationname);
                        dtl_Program_dic.Add("arrestperson_mobile", dtl_Program.arrestperson_mobile);
                        await _dtlprogramarrestperson.Add(dtl_Program_dic, "InsertDtlprogramarrestperson");
                    }
                }


                return Result<int>.SuccessResult(result, $"Data Save Successfully", 1);

            }
            else
            {
                return Result<int>.FailureResult($"An error occurred: Data Not Save", 0);

            }


        }
    }
}
