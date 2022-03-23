namespace IoTBay.Models;
public class Admin : User
{
    public Admin(string username, string password, string fullName, string email) : base(username, password, fullName, email)
    {
    }
}
