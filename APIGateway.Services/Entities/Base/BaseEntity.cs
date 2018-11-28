using APIGateway.Services.Entities.Base.Validation;

namespace APIGateway.Services.Entities.Base
{
    public abstract class BaseEntity : IValidatable<BaseEntity>
    {
        public bool Validate()
        {
            return EntityValidator.Validate(this);
        }
    }
}
