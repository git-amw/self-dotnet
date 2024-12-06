using System.ComponentModel.DataAnnotations;
namespace API.Model
{
    public class PrimaryKey
    {
        [Key]
        public int AccountId { get; set; }
    }
}