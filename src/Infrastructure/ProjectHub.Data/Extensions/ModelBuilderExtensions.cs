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
}