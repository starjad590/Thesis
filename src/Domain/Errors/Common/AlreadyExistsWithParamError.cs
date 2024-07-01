using Domain.Errors.BaseErrors;
using Microsoft.Extensions.Logging;

namespace Domain.Errors;

public sealed class AlreadyExistsWithParamError : BadRequestError
{
    private const string Error = "{0} already exists : {1} => {2}";
    public AlreadyExistsWithParamError(ILogger logger, string model, string property, object id) : base(string.Format(Error, model, property, id))
    {
        logger.LogError(string.Format(Error, model, property, id));
    }
}
