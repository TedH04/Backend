using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dtos
{
    public class ContactHttpResponse
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
