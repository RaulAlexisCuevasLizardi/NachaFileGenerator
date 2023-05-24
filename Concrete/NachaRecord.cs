using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;

namespace NachaFileGenerator.Concrete
{
    class NachaRecord
    {
        protected string PadIfNeeded(IFieldDefinition fieldDefinition, string value)
        {
            if (fieldDefinition.GetFieldType() == FieldType.Alphabetic || fieldDefinition.GetFieldType() == FieldType.Alphanumeric)
            {
                value = value.PadRight(fieldDefinition.GetLength(), ' ');
            }
            else if (fieldDefinition.GetFieldType() == FieldType.Numeric)
            {
                value = value.PadLeft(fieldDefinition.GetLength(), '0');
            }
            return value;
        }
    }
}
