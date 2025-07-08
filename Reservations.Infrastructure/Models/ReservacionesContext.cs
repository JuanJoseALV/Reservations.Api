using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reservations.Infrastructure.Models;

public partial class ReservacionesContext : DbContext
{
    public ReservacionesContext()
    {
    }

    public ReservacionesContext(DbContextOptions<ReservacionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Binnacle> Binnacles { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Binnacle>(entity =>
        {
            entity.HasKey(e => e.BinnacleId).HasName("PK__Binnacle__C5F9D9417ECCCA85");

            entity.ToTable("Binnacle");

            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("Action_Date");
            entity.Property(e => e.ActionPerformed)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Action_Performed");

            entity.HasOne(d => d.Person).WithMany(p => p.Binnacles)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Binnacle__Person__2F10007B");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__46023BDFEB7888E0");

            entity.ToTable("Hotel");

            entity.Property(e => e.HotelDirection)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Hotel_Direction");
            entity.Property(e => e.HotelName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Hotel_Name");
            entity.Property(e => e.HotelNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Hotel_Number");
            entity.Property(e => e.PriceForAdult)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("Price_For_Adult");
            entity.Property(e => e.PriceForKids)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("Price_For_Kids");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Personas__AA2FFBE5BAF73F40");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Employee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PasswordEmail)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Password_Email");
            entity.Property(e => e.StatePerson)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("State_Person");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F24FC3A1959");

            entity.ToTable("Reservation");

            entity.Property(e => e.AdultsNumber).HasColumnName("Adults_Number");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepartureDate)
                .HasColumnType("datetime")
                .HasColumnName("Departure_Date");
            entity.Property(e => e.EntryDate)
                .HasColumnType("datetime")
                .HasColumnName("Entry_Date");
            entity.Property(e => e.KidsNumber).HasColumnName("Kids_Number");
            entity.Property(e => e.PriceForAdult)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("Price_For_Adult");
            entity.Property(e => e.PriceForKid)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("Price_For_kid");
            entity.Property(e => e.ReservationState)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Reservation_State");
            entity.Property(e => e.TotalDaysReservation).HasColumnName("Total_Days_Reservation");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("Total_Price");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_Date");

            entity.HasOne(d => d.Person).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Perso__2B3F6F97");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__RoomI__2C3393D0");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__32863939B2F956BA");

            entity.Property(e => e.RoomCapacity).HasColumnName("Room_Capacity");
            entity.Property(e => e.RoomDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Room_Description");
            entity.Property(e => e.RoomNumber).HasColumnName("Room_Number");
            entity.Property(e => e.RoomState)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Room_State");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rooms__HotelId__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
