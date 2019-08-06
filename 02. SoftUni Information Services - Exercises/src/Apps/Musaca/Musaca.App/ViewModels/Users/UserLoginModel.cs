using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.App.ViewModels.Users
{
    public class UserLoginModel
    {
        private const string UsernameErrorMessage = "Username must be between 5 and 20 chars long!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }
        [RequiredSis]
        public string Password { get; set; }
    }
}
