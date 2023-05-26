using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PXLApp.CustomModelValidation
{
    public class DatumCheck : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var dtm = DateTime.Now;
            var lst = new List<ModelValidationResult>();
            if (DateTime.TryParse(context.Model?.ToString(), out dtm))
            {
                if (dtm > new DateTime(DateTime.Now.Year, 1, 1))
                    lst.Add(new ModelValidationResult("", "Uitgiftedatum kan niet in de toekomst zijn."));
                else if (dtm < new DateTime(1980, 1, 1))
                    lst.Add(new ModelValidationResult("", "Dit handboek is te verouderd."));
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Geen geldige datum."));
            }
            return lst;
        }
    }
}
