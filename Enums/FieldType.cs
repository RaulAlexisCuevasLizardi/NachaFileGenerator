namespace NachaFileGenerator.Enums
{
    //consider adding "concrete" field type.
    //a concrete type would have a value that cannot be changed
    public enum FieldType
    {
        Numeric,
        Alphabetic,
        Alphanumeric,
        RouteNumber, //a nine digit string that starts with an alphabetical character
        Date, //YYMMDD
        Time, //HHMM
        RouteNumberNoChkDigit, //TTTTAAAA, route number without the first character
        Constant //Cannot be changed, must have default value
    }
}
