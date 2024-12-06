using System.ComponentModel.DataAnnotations;

namespace BusinessAccessLayer.DTOs
{
    public class PrimaryKeyDTO
    {
        [Key]
        public int AccountId { get; set; }
    }
}