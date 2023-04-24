using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class ContactFormEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Message { get; set; } = null!;
        public static implicit operator ContactHttpResponse(ContactFormEntity entity)
        {
            return new ContactHttpResponse
            {
                CustomerId = entity.CustomerId,
                CustomerName = entity.CustomerName,
                CustomerEmail = entity.CustomerEmail,
                Message = entity.Message,
            };
        }
    }
}
