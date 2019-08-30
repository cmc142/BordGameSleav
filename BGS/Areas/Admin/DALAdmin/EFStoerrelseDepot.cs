using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Boardgamesleeves.Models;
using Boardgamesleeves.DAL;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Boardgamesleeves.Areas.Admin.DALAdmin
{
    public class EFStoerrelseDepot : IStoerrelsesDepot
    {
        BGSModel db = new BGSModel();

        public async Task<IEnumerable<Stoerrelse>> GetStoerrelse()
        {
            return await db.Stoerrelse.ToListAsync() ?? new List<Stoerrelse>();
        }

        public async Task<Stoerrelse> GetStoerrelse(int stoerrelseid)
        {
            return await db.Stoerrelse.FindAsync(stoerrelseid);
        }
       
        public async Task<bool> SaveStoerrelse(Stoerrelse stoerrelse)
        {
            bool result = false;
            try
            {
                if (stoerrelse.Stoerrelseid == 0)
                {
                    db.Stoerrelse.Add(stoerrelse);
                }
                else
                {
                    db.Entry(stoerrelse).State = EntityState.Modified;
                }

               await db.SaveChangesAsync();
               result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en fejl under oprettelsen af varen. - Prøv igen senere. <br/>Fejlinfo: " + ex.Message);
           }

            return result;
        }


        public async Task<Stoerrelse> DeleteStoerrelse(int stoerrelseid)
        {
            try
            {
                Stoerrelse stoerrelse = await GetStoerrelse(stoerrelseid);
                db.Stoerrelse.Remove(stoerrelse);
                await db.SaveChangesAsync();
                return stoerrelse;
            }
            catch (Exception ex)
            {
                throw new Exception("Sletningen kun ikke gennemføres. - Prøv igen senere. <br/>Fejlinfo: " + ex.Message);
            }

        }
    }
}