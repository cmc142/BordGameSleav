using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BGS.Infrastructure.Validering
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class TjekForTegnAttribute : ValidationAttribute, IClientValidatable
    {

        public TjekForTegnAttribute()
        {        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "tjekfortegn",
                ErrorMessage =  "Tegnene <>%, må ikke indgå i emnet."
            };
            
            return new List<ModelClientValidationRule> { modelClientValidationRule };

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult res = null;
            string msg = "";

            if (value != null)
            {                
                    string pattern = @"^[^<>%]*$";
                    Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
                 
                    if (check.IsMatch(value.ToString()))
                    {
                        msg = "ok";
                    }
                    else
                    {
                        msg = "Tegnene <>%, må ikke indgå i emnet.";
                    }                
            }
            else
            {
                msg = "Mangler tekst at tjekke.";
            }

            if (msg.Equals("ok"))
            {
                res = ValidationResult.Success;
            }
            else
            {
                res = new ValidationResult(msg);
            }

            return res;

        }
    }
}