using System.ComponentModel.DataAnnotations;
using Resources;

namespace Infra.Dto
{
    public class ReqAttribute : RequiredAttribute
    {
        public ReqAttribute()
        {
            ErrorMessageResourceName = "required";
            ErrorMessageResourceType = typeof(Mui);
        }
    }
}