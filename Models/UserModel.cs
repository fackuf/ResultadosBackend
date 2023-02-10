using System.ComponentModel.DataAnnotations;

namespace ResultadosBackend.Models
{
    public class User : BaseEntity
    {

        [Required]
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
