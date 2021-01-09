using Microsoft.AspNetCore.Identity;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Identity
{
    public class User : IdentityUser
    {
        //Asagıda, IdentityUser kütüphanesinden gelen özellikler dışında özellikler tanımladım. Aşagıdaki propertylere ihtiyacımız yoksa User tanımlamaya gerek yok, IdentityUser kullanabiliriz. Aynı durum IdentityRole için de geçerlidir.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
