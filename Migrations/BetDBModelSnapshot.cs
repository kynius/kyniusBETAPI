﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kyniusBETAPI.Data;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    [DbContext(typeof(BetDB))]
    partial class BetDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("kyniusBETAPI.Model.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("League");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.LeagueUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("UserId");

                    b.ToTable("LeagueUser");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.FootballLeague", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "country");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "flag");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "logo");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("FootballLeague");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Goals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Away")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "away");

                    b.Property<int?>("Home")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "home");

                    b.HasKey("Id");

                    b.ToTable("Goals");

                    b.HasAnnotation("Relational:JsonPropertyName", "penalty");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiId")
                        .HasColumnType("int");

                    b.Property<int?>("AwayId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FootballLeagueId")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsId")
                        .HasColumnType("int");

                    b.Property<int?>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("Referee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScoreId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("Timestamp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayId");

                    b.HasIndex("FootballLeagueId");

                    b.HasIndex("GoalsId");

                    b.HasIndex("HomeId");

                    b.HasIndex("ScoreId");

                    b.HasIndex("StatusId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExtratimeId")
                        .HasColumnType("int");

                    b.Property<int?>("FulltimeId")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsInFirsthalfId")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsInSecondhalfId")
                        .HasColumnType("int");

                    b.Property<int?>("HalftimeId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAwayWinnerFirstHalf")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAwayWinnerFullMatch")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAwayWinnerSecondHalf")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsHomeWinnerFirstHalf")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsHomeWinnerFullMatch")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsHomeWinnerSecondHalf")
                        .HasColumnType("bit");

                    b.Property<int?>("PenaltyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExtratimeId");

                    b.HasIndex("FulltimeId");

                    b.HasIndex("GoalsInFirsthalfId");

                    b.HasIndex("GoalsInSecondhalfId");

                    b.HasIndex("HalftimeId");

                    b.HasIndex("PenaltyId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Elapsed")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "elapsed");

                    b.Property<string>("Long")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "long");

                    b.Property<string>("Short")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "short");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "logo");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AvatarImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("kyniusBETAPI.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("kyniusBETAPI.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kyniusBETAPI.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("kyniusBETAPI.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("kyniusBETAPI.Model.LeagueUser", b =>
                {
                    b.HasOne("kyniusBETAPI.Model.League", "League")
                        .WithMany("LeagueUser")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kyniusBETAPI.Model.User", "User")
                        .WithMany("LeagueUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("User");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Match", b =>
                {
                    b.HasOne("kyniusBETAPI.Model.Match.Team", "Away")
                        .WithMany()
                        .HasForeignKey("AwayId");

                    b.HasOne("kyniusBETAPI.Model.Match.FootballLeague", "FootballLeague")
                        .WithMany()
                        .HasForeignKey("FootballLeagueId");

                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "Goals")
                        .WithMany()
                        .HasForeignKey("GoalsId");

                    b.HasOne("kyniusBETAPI.Model.Match.Team", "Home")
                        .WithMany()
                        .HasForeignKey("HomeId");

                    b.HasOne("kyniusBETAPI.Model.Match.Score", "Score")
                        .WithMany()
                        .HasForeignKey("ScoreId");

                    b.HasOne("kyniusBETAPI.Model.Match.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Away");

                    b.Navigation("FootballLeague");

                    b.Navigation("Goals");

                    b.Navigation("Home");

                    b.Navigation("Score");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.Match.Score", b =>
                {
                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "Extratime")
                        .WithMany()
                        .HasForeignKey("ExtratimeId");

                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "Fulltime")
                        .WithMany()
                        .HasForeignKey("FulltimeId");

                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "GoalsInFirsthalf")
                        .WithMany()
                        .HasForeignKey("GoalsInFirsthalfId");

                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "GoalsInSecondhalf")
                        .WithMany()
                        .HasForeignKey("GoalsInSecondhalfId");

                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "Halftime")
                        .WithMany()
                        .HasForeignKey("HalftimeId");

                    b.HasOne("kyniusBETAPI.Model.Match.Goals", "Penalty")
                        .WithMany()
                        .HasForeignKey("PenaltyId");

                    b.Navigation("Extratime");

                    b.Navigation("Fulltime");

                    b.Navigation("GoalsInFirsthalf");

                    b.Navigation("GoalsInSecondhalf");

                    b.Navigation("Halftime");

                    b.Navigation("Penalty");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.League", b =>
                {
                    b.Navigation("LeagueUser");
                });

            modelBuilder.Entity("kyniusBETAPI.Model.User", b =>
                {
                    b.Navigation("LeagueUser");
                });
#pragma warning restore 612, 618
        }
    }
}
