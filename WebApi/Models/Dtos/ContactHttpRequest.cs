using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class ContactHttpRequest
    {
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Message { get; set; } = null!;

        public static implicit operator ContactFormEntity(ContactHttpRequest req)
        {
            return new ContactFormEntity
            {
                CustomerName = req.CustomerName,
                CustomerEmail = req.CustomerEmail,
                Message = req.Message
            };
        }
    }
}
