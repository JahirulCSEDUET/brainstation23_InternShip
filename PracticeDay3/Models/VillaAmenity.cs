using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeDay3.Models
{
    public class VillaAmenity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int VillaId { get; set; }
        public Villa Villa { get; set; }
        public string Name { get; set; }
    }
}
