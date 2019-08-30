using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.Models.ViewModels
{
    public class KurvVisModel
    {
        public Kurv Kurv
        {
            get;
            set;
        }
        public string ReturnUrl
        {
            get;
            set;
        }
        public int[] KoebsAntal
        {
            get;
            set;
        }

        public List<SelectListItem> ViewListe(int valgt)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            foreach (int i in KoebsAntal)
            {   
                SelectListItem item = new SelectListItem { 
                    Value = i.ToString(),
                    Text = i.ToString() };

                if (i == valgt) { item.Selected = true; }

                result.Add(item);
            }

            if (result != null)
            {
                SelectListItem item = result.Where(x=> x.Value == valgt.ToString()).FirstOrDefault() ?? new SelectListItem();
                item.Selected = true;
            }

            return result;
        }
    }
}