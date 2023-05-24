using NachaFileGenerator.Interfaces;
using System;
using System.Collections.Generic;

namespace NachaFileGenerator.Concrete
{
    class NachaFile: INachaFileGenerator
    {
        private List<INachaRecord> NachaRecords = new List<INachaRecord>();

        public string GenerateFile()
        {
            throw new NotImplementedException();
        }

        public void AddRecord(INachaRecord nachaRecord)
        {
            NachaRecords.Add(nachaRecord);
        }
    }
}
