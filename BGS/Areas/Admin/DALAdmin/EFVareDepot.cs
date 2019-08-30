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
    public class EFVareDepot : IVareDepot
    {
        BGSModel db = new BGSModel();

        public async Task<IEnumerable<Vare>> GetVareList()
        {
            return await db.Vare.ToListAsync() ?? new List<Vare>();
        }

        public async Task<Vare> GetVare(string vareid)
        {
            return await db.Vare.FindAsync(vareid);
        }

        public async Task<bool> CreateVare(Vare vare)
        {
            bool result = false;
            try
            {
                if (await GetVare(vare.Vareid ??"") == null)
                {
                    vare.Oprettelsesdato = DateTime.Now;
                    db.Vare.Add(vare);
                    await db.SaveChangesAsync();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Der opstod en fejl under oprettelsen af varen. - Prøv igen senere. <br/>Fejlinfo: "+ ex.Message);
            }

            return result;
        }

        public async Task<bool> EditVare(Vare vare)
        {
            bool result = false;
            try
            {
                if (await GetVare(vare.Vareid ?? "") != null)
                {
                   string SQL = "UPDATE dbo.Vare SET Titel = {0}, Pris = {1}, Kategori = {2}, Beskrivelse = {3}, Billedsti = {4}, LagerAntal = {5}, STK = {6}, Stoerrelseid = {7} WHERE Vareid = {8}";

                   
                   int aedret = await db.Database.ExecuteSqlCommandAsync(SQL, vare.Titel, vare.Pris, vare.Kategori, vare.Beskrivelse, vare.Billedsti, vare.LagerAntal, vare.STK, vare.Stoerrelseid, vare.Vareid);

                   if (aedret > 0)
                   {
                       result = true;
                   }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en fejl under rettelsen af varen. - Prøv igen senere. <br/>Fejlinfo: " + ex.Message);
            }

            return result;
        }


        public async Task<Vare> DeleteVare(string vareid)
        {
            try
            {
                Vare vare = await GetVare(vareid);
                db.Vare.Remove(vare);
                await db.SaveChangesAsync();
                return vare;
            }
            catch (Exception ex)
            {
                throw new Exception("Sletningen kun ikke gennemføres. - Prøv igen senere. <br/>Fejlinfo: " + ex.Message);
            }
        }


        public async Task<IEnumerable<Stoerrelse>> GetStoerrelsesList()
        {
            return await db.Stoerrelse.ToListAsync() ?? new List<Stoerrelse>();
        }
    }
}