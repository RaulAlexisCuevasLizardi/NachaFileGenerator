using NachaFileGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Interfaces
{
    interface IFieldDefinition
    {
        bool IsRequired();
        FieldType GetFieldType();
        int GetLength();
        int GetPos();
        int GetFieldNumber();
        string GetFieldName();
    }
}
