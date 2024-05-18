using FluentValidation;

namespace Uplay.Application.Models.SocialLinks
{
    public class SaveSocialLinkRequestValidator : BaseValidator<SaveSocialLinkRequest>
    {
        public SaveSocialLinkRequestValidator()
        {
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("Phone is required");
            RuleFor(x => x.FacebookUrl).NotEmpty().NotNull().WithMessage("FacebookUrl is required");
            RuleFor(x => x.TwitterUrl).NotEmpty().NotNull().WithMessage("TwitterUrl is required");
            RuleFor(x => x.InstagramUrl).NotEmpty().NotNull().WithMessage("InstagramUrl is required");
            RuleFor(x => x.YoutubeUrl).NotEmpty().NotNull().WithMessage("YoutubeUrl is required");
            RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage("Email is not correact format").NotEmpty().WithMessage("Email is required");
        }
    }
}
