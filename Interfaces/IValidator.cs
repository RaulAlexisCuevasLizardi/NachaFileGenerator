
namespace NachaFileGenerator.Interfaces
{
    interface IValidator
    {
        public abstract void Validate(IFieldDefinition fieldDefinition, string value);
    }
}
