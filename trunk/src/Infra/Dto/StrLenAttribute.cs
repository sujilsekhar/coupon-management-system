using System.ComponentModel.DataAnnotations;
using Resources;

namespace Infra.Dto
{
    public class StrLenAttribute : StringLengthAttribute
    {
        public StrLenAttribute(int maximumLength)
            : base(maximumLength)
        {
            ErrorMessageResourceName = "strlen";
            ErrorMessageResourceType = typeof(Mui);
        }
    }
}