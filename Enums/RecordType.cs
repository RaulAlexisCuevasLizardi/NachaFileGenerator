using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Enums
{
    public enum RecordType
    {
        FileHeader = 1,
        BatchHeader = 5,
        EntryRecord = 6,
        AddendaRecord = 7,
        BatchControl = 8,
        FileControl = 9
    }
}
