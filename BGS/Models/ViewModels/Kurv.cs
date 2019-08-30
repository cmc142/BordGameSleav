using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.Models.ViewModels
{
    public class Kurv
    {
        List<KurvVare> _KurvVareList = new List<KurvVare>();
   
        public decimal TotalPris
        {
            get { return _KurvVareList.Sum(e => e.Vare.Pris * e.Antal); }
        }

        public List<KurvVare> KurvVareList { get { return _KurvVareList; } }


        public Kurv() { }
        
        public void AddVare(Vare vare, int antal)
        {
            KurvVare kurvVare = _KurvVareList.Where(p => p.Vare.Vareid == vare.Vareid)
                                                      .FirstOrDefault();
            if (kurvVare == null)
            {
                _KurvVareList.Add(new KurvVare
                {
                    Vare = vare,
                    Antal = antal
                });
            }
            else
            {
                if (kurvVare.Antal + antal >= 10)
                {
                    kurvVare.Antal = 10;
                }
                else
                {
                    kurvVare.Antal += antal;
                }
            }
        }

        public void RemoveVare(Vare vare)
        {
            _KurvVareList.RemoveAll(i => i.Vare.Vareid == vare.Vareid);
        }

        public void Clear()
        {
            _KurvVareList.Clear();
        }
    }
}