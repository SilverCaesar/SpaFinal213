using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaFinal213.Models
{
    public abstract class User
    {
        public int User_Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string ?Phone { get; set; }
    }
}
