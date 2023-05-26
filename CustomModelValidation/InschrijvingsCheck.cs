using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PXLApp.Models;

namespace PXLApp.CustomModelValidation
{
    public class InschrijvingsCheck : Attribute, IModelValidator
    {
      
            public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
            {
                var lst = new List<ModelValidationResult>();
                var model1 = context.Model as Student;
                var model2 = context.Model as Vak;

                if (model1 != null && model2 != null)
                {
                    lst.Add(new ModelValidationResult("", "Er moeten zowel minstens 1 vak als 1 student bestaan"));
                }

                return lst;
            }

        
    }
}
