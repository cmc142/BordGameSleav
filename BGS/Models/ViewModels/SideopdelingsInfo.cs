using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.Models.ViewModels 
{
    public class SideopdelingsInfo
    {
        // auto-implementerede properties
        public int TotaleElementer
        {
            get;
            set;
        }

        public int ElementerPerSide
        {
            get;
            set;
        }

        public int NuvaerendeSide
        {
            get;
            set;
        }

        // property der returnere antal sider der er tilgængelige, den nuværende side og totale antal af produkter i repository
        public int TotaleSider
        {
            get { return (int)Math.Ceiling((decimal)TotaleElementer / ElementerPerSide ); }
        }

    }
}