using DnDWorld.BLL.Utility;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDWorld.BLL.Repositories
{
    public class CampaignRepo
    {
        DNDWDBEntities db = DBTools.DBInstance;
        public bool DoesCampaignExists(string charName, int userID)
        {
            return db.Campaigns.Any(c => c.Fullname == charName && c.OwnerID == userID);
        }

        public bool InsertCampaign(Campaign newCamp, out string islemSonucu)
        {
            newCamp.Fullname = newCamp.Fullname.ClearText();
            newCamp.IsDeleted = false;
            newCamp.IsOpen = false;
            if (!DoesCampaignExists(newCamp.Fullname, newCamp.OwnerID))
            {
                db.Campaigns.Add(newCamp);
                if (db.SaveChanges() > 0)
                {
                    islemSonucu = "Başarılı";
                    return true;
                }
                else
                {
                    islemSonucu = "Bir hata oluştu";
                    return false;
                }
            }
            else
            {
                islemSonucu = "Böyle bir maceraya zaten sahipsin";
                return false;
            }
        }
    }
}
