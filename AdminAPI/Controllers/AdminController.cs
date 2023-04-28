using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AdminApi.Models;
using System.Data;
using Npgsql;
using aspnet_core3_webapi.Models;
using System.Linq;

namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminDbContext _context;
        public AdminController(AdminDbContext context)
        {
            _context = context;
        }

        private NpgsqlConnectionStringBuilder makeBuilder()
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            builder.Host = "ec2-3-248-121-12.eu-west-1.compute.amazonaws.com";
            builder.Port = 5432;
            builder.Database = "d7ccpqspfmji5j";
            builder.Username = "uxcyvcschlpcxe";
            builder.Password = "2fcdd6acacdd259b6166122e4456edd440952567b1557729705da8c3290ccb3c";
            builder.Pooling = true;
            builder.SslMode = SslMode.Require;
            builder.TrustServerCertificate = true;
            return builder;

        }

        [HttpGet("candidate")]
        public ActionResult<List<Candidate>> GetCandidates()
        {
            List<Candidate> result = new List<Candidate>();
            try
            {
                NpgsqlConnectionStringBuilder builder = makeBuilder();

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand dCmd = new NpgsqlCommand("SELECT id, name, emailid, phonenumber, adressline1, adressline2, active FROM candidate;", connection))
                    {
                        dCmd.CommandType = CommandType.Text;
                        using (NpgsqlDataReader reader = dCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Candidate c = new Candidate();
                                    c.id = Convert.ToInt32(reader[0]);
                                    c.name = reader[1].ToString();
                                    c.emailId = reader[2].ToString();
                                    c.phonenumber = reader[3].ToString();
                                    c.adressline1 = reader[4].ToString();
                                    c.adressline2 = reader[5].ToString();
                                    c.active = Convert.ToBoolean(reader[6]);
                                    result.Add(c);
                                }
                            }

                        }

                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }

        [HttpGet("FormView")]
        public ActionResult<List<FormView>> FormView()
        {
            List<FormView> result = new List<FormView>();
            try
            {
                NpgsqlConnectionStringBuilder builder = makeBuilder();

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand dCmd = new NpgsqlCommand("SELECT c.id , c.name , c.emailid , c.phonenumber , f.id , f.name , fa.id , (SELECT SUBSTR (f3.action, 1, POSITION (' ' IN f3.action)) FROM formaction f3 WHERE f3.id = fa.id) FROM candidate c INNER JOIN (SELECT MAX(id) AS id, candidateid, formid, MAX(actionon) FROM formaction f2 GROUP BY candidateid, formid) fa ON c.id = fa.candidateid INNER JOIN form f ON fa.formid = f.id WHERE c.active = '1' AND f.active = '1';", connection))
                    {
                        dCmd.CommandType = CommandType.Text;
                        using (NpgsqlDataReader reader = dCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    FormView fv = new FormView();
                                    fv.idCandidate = Convert.ToInt32(reader[0]);
                                    fv.nameCandidate = reader[1].ToString();
                                    fv.emailId = reader[2].ToString();
                                    fv.phonenumber = reader[3].ToString();
                                    fv.formId = Convert.ToInt32(reader[4]);
                                    fv.formName = reader[5].ToString();
                                    fv.formActionId = Convert.ToInt32(reader[6]);
                                    fv.formAction = reader[7].ToString();
                                    result.Add(fv);
                                }
                            }

                        }

                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }


        [HttpPost("delete")]
        public ActionResult<bool> DeleteInForm([FromBody] int[] ids)
        {
            List<bool> result = new List<bool>();
            List<Candidate> resultCandidate = new List<Candidate>();
            try
            {
                NpgsqlConnectionStringBuilder builder = makeBuilder();

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    var str = String.Join(",", ids); 
                    connection.Open();
                    using (NpgsqlCommand dCmd = new NpgsqlCommand("DELETE FROM candidate WHERE id IN (" + str + ")", connection))
                    {

                        dCmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        private DetailCandidate detailCan(int id)
        {
            DetailCandidate result = new DetailCandidate();
            try
            {
                NpgsqlConnectionStringBuilder builder = makeBuilder();

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand dCmd = new NpgsqlCommand(" select c.id, c.name, c.phonenumber , c.emailid from candidate c where c.id = " + id + ";", connection))
                    {
                        dCmd.CommandType = CommandType.Text;
                        using (NpgsqlDataReader reader = dCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    DetailCandidate fv = new DetailCandidate();
                                    fv.idCandidate = Convert.ToInt32(reader[0]);
                                    fv.nameCandidate = reader[1].ToString();
                                    fv.phoneCandidate = reader[2].ToString();
                                    fv.emailCandidate = reader[3].ToString();
                                    result = fv;
                                }
                            }

                        }

                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }

        private List<DetailForm> DetailForm(int id)
        {
            List<DetailForm> result = new List<DetailForm>();
            try
            {
                NpgsqlConnectionStringBuilder builder = makeBuilder();

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand dCmd = new NpgsqlCommand("select f.name, SUBSTR(fa.action ,1, POSITION(' ' IN fa.action)) , fa.actionon  from form f inner join formaction fa on fa.formid = f.id where fa.candidateid  = " + id + " order by  fa.actionon", connection))
                    {
                        dCmd.CommandType = CommandType.Text;
                        using (NpgsqlDataReader reader = dCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    DetailForm fv = new DetailForm();

                                    fv.form = reader[0].ToString();
                                    fv.status = reader[1].ToString();
                                    fv.actionOn = Convert.ToDateTime(reader[2]);

                                    result.Add(fv);
                                }
                            }

                        }

                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }


        private List<DetailAction> DetailAction(int id)
        {
            List<DetailAction> result = new List<DetailAction>();

            try
            {
                NpgsqlConnectionStringBuilder builder = makeBuilder();

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand dCmd = new NpgsqlCommand("select fa.id, fa.action , fa.actionon  from formaction fa inner join candidate c ON c.id  = fa.candidateid where fa.candidateid = " + id + " order by fa.actionon ", connection))
                    {
                        dCmd.CommandType = CommandType.Text;
                        using (NpgsqlDataReader reader = dCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    DetailAction fv = new DetailAction();

                                    fv.idAction = Convert.ToInt32(reader[0]);
                                    fv.action = reader[1].ToString();
                                    fv.actionOn = Convert.ToDateTime(reader[2]);
                                    fv.waitingTime = "0 Days, 0 Hours, 0 Minutes, 0 Seconds";
                                    result.Add(fv);
                                }
                            }

                        }

                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }



        [HttpGet("detailCandidate/{id}")]
        public ActionResult<DetailOfIndividualForms> DetailCandidate(int id)
        {

            DetailOfIndividualForms result = new DetailOfIndividualForms();
            try
            {
                result.detailCandidate = detailCan(id);
                List<DetailForm> formList = DetailForm(id);
                List<DetailAction> listAction = DetailAction(id);


                for (int i = 0; i <= formList.ToArray().Length; i++)
                {
                    if (i + 1 >= 0 && i + 1 < formList.ToArray().Length)
                    {
                        formList[i].waitingTime = (formList[i + 1].actionOn - formList[i].actionOn);
                    }  
                }
                DetailForm dt = new DetailForm();
                dt.form = formList.Last().form;
                dt.status = formList.Last().status;
                TimeSpan span = new TimeSpan(formList.Sum(p => p.waitingTime.Ticks));
                dt.totalWaitingTime = String.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds", span.Days, span.Hours, span.Minutes, span.Seconds);


                result.detailForms = dt;
                for (int i = listAction.ToArray().Length - 1; i > 0; i--)
                {
                    TimeSpan span_action = (listAction[i].actionOn - listAction[i - 1].actionOn);
                    listAction[i].waitingTime = String.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds", span_action.Days, span_action.Hours, span_action.Minutes, span_action.Seconds);
                }
                result.detalAction = listAction;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }
    }
}
