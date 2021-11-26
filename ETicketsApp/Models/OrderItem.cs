using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
