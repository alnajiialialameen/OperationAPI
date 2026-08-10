using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OperationAPI.Presistence.Models;

public partial class Entities : DbContext
{
    public Entities()
    {
    }

    public Entities(DbContextOptions<Entities> options)
        : base(options)
    {
    }

    public virtual DbSet<AirLine> AirLines { get; set; }

    public virtual DbSet<AirLineAgent> AirLineAgents { get; set; }

    public virtual DbSet<AirLinesFlightTrip> AirLinesFlightTrips { get; set; }

    public virtual DbSet<AirPort> AirPorts { get; set; }

    public virtual DbSet<AircraftRegistration> AircraftRegistrations { get; set; }

    public virtual DbSet<AircraftSize> AircraftSizes { get; set; }

    public virtual DbSet<AircraftType> AircraftTypes { get; set; }

    public virtual DbSet<AireCraftStyIn> AireCraftStyIns { get; set; }

    public virtual DbSet<AireCraftStyInFee> AireCraftStyInFees { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUsers1> AspNetUsers1s { get; set; }

    public virtual DbSet<CompanyInfo> CompanyInfos { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyDetail> CurrencyDetails { get; set; }

    public virtual DbSet<FinalInvoiceNumber> FinalInvoiceNumbers { get; set; }

    public virtual DbSet<FlightNoCore> FlightNoCores { get; set; }

    public virtual DbSet<FlightRcore> FlightRcores { get; set; }

    public virtual DbSet<FormatType> FormatTypes { get; set; }

    public virtual DbSet<FuelCompany> FuelCompanies { get; set; }

    public virtual DbSet<HandlingAgentsCompany> HandlingAgentsCompanies { get; set; }

    public virtual DbSet<LandingCore> LandingCores { get; set; }

    public virtual DbSet<OfficerDatum> OfficerData { get; set; }

    public virtual DbSet<PlaneRcore> PlaneRcores { get; set; }

    public virtual DbSet<PrintFormat> PrintFormats { get; set; }

    public virtual DbSet<RegisterationCore> RegisterationCores { get; set; }

    public virtual DbSet<Revenue> Revenues { get; set; }

    public virtual DbSet<ServiceCarCompany> ServiceCarCompanies { get; set; }

    public virtual DbSet<TowerDatum> TowerData { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<TripType> TripTypes { get; set; }

    public virtual DbSet<ViewFlightNoInsert> ViewFlightNoInserts { get; set; }

    public virtual DbSet<ViewType> ViewTypes { get; set; }

    public virtual DbSet<VwAllAirlinesSumationFee> VwAllAirlinesSumationFees { get; set; }

    public virtual DbSet<VwAllFeesRep> VwAllFeesReps { get; set; }

    public virtual DbSet<VwAllPax> VwAllPaxes { get; set; }

    public virtual DbSet<VwJournalCuppsdome> VwJournalCuppsdomes { get; set; }

    public virtual DbSet<VwJournalCuppsinter> VwJournalCuppsinters { get; set; }

    public virtual DbSet<VwJournalNydome> VwJournalNydomes { get; set; }

    public virtual DbSet<VwJournalNyinter> VwJournalNyinters { get; set; }

    public virtual DbSet<VwJournalPushback> VwJournalPushbacks { get; set; }

    public virtual DbSet<VwTopMaxAirLine> VwTopMaxAirLines { get; set; }

    public virtual DbSet<VwUserRlo> VwUserRloes { get; set; }

    public virtual DbSet<WorkOn> WorkOns { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-2NIRS86\\NAJI;Database=AirPortERP;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_100_CI_AI");

        modelBuilder.Entity<AirLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AireLines");

            entity.ToTable("AirLine");

            entity.HasIndex(e => e.Id, "IX_AirLines").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ArName).HasMaxLength(50);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AirLineAgent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AireLineAgent");

            entity.ToTable("AirLineAgent");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameAn)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameAr)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone1)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone2)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.AirLine).WithMany(p => p.AirLineAgents)
                .HasForeignKey(d => d.AirLineId)
                .HasConstraintName("FK_AirLineAgent_AirLine");
        });

        modelBuilder.Entity<AirLinesFlightTrip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AirLinesFlightTrips");

            entity.ToTable("AirLinesFlightTrip");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.FlightNo)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.AirLine).WithMany(p => p.AirLinesFlightTrips)
                .HasForeignKey(d => d.AirLineId)
                .HasConstraintName("FK_AirLinesFlightTrip_AirLine");

            entity.HasOne(d => d.AirPort).WithMany(p => p.AirLinesFlightTrips)
                .HasForeignKey(d => d.AirPortId)
                .HasConstraintName("FK_AirLinesFlightTrip_AirPort");
        });

        modelBuilder.Entity<AirPort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AirPorts");

            entity.ToTable("AirPort");

            entity.HasIndex(e => e.Id, "IX_AirPorts").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.AirPorts)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_AirPort_Country");
        });

        modelBuilder.Entity<AircraftRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AireCrafiReg");

            entity.ToTable("AircraftRegistration");

            entity.HasIndex(e => e.Id, "IX_AircraftRegistration").IsUnique();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.MaxTakoffWieght).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Registration)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.AircraftType).WithMany(p => p.AircraftRegistrations)
                .HasForeignKey(d => d.AircraftTypeId)
                .HasConstraintName("FK_AircraftRegistration_AircraftType");

            entity.HasOne(d => d.AireLine).WithMany(p => p.AircraftRegistrations)
                .HasForeignKey(d => d.AireLineId)
                .HasConstraintName("FK_AircraftRegistration_AircraftRegistration");
        });

        modelBuilder.Entity<AircraftSize>(entity =>
        {
            entity.ToTable("AircraftSize");

            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<AircraftType>(entity =>
        {
            entity.ToTable("AircraftType");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Size).WithMany(p => p.AircraftTypes)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK_AircraftType_AircraftSize");
        });

        modelBuilder.Entity<AireCraftStyIn>(entity =>
        {
            entity.ToTable("AireCraftStyIn");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.AireCraftReg).WithMany(p => p.AireCraftStyIns)
                .HasForeignKey(d => d.AireCraftRegId)
                .HasConstraintName("FK_AireCraftStyIn_AircraftRegistration");

            entity.HasOne(d => d.AireLine).WithMany(p => p.AireCraftStyIns)
                .HasForeignKey(d => d.AireLineId)
                .HasConstraintName("FK_AireCraftStyIn_AirLine");
        });

        modelBuilder.Entity<AireCraftStyInFee>(entity =>
        {
            entity.Property(e => e.AccountingDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.SettingAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.StayIn).WithMany(p => p.AireCraftStyInFees)
                .HasForeignKey(d => d.StayInId)
                .HasConstraintName("FK_AireCraftStyInFees_AireCraftStyIn");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.ClaimType).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ClaimValue).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ProviderKey)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUsers1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.ToTable("AspNetUsers1");

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PhoneNumber).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.SecurityStamp).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserName)
                .HasMaxLength(256)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUsers1>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserId");
                        j.IndexerProperty<string>("UserId")
                            .HasMaxLength(128)
                            .UseCollation("SQL_Latin1_General_CP1_CI_AS");
                        j.IndexerProperty<string>("RoleId")
                            .HasMaxLength(128)
                            .UseCollation("SQL_Latin1_General_CP1_CI_AS");
                    });
        });

        modelBuilder.Entity<CompanyInfo>(entity =>
        {
            entity.ToTable("CompanyInfo");

            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DomeCuupssupervisor)
                .HasMaxLength(50)
                .HasColumnName("DomeCUUPSSupervisor");
            entity.Property(e => e.DomeNysupervisor)
                .HasMaxLength(50)
                .HasColumnName("DomeNYSupervisor");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstClassSupervisor).HasMaxLength(50);
            entity.Property(e => e.InterCuupssupervisor)
                .HasMaxLength(50)
                .HasColumnName("InterCUUPSSupervisor");
            entity.Property(e => e.InterNysupervisor)
                .HasMaxLength(50)
                .HasColumnName("InterNYSupervisor");
            entity.Property(e => e.LandingSupervisor).HasMaxLength(50);
            entity.Property(e => e.Latitude)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Longitude)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameAr)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameEn)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PushBackSupervisor).HasMaxLength(50);
            entity.Property(e => e.RevenuesManager).HasMaxLength(50);
            entity.Property(e => e.ServiceCarSupervisor).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Countries");

            entity.ToTable("Country");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpadatingDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.ExchangeRateAgainstPrimaryCurrency).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.MajorUnit)
                .HasMaxLength(50)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.MinorUnit)
                .HasMaxLength(50)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .UseCollation("Arabic_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CurrencyDetail>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ExchangeRateAgainstPrimaryCurrency).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Currency).WithMany(p => p.CurrencyDetails)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_CurrencyDetails_Currency");
        });

        modelBuilder.Entity<FinalInvoiceNumber>(entity =>
        {
            entity.ToTable("FinalInvoiceNumber");

            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreationDate).HasMaxLength(128);
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.UpdationDate).HasMaxLength(128);

            entity.HasOne(d => d.AirLine).WithMany(p => p.FinalInvoiceNumbers)
                .HasForeignKey(d => d.AirLineId)
                .HasConstraintName("FK_FinalInvoiceNumber_AirLine");
        });

        modelBuilder.Entity<FlightNoCore>(entity =>
        {
            entity.ToTable("FlightNoCore");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyCode).HasMaxLength(255);
            entity.Property(e => e.FlightNo).HasMaxLength(255);
            entity.Property(e => e.FlightTo).HasMaxLength(255);
        });

        modelBuilder.Entity<FlightRcore>(entity =>
        {
            entity.ToTable("FlightRCore");
        });

        modelBuilder.Entity<FormatType>(entity =>
        {
            entity.ToTable("FormatType");

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<FuelCompany>(entity =>
        {
            entity.ToTable("FuelCompany");

            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.NameEn).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Currency).WithMany(p => p.FuelCompanies)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_FuelCompany_Currency");
        });

        modelBuilder.Entity<HandlingAgentsCompany>(entity =>
        {
            entity.ToTable("HandlingAgentsCompany");

            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NameAr)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameEn)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Currency).WithMany(p => p.HandlingAgentsCompanies)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_HandlingAgentsCompany_Currency");
        });

        modelBuilder.Entity<LandingCore>(entity =>
        {
            entity.ToTable("LandingCore");

            entity.Property(e => e.Ata)
                .HasColumnType("datetime")
                .HasColumnName("ATA");
            entity.Property(e => e.Ata2)
                .HasMaxLength(255)
                .HasColumnName("ATA2");
            entity.Property(e => e.Atd)
                .HasColumnType("datetime")
                .HasColumnName("ATD");
            entity.Property(e => e.Atd2)
                .HasMaxLength(255)
                .HasColumnName("ATD2");
            entity.Property(e => e.CompanyCode).HasMaxLength(255);
            entity.Property(e => e.ExpMainIn).HasColumnName("ExpMainIN");
            entity.Property(e => e.ExpressMailFees).HasColumnName("ExpressMail_Fees");
            entity.Property(e => e.FirstClassFees).HasColumnName("FirstClass_Fees");
            entity.Property(e => e.FlightDate).HasColumnType("datetime");
            entity.Property(e => e.FlightFrom).HasMaxLength(255);
            entity.Property(e => e.FlightNo).HasMaxLength(255);
            entity.Property(e => e.FlightTo).HasMaxLength(255);
            entity.Property(e => e.FlightType).HasMaxLength(255);
            entity.Property(e => e.FreightFees).HasColumnName("Freight_Fees");
            entity.Property(e => e.FreightIn).HasColumnName("Freight_IN");
            entity.Property(e => e.FreightOut).HasColumnName("Freight_Out");
            entity.Property(e => e.LandingFees).HasColumnName("Landing_Fees");
            entity.Property(e => e.MailFees).HasColumnName("Mail_Fees");
            entity.Property(e => e.MailIn).HasColumnName("Mail_IN");
            entity.Property(e => e.MailOut).HasColumnName("Mail_Out");
            entity.Property(e => e.NightSurgarcgeFees).HasColumnName("NightSurgarcge_Fees");
            entity.Property(e => e.ParkingFees).HasColumnName("Parking_Fees");
            entity.Property(e => e.PlaneSizeId)
                .HasMaxLength(255)
                .HasColumnName("PlaneSizeID");
            entity.Property(e => e.PushBackFees).HasColumnName("PushBack_Fees");
            entity.Property(e => e.RegNo).HasMaxLength(255);
            entity.Property(e => e.SecurityFees).HasColumnName("Security_Fees");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserChargeFees).HasColumnName("UserCharge_Fees");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<OfficerDatum>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CrewNo).HasColumnName("CrewNO");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Disemb).HasColumnName("DISEMB");
            entity.Property(e => e.Emb).HasColumnName("EMB");
            entity.Property(e => e.FuelLiter).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.IsNotUsedCupps).HasColumnName("IsNotUsedCUPPS");
            entity.Property(e => e.NormalMailLoadingExp).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NormalMailLoadingImp).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RapidMailLoadingExp).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RapidMailLoadingImp).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Trnone).HasColumnName("TRNone");
            entity.Property(e => e.Trny).HasColumnName("TRNY");
            entity.Property(e => e.Trnycupps).HasColumnName("TRNYCUPPS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.AireLineAgent).WithMany(p => p.OfficerData)
                .HasForeignKey(d => d.AireLineAgentId)
                .HasConstraintName("FK_OfficerData_AirLineAgent");

            entity.HasOne(d => d.FuelCompany).WithMany(p => p.OfficerData)
                .HasForeignKey(d => d.FuelCompanyId)
                .HasConstraintName("FK_OfficerData_FuelCompany");

            entity.HasOne(d => d.HandlingAgent).WithMany(p => p.OfficerData)
                .HasForeignKey(d => d.HandlingAgentId)
                .HasConstraintName("FK_OfficerData_HandlingAgentsCompany");

            entity.HasOne(d => d.TowerData).WithMany(p => p.OfficerData)
                .HasForeignKey(d => d.TowerDataId)
                .HasConstraintName("FK_OfficerData_TowerData");
        });

        modelBuilder.Entity<PlaneRcore>(entity =>
        {
            entity.ToTable("PlaneRCore");

            entity.Property(e => e.PlaneId).HasColumnName("PlaneID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PrintFormat>(entity =>
        {
            entity.ToTable("PrintFormat");

            entity.HasOne(d => d.FormatType).WithMany(p => p.PrintFormats)
                .HasForeignKey(d => d.FormatTypeId)
                .HasConstraintName("FK_PrintFormat_FormatType");
        });

        modelBuilder.Entity<RegisterationCore>(entity =>
        {
            entity.ToTable("RegisterationCore");

            entity.Property(e => e.CompanyCode).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.PlaneSize).HasMaxLength(255);
            entity.Property(e => e.Reg).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Revenue>(entity =>
        {
            entity.ToTable("Revenue");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AmbolanceFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DomeCuppsfees)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DomeCUPPSFees");
            entity.Property(e => e.DomeNyfees)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DomeNYFees");
            entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ExpMailFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FireFightingFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FirstClassFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FreightFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FuelFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.GroundHandlingFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ImpMailFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.InterCuppsfees)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("InterCUPPSFees");
            entity.Property(e => e.InterNyfees)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("InterNYFees");
            entity.Property(e => e.LandingFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.NavigationFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.NightOperationFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.NoiseFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OpenAireportOvertimeFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ParkingFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PushBackFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.SecurityFees).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.CompanyInfo).WithMany(p => p.Revenues)
                .HasForeignKey(d => d.CompanyInfoId)
                .HasConstraintName("FK_Revenue_CompanyInfo");

            entity.HasOne(d => d.OfficerData).WithMany(p => p.Revenues)
                .HasForeignKey(d => d.OfficerDataId)
                .HasConstraintName("FK_Revenue_OfficerData");
        });

        modelBuilder.Entity<ServiceCarCompany>(entity =>
        {
            entity.ToTable("ServiceCarCompany");

            entity.Property(e => e.Address).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.NameAr)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NameEn)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TowerDatum>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ata).HasColumnName("ATA");
            entity.Property(e => e.Atd).HasColumnName("ATD");
            entity.Property(e => e.CompanyInfoId).HasDefaultValue(1);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LandingDate).HasColumnType("datetime");
            entity.Property(e => e.LandingPermission)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Pob).HasColumnName("POB");
            entity.Property(e => e.Qbd).HasColumnName("QBD");
            entity.Property(e => e.TakeOffDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");

            entity.HasOne(d => d.AirLine).WithMany(p => p.TowerData)
                .HasForeignKey(d => d.AirLineId)
                .HasConstraintName("FK_TowerData_AirLine");

            entity.HasOne(d => d.AircraftReg).WithMany(p => p.TowerData)
                .HasForeignKey(d => d.AircraftRegId)
                .HasConstraintName("FK_TowerData_AircraftRegistration");

            entity.HasOne(d => d.AirportIdFromNavigation).WithMany(p => p.TowerDatumAirportIdFromNavigations)
                .HasForeignKey(d => d.AirportIdFrom)
                .HasConstraintName("FK_TowerData_AirPort1");

            entity.HasOne(d => d.AirportIdToNavigation).WithMany(p => p.TowerDatumAirportIdToNavigations)
                .HasForeignKey(d => d.AirportIdTo)
                .HasConstraintName("FK_TowerData_AirPort");

            entity.HasOne(d => d.CompanyInfo).WithMany(p => p.TowerData)
                .HasForeignKey(d => d.CompanyInfoId)
                .HasConstraintName("FK_TowerData_CompanyInfo");

            entity.HasOne(d => d.FlightNoNavigation).WithMany(p => p.TowerData)
                .HasForeignKey(d => d.FlightNo)
                .HasConstraintName("FK_TowerData_AireLinesFlightTrip");

            entity.HasOne(d => d.TripType).WithMany(p => p.TowerData)
                .HasForeignKey(d => d.TripTypeId)
                .HasConstraintName("FK_TowerData_TripType");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.ToTable("TransactionLog");

            entity.Property(e => e.IsComplate).HasDefaultValue(false);
        });

        modelBuilder.Entity<TripType>(entity =>
        {
            entity.ToTable("TripType");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UpdatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ViewFlightNoInsert>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_FlightNoInsert");

            entity.Property(e => e.CompanyCode).HasMaxLength(255);
            entity.Property(e => e.FlightNo).HasMaxLength(255);
            entity.Property(e => e.FlightTo).HasMaxLength(255);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<ViewType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_Types");

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<VwAllAirlinesSumationFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwAllAirlinesSumationFees");

            entity.Property(e => e.AmbolanceFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.DomeCuppsfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("DomeCUPPSFees");
            entity.Property(e => e.DomeNyfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("DomeNYFees");
            entity.Property(e => e.ExpMailFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.FireFightingFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.FirstClassFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.FreightFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.ImpMailFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.InterCuppsfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("InterCUPPSFees");
            entity.Property(e => e.InterNyfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("InterNYFees");
            entity.Property(e => e.LandingDate).HasColumnType("datetime");
            entity.Property(e => e.LandingFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NavigationFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.NightOperationFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.NoiseFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.ParkingFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.PushBackFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.RevenueStamp).HasColumnType("numeric(38, 6)");
            entity.Property(e => e.SecurityFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.TotalFees).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwAllFeesRep>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwAllFeesRep");

            entity.Property(e => e.AmbolanceFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.DomeCuppsfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("DomeCUPPSFees");
            entity.Property(e => e.DomeNyfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("DomeNYFees");
            entity.Property(e => e.ExpMailFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.FireFightingFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.FirstClassFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.FreightFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.ImpMailFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.InterCuppsfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("InterCUPPSFees");
            entity.Property(e => e.InterNyfees)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("InterNYFees");
            entity.Property(e => e.LandingDate).HasColumnType("datetime");
            entity.Property(e => e.LandingFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.NavigationFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.NightOperationFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.NoiseFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.OpenAireportOvertimeFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.ParkingFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.PushBackFees).HasColumnType("decimal(38, 4)");
            entity.Property(e => e.SecurityFees).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwAllPax>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwAllPax");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TotalPax).HasColumnName("total Pax");
        });

        modelBuilder.Entity<VwJournalCuppsdome>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwJournalCUPPSDome");

            entity.Property(e => e.Total).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwJournalCuppsinter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwJournalCUPPSInter");

            entity.Property(e => e.Total).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwJournalNydome>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwJournalNYDome");

            entity.Property(e => e.Total).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwJournalNyinter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwJournalNYInter");

            entity.Property(e => e.Total).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwJournalPushback>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwJournalPushback");

            entity.Property(e => e.Total).HasColumnType("decimal(38, 4)");
        });

        modelBuilder.Entity<VwTopMaxAirLine>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTopMaxAirLine");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<VwUserRlo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwUserRloes");

            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PasswordHash).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.RoleName)
                .HasMaxLength(256)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.UserName)
                .HasMaxLength(256)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<WorkOn>(entity =>
        {
            entity.ToTable("WorkOn");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.CompanyInfo).WithMany(p => p.WorkOns)
                .HasForeignKey(d => d.CompanyInfoId)
                .HasConstraintName("FK_WorkOn_CompanyInfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
