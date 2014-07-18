using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace krotkiProjekt.Models
{
    public class Autor
    {
        [Key]
        public int Id_A { get; set; }
        public string Imie { get; set; }
        public string Opis { get; set; }
        public DateTime Data_urodzenia { get; set; }
    }
    public class Ksiazka
    {
        [Key]
        public int Id_K { get; set; }
        public string Tytul { get; set; }
        public string Opis { get; set; }
        public DateTime Data_wydania { get; set; }
    }
    public class Ksiazka_Autor
    {
        [Key]
        public int Id { get; set; }
        public int Id_A { get; set; }
        public int Id_K { get; set; }
    }
    public class MyDb : DbContext
    {
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Ksiazka_Autor> Asocjacja { get; set; }
    }
    public class Temp1
    { //ważna jest kolejność w porównaniu do kontrolera 'Home' i var 'Ksiazki' wyrażenie lambda
        public int Id_A { get; set; }
        public int Id { get; set; }
        public int Id_K { get; set; }
    }
    public class Temp2
    {
        public int Id_A { get; set; }
        public int Id_K { get; set; }
        public string Tytul { get; set; }
        public string Opis { get; set; } //to można usunąć, ale zostawiamy ;)
        public DateTime Data_wydania { get; set; }
    }
}
