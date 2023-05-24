using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
