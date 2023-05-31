using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;
using NachaFileGenerator.Interfaces.Fields;
using System;
using System.Text;

namespace NachaFileGenerator.Concrete
{
    class BatchHeaderRecord : NachaRecord, IBatchHeaderRecord
    {
        private StringBuilder BatchHeaderRecordStrBuilder;
        private readonly IFieldDefinition[] FieldDefinitions;
        public BatchHeaderRecord()
        {
            BatchHeaderRecordStrBuilder = new StringBuilder();
            FieldDefinitions = new BatchHeaderFieldDefinition[]{
                new BatchHeaderFieldDefinition(BatchHeaderField.RecordTypeCode,               1,   FieldType.Numeric,                  true,  1, "5"),
                new BatchHeaderFieldDefinition(BatchHeaderField.ServiceClassCode,             3,   FieldType.Numeric,                  true,  2),
                new BatchHeaderFieldDefinition(BatchHeaderField.CompanyName,                  16,  FieldType.Alphanumeric,             true,  5),
                new BatchHeaderFieldDefinition(BatchHeaderField.CompanyDiscretionaryData,     20,  FieldType.Alphanumeric,             false, 21),
                new BatchHeaderFieldDefinition(BatchHeaderField.CompanyIdentification,        10,  FieldType.Alphanumeric,             true,  41),
                new BatchHeaderFieldDefinition(BatchHeaderField.StandardEntryClassCode,        3,  FieldType.Alphanumeric,             true,  51),
                new BatchHeaderFieldDefinition(BatchHeaderField.CompanyEntryDescription,      10,  FieldType.Alphanumeric,             true,  54),
                new BatchHeaderFieldDefinition(BatchHeaderField.CompanyDescriptiveDate,       6,   FieldType.Alphanumeric,             true,  64),
                new BatchHeaderFieldDefinition(BatchHeaderField.EffectiveEntryDate,           6,   FieldType.Date,                     true,  70),
                new BatchHeaderFieldDefinition(BatchHeaderField.SettlementDate,               3,   FieldType.Numeric,                  true,  76),
                new BatchHeaderFieldDefinition(BatchHeaderField.OriginatorStatusCode,         1,   FieldType.Alphanumeric,             true,  79),
                new BatchHeaderFieldDefinition(BatchHeaderField.OriginatingDfiIdentification, 8,   FieldType.RouteNumberNoChkDigit,    true,  80),
                new BatchHeaderFieldDefinition(BatchHeaderField.BatchNumber,                  7,   FieldType.Numeric,                  true,  88)
            };
        }
        public void AddField(BatchHeaderField fieldNumber, string value)
        {
            BatchHeaderFieldDefinition fieldDefinition = this.MatchFieldDefinition(fieldNumber);
            IValidator validator = new Validator();
            validator.Validate(fieldDefinition, value);
            value = base.PadIfNeeded(fieldDefinition, value);
            BatchHeaderRecordStrBuilder.Insert(fieldDefinition.GetPos() - 1, value);
        }

        public string GetRecord()
        {
            return BatchHeaderRecordStrBuilder.ToString();
        }
        private BatchHeaderFieldDefinition MatchFieldDefinition(BatchHeaderField fieldNumber)
        {
            foreach (BatchHeaderFieldDefinition fieldDefinition in this.FieldDefinitions)
            {
                if (fieldDefinition.GetFieldNumber() == (int)fieldNumber)
                {
                    return fieldDefinition;
                }
            }
            throw new Exception("Batch header record does not have that field");
        }
    }
}
