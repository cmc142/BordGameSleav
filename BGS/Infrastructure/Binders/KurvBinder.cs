using Boardgamesleeves.DAL;
using Boardgamesleeves.Models;
using Boardgamesleeves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.Infrastructure.Binders
{
    public class KurvBinder:IModelBinder
    {
        private const string sessionKey = "Kurv";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Kurv kurv = null;

            if (controllerContext.HttpContext.Session != null)
            {
                kurv = (Kurv)controllerContext.HttpContext.Session[sessionKey];
            }

            if (kurv == null)
            {
                kurv = new Kurv();
               
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = kurv;
                }
            }
            
            
            return kurv;
        }
    }
}