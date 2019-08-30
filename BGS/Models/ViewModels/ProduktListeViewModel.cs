using Boardgamesleeves.Models;
using Boardgamesleeves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.Models.ViewModels
{
    public class ProduktListeViewModel
    {
        // auto-implemented properties
        public IEnumerable<Vare> Varer
        {
            get;
            set; 
        }


        public SideopdelingsInfo SideopdelingsInfo
        {
            get;
            set;
        }

        public string NuvaerendeKategori
        {
            get;
            set;
        }
    }
}