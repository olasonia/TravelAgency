namespace TravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
       
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voyage> Voyages { get; set; }
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public User()
        {
        }

        public User(string name, string surname, string login, string password)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
           

        }
    }

    public class Voyage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Destination { get; set; }
        public int Days { get; set; }

        public Voyage()
        {
        }

        public Voyage(string destination, int days)
        {
            Destination = destination;
            Days = days;
        }
    }
}