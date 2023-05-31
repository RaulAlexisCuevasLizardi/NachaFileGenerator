using NachaFileGenerator.Enums;

namespace NachaFileGenerator.Interfaces.Fields
{
    class FileHeaderFieldDefinition : FieldDefinition, IFieldDefinition
    {
        private readonly FileHeaderField FieldNumber;
        public FileHeaderFieldDefinition(FileHeaderField fieldNumber, int length, FieldType fieldType, bool required, int pos, string defaultValue = null): base(length, fieldType, required, pos, defaultValue)
        {
            this.FieldNumber = fieldNumber;
        }

        public int GetFieldNumber()
        {
            return (int)this.FieldNumber;
        }

        public string GetFieldName()
        {
            return this.FieldNumber.ToString();
        }
    }
}
