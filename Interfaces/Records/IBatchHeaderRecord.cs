using NachaFileGenerator.Enums;

namespace NachaFileGenerator.Interfaces
{
    interface IBatchHeaderRecord: INachaRecord
    {
        public abstract void AddField(BatchHeaderField fieldDefinition, string value);
        public abstract string GetRecord();
    }
}
