using NachaFileGenerator.Enums;

namespace NachaFileGenerator.Interfaces.Fields
{
    class FieldDefinition
    {
        private readonly int Length;
        private readonly FieldType FieldType;
        private readonly bool Required;
        private readonly int Pos;
        public FieldDefinition(int length, FieldType fieldType, bool required, int pos)
        {
            this.Length = length;
            this.FieldType = fieldType;
            this.Required = required;
            this.Pos = pos;
        }

        public int GetLength()
        {
            return this.Length;
        }

        public FieldType GetFieldType()
        {
            return this.FieldType;
        }

        public bool IsRequired()
        {
            return this.Required;
        }

        public int GetPos()
        {
            return this.Pos;
        }
    }
}
