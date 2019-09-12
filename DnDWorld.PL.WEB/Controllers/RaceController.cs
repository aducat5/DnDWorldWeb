using DnDWorld.BLL.Repositories;
using DnDWorld.BLL.Utility;
using DnDWorld.BSL.Authorization;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDWorld.PL.WEB.Controllers
{
    public class RaceController : Controller
    {
        RaceRepo rr = new RaceRepo();
        
        public JsonResult GetRaces()
        {
            List<Race> races = rr.GetRaces();
            List<Race> raceDTO = new List<Race>();
            if (races != null)
            {
                foreach (Race race in races)
                {
                    raceDTO.Add(new Race()
                    {
                        Fullname = race.Fullname,
                        PicturePath = race.PicturePath,
                        RaceID = race.RaceID
                    });
                }
            }
            return Json(raceDTO, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubraces(string raceID)
        {
            List<Subrace> subraces = rr.GetSubraces(raceID.ToInt());
            List<Subrace> subraceDTO = new List<Subrace>();
            if (subraces != null)
            {
                foreach (Subrace subrace in subraces)
                {
                    subraceDTO.Add(new Subrace()
                    {
                        Fullname = subrace.Fullname,
                        PicturePath = subrace.PicturePath,
                        SubraceID = subrace.SubraceID,
                        Description = subrace.Description
                    });
                }
            }
            return Json(subraceDTO, JsonRequestBehavior.AllowGet);
        }
    }
}