using NachaFileGenerator.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Interfaces
{
    interface IValidator
    {
        public abstract void Validate(IFieldDefinition fieldDefinition, string value);
    }
}
