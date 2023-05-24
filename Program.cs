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
            fileHeaderRecord.AddField(FileHeaderFields.RecordTypeCode, "1");
            fileHeaderRecord.AddField(FileHeaderFields.PriorityCode, "01");
            fileHeaderRecord.AddField(FileHeaderFields.ImmediateDestination, "B987654321");
            fileHeaderRecord.AddField(FileHeaderFields.ImmediateOrigin, "A234567890");
            fileHeaderRecord.AddField(FileHeaderFields.FileCreationDate, "230523");
            fileHeaderRecord.AddField(FileHeaderFields.FileCreationTime, "1940");
            fileHeaderRecord.AddField(FileHeaderFields.FileIdModifier, "0");
            fileHeaderRecord.AddField(FileHeaderFields.RecordSize, "094");
            fileHeaderRecord.AddField(FileHeaderFields.BlockingFactor, "10");
            fileHeaderRecord.AddField(FileHeaderFields.FormatCode, "1");
            fileHeaderRecord.AddField(FileHeaderFields.ImmediateDestinationName, "RaulCuevas");
            fileHeaderRecord.AddField(FileHeaderFields.ImmediateOrigineName, "supsup");
            fileHeaderRecord.AddField(FileHeaderFields.ReferenceCode, "ExtraInf");
            Console.WriteLine("[" + fileHeaderRecord.GetRecord() + "]");
            nachaFileGenerator.AddRecord(fileHeaderRecord);
        }
    }
}
