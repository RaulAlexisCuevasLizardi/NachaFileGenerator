using NachaFileGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Interfaces.Fields
{
    class FileHeaderFieldDefinition : IFieldDefinition
    {
        private readonly FileHeaderFields FieldNumber;
        private readonly int Length;
        private readonly FieldType FieldType;
        private readonly bool Required;
        private readonly int Pos;
        public FileHeaderFieldDefinition(FileHeaderFields fieldNumber, int length, FieldType fieldType, bool required, int pos)
        {
            this.FieldNumber = fieldNumber;
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
