using System.ComponentModel.DataAnnotations;
using ETicketsApp.Data.Repository;

namespace ETicketsApp.Models
{
    public class BaseEntity : IEntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
