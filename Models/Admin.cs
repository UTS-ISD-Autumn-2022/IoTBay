namespace IoTBay.Models
{
    public class Admin : User
    {
        public Guid Id { get; set; }

        public Admin(string username, string password, string fullName, string email) : base(username, password, fullName, email)
        {
        }
    }
}
