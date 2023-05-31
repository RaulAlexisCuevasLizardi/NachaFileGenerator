using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;
using System.Text.RegularExpressions;

namespace NachaFileGenerator.Concrete
{
    class Validator: IValidator
    {
        private readonly Regex RouteNumberRx = new Regex(@"^[A-z]\d{9}$");
        private readonly Regex AlphanumericalRx = new Regex(@"^([a-z]|[A-Z]|[0-9])+$");
        private readonly Regex AlphabeticalRx = new Regex(@"^([a-z]|[A-Z])+$");
        private readonly Regex NumericalRx = new Regex(@"^([0-9])+$");
        private readonly Regex DateRx = new Regex(@"^\d\d(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])$");
        private readonly Regex TimeRx = new Regex(@"^([01][0-9]|2[0-4])([0-6][0-9])$");
        private readonly Regex RouteNumberNoChkDigit = new Regex(@"^([a-z]|[A-Z]|[0-9]){8}$");
        public void Validate(IFieldDefinition fieldDefinition, string value)
        {
            bool isRequiredValueEmpty = fieldDefinition.IsRequired() && string.IsNullOrEmpty(value);

            if (isRequiredValueEmpty)
            {
                throw new System.Exception(fieldDefinition.GetFieldName() + " is a required value and cannot be empty.");
            }

            if (fieldDefinition.GetLength() < value.Length)
                throw new System.Exception("Value exceeds field length. " + fieldDefinition.GetFieldName() + " is only " + fieldDefinition.GetLength() + " in size.");

            switch (fieldDefinition.GetFieldType())
            {
                case FieldType.Alphabetic:
                    if (!AlphabeticalRx.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be alphabetical.");
                    break;
                case FieldType.Alphanumeric:
                    if (!AlphanumericalRx.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be alphanumerical.");
                    break;
                case FieldType.Date:
                    if (!DateRx.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be a date in YYMMDD format.");
                    break;
                case FieldType.Numeric:
                    if (!NumericalRx.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be numeric.");
                    break;
                case FieldType.RouteNumber:
                    if(!RouteNumberRx.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be a route number in Bnnnnnnnnn format.");
                    break;
                case FieldType.Time:
                    if(!TimeRx.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be a time in HHMM format.");
                    break;
                case FieldType.Constant:
                    if (value != fieldDefinition.GetDefaultValue())
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must always be a constant value of " + fieldDefinition.GetDefaultValue());
                    break;
                case FieldType.RouteNumberNoChkDigit:
                    if (!RouteNumberNoChkDigit.Match(value).Success)
                        throw new System.Exception(fieldDefinition.GetFieldName() + " must be a routing number without the first character in TTTTAAAA format where T and A are all digits.");
                    break;
            }
        }
    }
}
