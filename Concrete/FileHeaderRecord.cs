using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;
using NachaFileGenerator.Interfaces.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new FileHeaderFieldDefinition(FileHeaderFields.RecordTypeCode,           1,  FieldType.Numeric,         true, 1),
                new FileHeaderFieldDefinition(FileHeaderFields.PriorityCode,             2,  FieldType.Numeric,         true, 2),
                new FileHeaderFieldDefinition(FileHeaderFields.ImmediateDestination,     10, FieldType.RouteNumber,     true, 4),
                new FileHeaderFieldDefinition(FileHeaderFields.ImmediateOrigin,          10, FieldType.RouteNumber,     true, 14),
                new FileHeaderFieldDefinition(FileHeaderFields.FileCreationDate,         6,  FieldType.Date,            true, 24),
                new FileHeaderFieldDefinition(FileHeaderFields.FileCreationTime,         4,  FieldType.Time,            true, 30),
                new FileHeaderFieldDefinition(FileHeaderFields.FileIdModifier,           1,  FieldType.Alphanumeric,    true, 34),
                new FileHeaderFieldDefinition(FileHeaderFields.RecordSize,               3,  FieldType.Numeric,         true, 35),
                new FileHeaderFieldDefinition(FileHeaderFields.BlockingFactor,           2,  FieldType.Numeric,         true, 38),
                new FileHeaderFieldDefinition(FileHeaderFields.FormatCode,               1,  FieldType.Numeric,         true, 40),
                new FileHeaderFieldDefinition(FileHeaderFields.ImmediateDestinationName, 23, FieldType.Alphanumeric,    true, 41),
                new FileHeaderFieldDefinition(FileHeaderFields.ImmediateDestinationName, 23, FieldType.Alphanumeric,    true, 41),
                new FileHeaderFieldDefinition(FileHeaderFields.ImmediateOrigineName,     23, FieldType.Alphanumeric,    true, 64),
                new FileHeaderFieldDefinition(FileHeaderFields.ReferenceCode,            8,  FieldType.Alphanumeric,    true, 87)
            };
        }
        public void AddField(FileHeaderFields fieldNumber, string value)
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
        private FileHeaderFieldDefinition MatchFieldDefinition(FileHeaderFields fieldNumber)
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
