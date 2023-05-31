using NachaFileGenerator.Enums;

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
        string GetDefaultValue();
    }
}
