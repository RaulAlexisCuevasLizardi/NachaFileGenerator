using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NachaFileGenerator.Enums
{
    //consider adding "concrete" field type.
    //a concrete type would have a value that cannot be changed
    public enum FieldType
    {
        Numeric,
        Alphabetic,
        Alphanumeric,
        RouteNumber,
        Date,
        Time
    }
}
