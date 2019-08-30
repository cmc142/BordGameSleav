using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.Models.ViewModels
{
    public class ProduktVisModel
    {
        public Vare vare 
        { 
            get; 
            set; 
        }

        public int[] KoebsAntal
        {
            get;
            set;
        }

        public int ValgtKoebsAntal
        {
            get;
            set;
        }
    }
}