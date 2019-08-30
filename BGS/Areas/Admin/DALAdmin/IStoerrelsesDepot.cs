using Boardgamesleeves.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgamesleeves.Areas.Admin.DALAdmin
{
    public interface IStoerrelsesDepot
    {
        Task<IEnumerable<Stoerrelse>> GetStoerrelse();
        Task<Stoerrelse> GetStoerrelse(int stoerrelseid);
        Task<bool> SaveStoerrelse(Stoerrelse stoerrelse);
        Task<Stoerrelse> DeleteStoerrelse(int stoerrelseid);
    }
}
