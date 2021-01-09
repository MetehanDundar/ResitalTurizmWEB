using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        //public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } //kullanıcının giriş yapmadan önceki isteği giriş yaptıktan hemen sonra gerçekleşmesi için. (giriş yapılmadan önceki istek)
    }
}
