namespace APIGateway.Services.Entities.Base.Validation
{
    public interface IValidatable
    {

    }

    public interface IValidatable<T> : IValidatable where T : BaseEntity
    {
        bool Validate();
    }
}
