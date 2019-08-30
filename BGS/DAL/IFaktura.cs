using Boardgamesleeves.Models;
using Boardgamesleeves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.DAL
{
    public interface IFakturaDepot
    {
        Vare GetVare(string vareid);
        bool SaveFaktura(Kurv kurv, TjekUdViewModel tjekUdViewModel);
    }
}