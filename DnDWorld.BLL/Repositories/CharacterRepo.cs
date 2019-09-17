using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDWorld.BLL.Utility;
using DnDWorld.DAL;
namespace DnDWorld.BLL.Repositories
{
    public class CharacterRepo
    {
        DNDWDBEntities db = DBTools.DBInstance;
        
        public bool DoesCharacterExists(string charName, int userID)
        {
            return db.Characters.Any(c => c.Fullname == charName && c.OwnerID == userID);
        }

        public bool AddClassToCharacter(int classID, int charID)
        {
            if (!db.CharacterClasses.Any(c => c.CharacterID == charID && c.ClassID == classID))
            {
                CharacterClass characterClass = new CharacterClass()
                {
                    CharacterID = charID,
                    ClassID = classID
                };

                db.CharacterClasses.Add(characterClass);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool InsertCharacter(Character newCharacter, out string islemSonucu)
        {
            newCharacter.Fullname = newCharacter.Fullname.ClearText();
            if (!DoesCharacterExists(newCharacter.Fullname, newCharacter.OwnerID))
            {
                db.Characters.Add(newCharacter);
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
                islemSonucu = "Böyle bir karaktere zaten sahipsin";
                return false;
            }
        }
    }
}
