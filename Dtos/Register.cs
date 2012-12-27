using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface.ServiceModel;

namespace MyServiceDTO
{
    [Route("/register")]
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }

    public class RegisterResponse
    {
        public RegisterRequest RegisterRequest;
        public string Result;
        public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
    }


}
