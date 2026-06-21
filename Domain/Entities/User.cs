using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { }

        public User(string email, string passwordHash, string firstName, string lastName) { 

            if (string.IsNullOrWhiteSpace(email)) 
                throw new ArgumentNullException("Email is required.", nameof(email));
            try
            {
                _ = new MailAddress(email);
            }
            catch
            {
                throw new ArgumentException("Email is not valid.", nameof(email));
            }

            if(string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentNullException("Password hash is required.", nameof(passwordHash));

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("First name is required.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("Last name is required.", nameof(lastName));

            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
