using System.Collections.Generic;

namespace AutoSalon.Models
{
    public class Users
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool License { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
