using DnDWorld.BLL.Repositories;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class ClassController : Controller
    {
        ClassRepo cr = new ClassRepo();
        public JsonResult GetClasses()
        {
            List<Class> classes = cr.GetClasses();
            List<Class> classDTO = new List<Class>();
            if (classes != null)
            {
                foreach (Class c in classes)
                {
                    classDTO.Add(new Class()
                    {
                        Fullname = c.Fullname,
                        PicturePath = c.PicturePath,
                        ClassID = c.ClassID,
                        Description = c.Description,
                        CharacterClasses = null
                    });
                }
            }
            return Json(classDTO, JsonRequestBehavior.AllowGet);
        }
    }
}