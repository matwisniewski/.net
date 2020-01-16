using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class DBLogin : DbContext
    {
        public DbSet<Login> Login { get; set; }
    }

    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
        public double stanKonta { get; set; }
        public double oszczednosci { get; set; }
        public double zdolnoscKredyt { get; set; }
    }
}
