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
        Time,
        RouteNumberNoChkDigit
    }
}
