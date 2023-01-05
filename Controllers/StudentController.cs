using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Data;
using MVCPostgres.Models;

namespace MVCPostgres.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<StudentModel> displaystudent = new List<StudentModel>();
            NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; Port = 5432; Database = firstdemodb; User Id = postgres;Password = postgres");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from student";

            NpgsqlDataReader sdr = comm.ExecuteReader();
            while(sdr.Read())
            {
                var stlist = new StudentModel();
                stlist.studid = Convert.ToInt32(sdr["studid"]);
                stlist.studname = sdr["studname"].ToString();
                stlist.emailid = sdr["emailid"].ToString();
                displaystudent.Add(stlist);
            }
            return View(displaystudent);
        }
    }
}