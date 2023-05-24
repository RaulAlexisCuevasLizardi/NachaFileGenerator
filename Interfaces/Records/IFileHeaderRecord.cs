using NachaFileGenerator.Enums;

namespace NachaFileGenerator.Interfaces
{
    interface IFileHeaderRecord: INachaRecord
    {
        public abstract void AddField(FileHeaderField fieldDefinition, string value);
        public abstract string GetRecord();
    }
}
