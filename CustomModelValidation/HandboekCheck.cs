using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PXLApp.Models;
using System.Collections.Generic;

namespace PXLApp.CustomModelValidation
{
    public class HandboekCheck : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var lst = new List<ModelValidationResult>();
            var model = context.Model as Handboek;

            if (model != null/* && model.HandboekenLijst.Count == 0*/)
            {
                lst.Add(new ModelValidationResult("", "Er moet minstens 1 handboek bestaan."));
            }

            return lst;
        }

    }
}
