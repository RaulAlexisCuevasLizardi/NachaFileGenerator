using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Enums
{
    public enum FileHeaderFields
    {
        RecordTypeCode,
        PriorityCode,
        ImmediateDestination,
        ImmediateOrigin,
        FileCreationDate,
        FileCreationTime,
        FileIdModifier,
        RecordSize,
        BlockingFactor,
        FormatCode,
        ImmediateDestinationName,
        ImmediateOrigineName,
        ReferenceCode
    }
}
