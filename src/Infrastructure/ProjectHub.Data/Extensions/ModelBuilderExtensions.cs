namespace ProjectHub.Data.Extensions;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProjectHub.Data.Abstractions.Entities;

[ExcludeFromCodeCoverage]
public static class ModelBuilderExtensions
{
    public static void SeedProgrammingLanguage(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>().HasData(
            new ProgrammingLanguage { Id = 1, Name = "Assembly" },
            new ProgrammingLanguage { Id = 2, Name = "Befunge" },
            new ProgrammingLanguage { Id = 3, Name = "Brainfuck" },
            new ProgrammingLanguage { Id = 4, Name = "C#" },
            new ProgrammingLanguage { Id = 5, Name = "Chef" },
            new ProgrammingLanguage { Id = 6, Name = "Chicken" },
            new ProgrammingLanguage { Id = 7, Name = "Clojure" },
            new ProgrammingLanguage { Id = 8, Name = "COBOL" },
            new ProgrammingLanguage { Id = 9, Name = "Dart" },
            new ProgrammingLanguage { Id = 10, Name = "Elm" },
            new ProgrammingLanguage { Id = 11, Name = "Elixir" },
            new ProgrammingLanguage { Id = 12, Name = "Erlang" },
            new ProgrammingLanguage { Id = 13, Name = "F#" },
            new ProgrammingLanguage { Id = 14, Name = "Fortran" },
            new ProgrammingLanguage { Id = 15, Name = "Go" },
            new ProgrammingLanguage { Id = 16, Name = "Groovy" },
            new ProgrammingLanguage { Id = 17, Name = "Haskell" },
            new ProgrammingLanguage { Id = 18, Name = "Java" },
            new ProgrammingLanguage { Id = 19, Name = "JavaScript" },
            new ProgrammingLanguage { Id = 20, Name = "Kotlin" },
            new ProgrammingLanguage { Id = 21, Name = "Lisp" },
            new ProgrammingLanguage { Id = 22, Name = "LOLCODE" },
            new ProgrammingLanguage { Id = 23, Name = "Lua" },
            new ProgrammingLanguage { Id = 24, Name = "MATLAB" },
            new ProgrammingLanguage { Id = 25, Name = "Objective-C" },
            new ProgrammingLanguage { Id = 26, Name = "Pascal" },
            new ProgrammingLanguage { Id = 27, Name = "Perl" },
            new ProgrammingLanguage { Id = 28, Name = "PHP" },
            new ProgrammingLanguage { Id = 29, Name = "Piet" },
            new ProgrammingLanguage { Id = 30, Name = "Prolog" },
            new ProgrammingLanguage { Id = 31, Name = "Python" },
            new ProgrammingLanguage { Id = 32, Name = "R" },
            new ProgrammingLanguage { Id = 33, Name = "Ruby" },
            new ProgrammingLanguage { Id = 34, Name = "Rust" },
            new ProgrammingLanguage { Id = 35, Name = "Scala" },
            new ProgrammingLanguage { Id = 36, Name = "Shakespeare" },
            new ProgrammingLanguage { Id = 37, Name = "Swift" },
            new ProgrammingLanguage { Id = 38, Name = "TrumpScript" },
            new ProgrammingLanguage { Id = 39, Name = "TypeScript" },
            new ProgrammingLanguage { Id = 40, Name = "Whitespace" },
            new ProgrammingLanguage { Id = 41, Name = "Webassembly" },
            new ProgrammingLanguage { Id = 42, Name = "keine Vorgabe" }
        );
    }

    public static void SeedTribe(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tribe>().HasData(
            new Tribe { Id = 1, Name = "Tribe Alpha" },
            new Tribe { Id = 2, Name = "Tribe Chi" },
            new Tribe { Id = 3, Name = "Tribe Delta" },
            new Tribe { Id = 4, Name = "Tribe Gamma" },
            new Tribe { Id = 5, Name = "Tribe Iota" },
            new Tribe { Id = 6, Name = "Tribe Lambda" },
            new Tribe { Id = 7, Name = "Tribe My" },
            new Tribe { Id = 8, Name = "Tribe Omega" },
            new Tribe { Id = 9, Name = "Tribe Psi" },
            new Tribe { Id = 10, Name = "Tribe Sigma" },
            new Tribe { Id = 11, Name = "Tribe Tau" },
            new Tribe { Id = 12, Name = "Tribe Xi" }
        );
    }

    public static void SeedUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { FirstName = "Adele", LastName = "Vance", Email = "AdeleV@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Alex", LastName = "Wilber", Email = "AlexW@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Diego", LastName = "Siciliani", Email = "DiegoS@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Grady", LastName = "Archie", Email = "GradyA@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Henrietta", LastName = "Mueller", Email = "HenriettaM@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Isaiah", LastName = "Langer", Email = "IsaiahL@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Johanna", LastName = "Lorenz", Email = "JohannaL@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Joni", LastName = "Sherman", Email = "JoniS@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Lee", LastName = "Gu", Email = "LeeG@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Lidia", LastName = "Holloway", Email = "LidiaH@ynl4z.onmicrosoft.com" },
            new User { FirstName = "Lynne", LastName = "Robbins", Email = "LynneR@ynl4z.onmicrosoft.com" }
        );
    }

    public static void SeedProject(this ModelBuilder modelBuilder)
    {
        string[] userUuids =
        {
            "AdeleV@ynl4z.onmicrosoft.com",
            "AlexW@ynl4z.onmicrosoft.com",
            "DiegoS@ynl4z.onmicrosoft.com",
            "GradyA@ynl4z.onmicrosoft.com",
            "HenriettaM@ynl4z.onmicrosoft.com",
            "IsaiahL@ynl4z.onmicrosoft.com",
            "JohannaL@ynl4z.onmicrosoft.com",
            "JoniS@ynl4z.onmicrosoft.com",
            "LeeG@ynl4z.onmicrosoft.com",
            "LidiaH@ynl4z.onmicrosoft.com",
            "LynneR@ynl4z.onmicrosoft.com"
        };

        List<Project> projects = new List<Project>();

        for (int i = 1; i <= 20; i++)
        {
            projects.Add(new Project
            {
                Id = i,
                Description = $"Project Description {i}",
                Title = $"Project Title {i}",
                Status = "New",
                UserUuid = userUuids[i % userUuids.Length],
                TribeId = i % 12 + 1,
                Created = GenerateRandomDate(i)
            });
        }

        modelBuilder.Entity<Project>().HasData(projects);
    }

    public static void SeedProjectProgrammingLanguages(this ModelBuilder modelBuilder1)
    {
        List<ProjectProgrammingLanguages> projectProgrammingLanguages = new();

        for (int i = 0; i < 30; i++)
        {
            int projectId = i % 20 + 1;
            int programmingLanguageId = i % 42 + 1;

            projectProgrammingLanguages.Add(new ProjectProgrammingLanguages
            {
                ProjectId = projectId,
                ProgrammingLanguageId = programmingLanguageId
            });
        }

        modelBuilder1.Entity<ProjectProgrammingLanguages>().HasData(projectProgrammingLanguages);
    }

    private static DateTime GenerateRandomDate(int seed)
    {
        Random rnd = new Random(seed);
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(rnd.Next(range));
    }
}