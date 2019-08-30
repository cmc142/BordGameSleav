using Boardgamesleeves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgamesleeves.Areas.Admin.DALAdmin
{
    public interface IVareDepot
    {
        Task<IEnumerable<Vare>> GetVareList();
        Task<Vare> GetVare(string vareid);
        Task<bool> CreateVare(Vare vare);
        Task<bool> EditVare(Vare vare);
        Task<Vare> DeleteVare(string vareid);
        Task<IEnumerable<Stoerrelse>> GetStoerrelsesList();
    }
}
