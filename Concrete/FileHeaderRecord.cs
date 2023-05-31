using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;
using NachaFileGenerator.Interfaces.Fields;
using System;
using System.Text;

namespace NachaFileGenerator.Concrete
{
    class FileHeaderRecord : NachaRecord, IFileHeaderRecord
    {
        private StringBuilder FileHeaderRecordStrBuilder;
        private readonly IFieldDefinition[] FieldDefinitions;

        public FileHeaderRecord()
        {
            FileHeaderRecordStrBuilder = new StringBuilder();
            FieldDefinitions = new FileHeaderFieldDefinition[]{
                new FileHeaderFieldDefinition(FileHeaderField.RecordTypeCode,           1,  FieldType.Numeric,         true,  1, "1"),
                new FileHeaderFieldDefinition(FileHeaderField.PriorityCode,             2,  FieldType.Numeric,         true,  2, "01"),
                new FileHeaderFieldDefinition(FileHeaderField.ImmediateDestination,     10, FieldType.RouteNumber,     true,  4),
                new FileHeaderFieldDefinition(FileHeaderField.ImmediateOrigin,          10, FieldType.RouteNumber,     true,  14),
                new FileHeaderFieldDefinition(FileHeaderField.FileCreationDate,         6,  FieldType.Date,            true,  24),
                new FileHeaderFieldDefinition(FileHeaderField.FileCreationTime,         4,  FieldType.Time,            false, 30),
                new FileHeaderFieldDefinition(FileHeaderField.FileIdModifier,           1,  FieldType.Alphanumeric,    true,  34),
                new FileHeaderFieldDefinition(FileHeaderField.RecordSize,               3,  FieldType.Numeric,         true,  35, "094"),
                new FileHeaderFieldDefinition(FileHeaderField.BlockingFactor,           2,  FieldType.Numeric,         true,  38, "10"),
                new FileHeaderFieldDefinition(FileHeaderField.FormatCode,               1,  FieldType.Numeric,         true,  40, "1"),
                new FileHeaderFieldDefinition(FileHeaderField.ImmediateDestinationName, 23, FieldType.Alphanumeric,    true,  41),
                new FileHeaderFieldDefinition(FileHeaderField.ImmediateDestinationName, 23, FieldType.Alphanumeric,    false, 41),
                new FileHeaderFieldDefinition(FileHeaderField.ImmediateOrigineName,     23, FieldType.Alphanumeric,    false, 64),
                new FileHeaderFieldDefinition(FileHeaderField.ReferenceCode,            8,  FieldType.Alphanumeric,    false, 87)
            };
        }
        public void AddField(FileHeaderField fieldNumber, string value)
        {
            FileHeaderFieldDefinition fieldDefinition = this.MatchFieldDefinition(fieldNumber);
            IValidator validator = new Validator();
            validator.Validate(fieldDefinition, value);
            value = base.PadIfNeeded(fieldDefinition, value);
            FileHeaderRecordStrBuilder.Insert(fieldDefinition.GetPos() - 1, value);
        }
        public string GetRecord()
        {
            return FileHeaderRecordStrBuilder.ToString();
        }
        private FileHeaderFieldDefinition MatchFieldDefinition(FileHeaderField fieldNumber)
        {
            foreach (FileHeaderFieldDefinition fieldDefinition in this.FieldDefinitions)
            {
                if(fieldDefinition.GetFieldNumber() == (int)fieldNumber)
                {
                    return fieldDefinition;
                }
            }
            throw new Exception("File header record does not have that field");
        }
    }
}
