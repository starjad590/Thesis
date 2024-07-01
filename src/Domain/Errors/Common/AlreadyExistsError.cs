using Domain.Errors.BaseErrors;
using Microsoft.Extensions.Logging;

namespace Domain.Errors;

public sealed class AlreadyExistsError : BadRequestError
{
    private const string Error = "{0} already exists";
    public AlreadyExistsError(ILogger logger, string model) : base(string.Format(Error, model))
    {
        logger.LogError(string.Format(Error, model));
    }
}
