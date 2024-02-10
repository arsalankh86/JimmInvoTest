using System.ComponentModel.DataAnnotations;

namespace JimmInvoTest.Utility
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}
