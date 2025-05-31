using Microsoft.EntityFrameworkCore;
using Projekt;
using System.Collections.Generic;

public class KinoContext : DbContext
{
    public DbSet<Film> Filmy { get; set; }
    public DbSet<Sala> Sale { get; set; }
    public DbSet<Miejsce> Miejsca { get; set; }
    public DbSet<Rezerwacja> Rezerwacje { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=kino.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var sale = new List<Sala>
    {
        new Sala { SalaId = 1, Nazwa = "Sala 1", LiczbaRzedow = 10, LiczbaMiejscWRzedzie = 10 },
        new Sala { SalaId = 2, Nazwa = "Sala 2", LiczbaRzedow = 8, LiczbaMiejscWRzedzie = 12 },
        new Sala { SalaId = 3, Nazwa = "Sala 3", LiczbaRzedow = 6, LiczbaMiejscWRzedzie = 8 }
    };

        modelBuilder.Entity<Sala>().HasData(sale);

        var miejsca = new List<Miejsce>();
        int id = 1;

        foreach (var sala in sale)
        {
            for (int rzad = 1; rzad <= sala.LiczbaRzedow; rzad++)
            {
                for (int numer = 1; numer <= sala.LiczbaMiejscWRzedzie; numer++)
                {
                    miejsca.Add(new Miejsce
                    {
                        MiejsceId = id++,
                        Rzad = rzad,
                        Numer = numer,
                        SalaId = sala.SalaId,
                        Zarezerwowane = false
                    });
                }
            }
        }

        modelBuilder.Entity<Miejsce>().HasData(miejsca);

        // Dodaj filmy przypisane do sal
        var filmy = new List<Film>
    {
        new Film { FilmId = 1, Tytul = "Incepcja", Data = new DateTime(2025, 5, 12, 12, 15, 0), SalaId = 1 },
        new Film { FilmId = 2, Tytul = "Matrix", Data = new DateTime(2025, 5, 12, 15, 0, 0), SalaId = 2 },
        new Film { FilmId = 3, Tytul = "Interstellar", Data = new DateTime(2025, 5, 12, 18, 30, 0), SalaId = 3 }
    };

        modelBuilder.Entity<Film>().HasData(filmy);
    }



}
