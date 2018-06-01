using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeMau.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserDao dao = new UserDao();
            var model = dao.ListUser().ToList();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            UserDao dao = new UserDao();
            var result = dao.ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var model = dao.Create(user);
                if (model > 0)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Không thêm được user");
            }
            return View();

        }
        public ActionResult Edit(int id)
        {
            UserDao dao = new UserDao();
            var model = dao.GetUserByID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var model = dao.Edit(user);
                if (model)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Không sửa được user");
            }
            return View();
        }
    }
}