using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Domain.Models
{
    [NotMapped]
    public class Notifications
    {        
        public DateOnly DateData { get; set; } 

    }
}
