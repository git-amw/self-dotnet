using System.ComponentModel.DataAnnotations.Schema;

namespace DomainAccessLayer.Entities
{
    public class AccountEntity : PrimaryKeyEntity
    {
        public int Amount { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}