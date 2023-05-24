using NachaFileGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Interfaces
{
    interface IFileHeaderRecord: INachaRecord
    {
        public abstract void AddField(FileHeaderFields fieldDefinition, string value);
        public abstract string GetRecord();
    }
}
