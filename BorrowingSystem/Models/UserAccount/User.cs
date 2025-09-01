namespace BorrowingSystem.Models.UserAccount
{
    public class User
    {
        public int UserId { get; set; }       // Primary Key
        public string Username { get; set; }  // Username for login
        public string Password { get; set; }  // Store password (later hash it)
        public string Email { get; set; }     // Email of the user

        // Role (true = Chairman, false = Faculty maybe?)
        public bool Role { get; set; }

        // Active status (true = active, false = inactive)
        public bool Active { get; set; }
    }
}
