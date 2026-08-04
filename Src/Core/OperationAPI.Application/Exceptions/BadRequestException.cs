
using FluentValidation.Results;

namespace OperationAPI.Application.Exceptions
{
   public class BadRequestException : Exception
    {
        public IDictionary<string, string[]>? ValidationErrors { get; set; }

        public BadRequestException(string? message) : base(message)
        {
        }

        public BadRequestException(string? message, IEnumerable<ValidationFailure> validationResult) : base(message)
        {
            ValidationErrors = validationResult
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );
        }
    }
}
