using System.ComponentModel.DataAnnotations;

namespace DDD.Domain
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required]
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}