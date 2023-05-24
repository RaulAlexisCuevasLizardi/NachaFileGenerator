using NachaFileGenerator.Concrete;
using NachaFileGenerator.Enums;
using NachaFileGenerator.Interfaces;
using System;

namespace NachaFileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NachaFile nachaFileGenerator = new NachaFile();
            IFileHeaderRecord fileHeaderRecord = new FileHeaderRecord();
            fileHeaderRecord.AddField(FileHeaderField.RecordTypeCode, "1");
            fileHeaderRecord.AddField(FileHeaderField.PriorityCode, "01");
            fileHeaderRecord.AddField(FileHeaderField.ImmediateDestination, "B987654321");
            fileHeaderRecord.AddField(FileHeaderField.ImmediateOrigin, "A234567890");
            fileHeaderRecord.AddField(FileHeaderField.FileCreationDate, "230523");
            fileHeaderRecord.AddField(FileHeaderField.FileCreationTime, "1940");
            fileHeaderRecord.AddField(FileHeaderField.FileIdModifier, "0");
            fileHeaderRecord.AddField(FileHeaderField.RecordSize, "094");
            fileHeaderRecord.AddField(FileHeaderField.BlockingFactor, "10");
            fileHeaderRecord.AddField(FileHeaderField.FormatCode, "1");
            fileHeaderRecord.AddField(FileHeaderField.ImmediateDestinationName, "RaulCuevas");
            fileHeaderRecord.AddField(FileHeaderField.ImmediateOrigineName, "supsup");
            fileHeaderRecord.AddField(FileHeaderField.ReferenceCode, "ExtraInf");
            Console.WriteLine("[" + fileHeaderRecord.GetRecord() + "]");
            nachaFileGenerator.AddRecord(fileHeaderRecord);
        }
    }
}
