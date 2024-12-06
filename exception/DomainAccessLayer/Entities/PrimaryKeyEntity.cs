using System.ComponentModel.DataAnnotations;

namespace DomainAccessLayer.Entities
{
    public class PrimaryKeyEntity
    {
        [Key]
        public int AccountId { get; set; }
    }
}