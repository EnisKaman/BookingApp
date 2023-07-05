namespace BookingSystem.Custom_Validations
{
    using System.ComponentModel.DataAnnotations;
    public class IsBefore : ValidationAttribute
    {
        public IsBefore(DateTime date)
        {
            this.Date = date;
        }
        public DateTime Date { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (this.Date >= (DateTime)value)
            {
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
