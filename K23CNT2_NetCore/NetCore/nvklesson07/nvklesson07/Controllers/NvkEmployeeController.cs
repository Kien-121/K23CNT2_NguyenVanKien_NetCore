using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nvklesson07.Models;

namespace nvklesson07.Controllers
{
    public class NvkEmployeeController : Controller
    {
        // Mock Data
        private static List<NvkEmployee> nvkListEmployee = new List<NvkEmployee>()
        {
            new NvkEmployee
            {
                NvkId = 1,
                NvkName = "Nguyễn Văn Kiên ",
                NvkBirthDay = new DateTime(2005 , 1, 12),
                NvkEmail = "kiennguyen@example.com",
                NvkPhone = "0901234567",
                NvkSalary = 15000000,
                NvkStatus = true
            },
            new NvkEmployee
            {
                NvkId = 2,
                NvkName = "Trần Thị Bình",
                NvkBirthDay = new DateTime(1988, 8, 22),
                NvkEmail = "binh.tran@example.com",
                NvkPhone = "0912345678",
                NvkSalary = 18000000,
                NvkStatus = true
            },
            new NvkEmployee
            {
                NvkId = 3,
                NvkName = "Lê Văn Cường",
                NvkBirthDay = new DateTime(1995, 3, 5),
                NvkEmail = "cuong.le@example.com",
                NvkPhone = "0923456789",
                NvkSalary = 12000000,
                NvkStatus = false
            },
            new NvkEmployee
            {
                NvkId = 4,
                NvkName = "Phạm Thị Dung",
                NvkBirthDay = new DateTime(1992, 11, 30),
                NvkEmail = "dung.pham@example.com",
                NvkPhone = "0934567890",
                NvkSalary = 20000000,
                NvkStatus = true
            },
            new NvkEmployee
            {
                NvkId = 5,
                NvkName = "Hoàng Văn Em",
                NvkBirthDay = new DateTime(1985, 1, 17),
                NvkEmail = "em.hoang@example.com",
                NvkPhone = "0945678901",
                NvkSalary = 17000000,
                NvkStatus = false
            }
        };
        // GET: NvkEmployeeController
        public ActionResult NvkIndex()
        {
            return View(nvkListEmployee);
        }

        // GET: NvkEmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NvkEmployeeController/NvkCreate
        public ActionResult NvkCreate()
        {
            var nvkEmployee = new NvkEmployee();
            return View();
        }

        // POST: NvkEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkCreate(NvkEmployee nvkModel)
        {
            try
            {
                nvkModel.NvkId = nvkListEmployee.Max(e => e.NvkId) + 1;
                nvkListEmployee.Add(nvkModel);
                return RedirectToAction("NvkIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkEmployeeController/Edit/5
        public ActionResult NvkEdit(int id)
        {
            var nvkEmployee = nvkListEmployee.FirstOrDefault(e => e.NvkId == id);
            return View(nvkEmployee);
        }

        // POST: NvkEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvkEdit(int id, NvkEmployee nvkModel)
        {
            try
            {
                for (int i = 0; i < nvkListEmployee.Count; i++)
                {
                    if (nvkListEmployee[i].NvkId == id)
                    {
                        nvkListEmployee[i] = nvkModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NvkEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
