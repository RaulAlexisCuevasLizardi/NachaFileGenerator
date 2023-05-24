using NachaFileGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
