namespace Panda.WebApp.Controllers
{
    using SIS.MvcFramework.Attributes.Validation;

    public class LoginInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be betweeb 5 and 20 characters")]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }
    }
}