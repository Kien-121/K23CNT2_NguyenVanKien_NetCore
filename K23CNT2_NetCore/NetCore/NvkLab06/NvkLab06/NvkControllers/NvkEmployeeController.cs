using Microsoft.AspNetCore.Mvc;
using NvkLab06.Models;

namespace NhtLab06.NhtControllers
{
    public class NvkEmployeeController : Controller
    {
        static List<NvkEmployee> nvkListEmployee = new List<NvkEmployee>()
        {
            new NvkEmployee{ NvkId=1, NvkName="Nguyễn Văn Kiên ", NvkBirthDay=new DateTime(2005,1,1), NvkEmail="kien@example.com", NvkPhone="0123456789", NvkSalary=1000, NvkStatus=true },
            new NvkEmployee{ NvkId=2, NvkName="Trần Văn A", NvkBirthDay=new DateTime(1995,5,1), NvkEmail="a@example.com", NvkPhone="0123456788", NvkSalary=2000, NvkStatus=true },
            new NvkEmployee{ NvkId=3, NvkName="Lê Thị B", NvkBirthDay=new DateTime(1998,4,4), NvkEmail="b@example.com", NvkPhone="0123456787", NvkSalary=1500, NvkStatus=false },
            new NvkEmployee{ NvkId=4, NvkName="Ngô Văn C", NvkBirthDay=new DateTime(1990,3,3), NvkEmail="c@example.com", NvkPhone="0123456786", NvkSalary=3000, NvkStatus=true },
            new NvkEmployee{ NvkId=5, NvkName="Phạm Thị D", NvkBirthDay=new DateTime(1993,2,2), NvkEmail="d@example.com", NvkPhone="0123456785", NvkSalary=2500, NvkStatus=false }
        };

        public ActionResult NvkIndex()
        {
            return View(nvkListEmployee);
        }

        [HttpGet]
        public ActionResult NvkCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NvkCreateSubmit(NvkEmployee emp)
        {
            emp.NvkId = nvkListEmployee.Max(e => e.NvkId) + 1;
            nvkListEmployee.Add(emp);
            return RedirectToAction("NvkIndex");
        }

        [HttpGet]
        public ActionResult NvkEdit(int id)
        {
            var emp = nvkListEmployee.FirstOrDefault(e => e.NvkId == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult NvkEditPUT(NvkEmployee emp)
        {
            var old = nvkListEmployee.FirstOrDefault(e => e.NvkId == emp.NvkId);
            if (old != null)
            {
                old.NvkName = emp.NvkName;
                old.NvkBirthDay = emp.NvkBirthDay;
                old.NvkEmail = emp.NvkEmail;
                old.NvkPhone = emp.NvkPhone;
                old.NvkSalary = emp.NvkSalary;
                old.NvkStatus = emp.NvkStatus;
            }
            return RedirectToAction("NvkIndex");
        }

        public ActionResult NvkDelete(int id)
        {
            var emp = nvkListEmployee.FirstOrDefault(e => e.NvkId == id);
            if (emp != null) nvkListEmployee.Remove(emp);
            return RedirectToAction("NvkIndex");
        }
    }
}

