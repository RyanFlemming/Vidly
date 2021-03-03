using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        // to do: add vm's
        // replace name with an enum

        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
