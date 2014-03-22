using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcFinalAssignment.Models;


namespace MvcFinalAssignment.Controllers
{
    public class CAEmployeeController : Controller
    {
        //
        // GET: /CAEmployee/

       public ActionResult Index()
        {
            CommunityAssistEntities cae = new CommunityAssistEntities();
            var employees = from e in cae.EmployeeJobTitles
                            orderby e.Employee.Person.PersonLastName
                            select new
                            {
                                e.Employee.Person.PersonLastName,
                                e.Employee.Person.PersonFirstName,
                                e.Employee.Person.PersonUsername,
                                e.Employee.EmployeeHireDate,
                                e.Jobtitle.JobTitleName,
                                e.Employee.EmployeeStatus
                            };
            List<CAEmployee> employeeList = new List<CAEmployee>();
            foreach (var x in employees)
            {
                CAEmployee emp = new CAEmployee();
                emp.LastName = x.PersonLastName;
                emp.FirstName = x.PersonFirstName;
                emp.Email = x.PersonUsername;
                emp.HireDate = x.EmployeeHireDate.ToString();
                emp.JobTitle = x.JobTitleName;
                emp.Status = x.EmployeeStatus;
                employeeList.Add(emp);
                
            }
            return View(employeeList);
        }

    }


    
}
