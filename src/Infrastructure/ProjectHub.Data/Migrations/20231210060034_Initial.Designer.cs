﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectHub.Data.Contexts;

#nullable disable

namespace ProjectHub.Data.Migrations
{
    [DbContext(typeof(ProjectHubSqLiteDbContext))]
    [Migration("20231210060034_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Assembly"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Befunge"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Brainfuck"
                        },
                        new
                        {
                            Id = 4,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chef"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Chicken"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Clojure"
                        },
                        new
                        {
                            Id = 8,
                            Name = "COBOL"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dart"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Elm"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Elixir"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Erlang"
                        },
                        new
                        {
                            Id = 13,
                            Name = "F#"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Fortran"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Go"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Groovy"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Haskell"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 19,
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Kotlin"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Lisp"
                        },
                        new
                        {
                            Id = 22,
                            Name = "LOLCODE"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Lua"
                        },
                        new
                        {
                            Id = 24,
                            Name = "MATLAB"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Objective-C"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Pascal"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Perl"
                        },
                        new
                        {
                            Id = 28,
                            Name = "PHP"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Piet"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Prolog"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 32,
                            Name = "R"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Ruby"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Rust"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Scala"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Shakespeare"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Swift"
                        },
                        new
                        {
                            Id = 38,
                            Name = "TrumpScript"
                        },
                        new
                        {
                            Id = 39,
                            Name = "TypeScript"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Whitespace"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Webassembly"
                        },
                        new
                        {
                            Id = 42,
                            Name = "keine Vorgabe"
                        });
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TribeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserUuid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TribeId");

                    b.HasIndex("UserUuid");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.ProjectProgrammingLanguages", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProjectId", "ProgrammingLanguageId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("ProjectProgrammingLanguages");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.Tribe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tribes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tribe Alpha"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tribe Chi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tribe Delta"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tribe Gamma"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tribe Iota"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Tribe Lambda"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Tribe My"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tribe Omega"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Tribe Psi"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Tribe Sigma"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Tribe Tau"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Tribe Xi"
                        });
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.Project", b =>
                {
                    b.HasOne("ProjectHub.Data.Abstractions.Entities.Tribe", "Tribe")
                        .WithMany()
                        .HasForeignKey("TribeId");

                    b.HasOne("ProjectHub.Data.Abstractions.Entities.User", "User")
                        .WithMany("CreatedProjects")
                        .HasForeignKey("UserUuid");

                    b.Navigation("Tribe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.ProjectProgrammingLanguages", b =>
                {
                    b.HasOne("ProjectHub.Data.Abstractions.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("ProjectProgrammingLanguages")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectHub.Data.Abstractions.Entities.Project", "Project")
                        .WithMany("projectProgrammingLanguages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguage");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("ProjectProgrammingLanguages");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.Project", b =>
                {
                    b.Navigation("projectProgrammingLanguages");
                });

            modelBuilder.Entity("ProjectHub.Data.Abstractions.Entities.User", b =>
                {
                    b.Navigation("CreatedProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
