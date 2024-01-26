using Microsoft.EntityFrameworkCore;
using WebApplicationTicketsCRUD.Db.Models;
using WebApplicationNotic.Db.Models;

namespace WebApplicationNotic.Db.DbConnector;

public partial class NoticDbContext : DbContext
{
    public NoticDbContext()
    {
    }

    public NoticDbContext(DbContextOptions<NoticDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupsNote> GroupsNotes { get; set; }

    public virtual DbSet<GroupsUser> GroupsUsers { get; set; }

    public virtual DbSet<ImportanciaLevel> ImportanciaLevels { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NoteType> NoteTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersNote> UsersNotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host= 83.147.246.87:5432;Database= notic_db;Username= notic_user;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colors_pk");

            entity.ToTable("colors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(100)
                .HasColumnName("color_hex");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groups_pk");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GroupsNote>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("groups_notes");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.NoteId).HasColumnName("note_id");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groups_notes_groups_id_fk");

            entity.HasOne(d => d.Note).WithMany()
                .HasForeignKey(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groups_notes_notes_id_fk");
        });

        modelBuilder.Entity<GroupsUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("groups_user");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groups_user_groups_id_fk");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groups_user_users_id_fk");
        });

        modelBuilder.Entity<ImportanciaLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("importancia_levels_pk");

            entity.ToTable("importancia_levels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("note_pk");

            entity.ToTable("notes");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('note_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(4096)
                .HasColumnName("description");
            entity.Property(e => e.ImportanciaId).HasColumnName("importancia_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NoteTypeId).HasColumnName("note_type_id");

            entity.HasOne(d => d.Importancia).WithMany(p => p.Notes)
                .HasForeignKey(d => d.ImportanciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("note_importancia_levels_id_fk");

            entity.HasOne(d => d.NoteType).WithMany(p => p.Notes)
                .HasForeignKey(d => d.NoteTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("note_note_type_id_fk");
        });

        modelBuilder.Entity<NoteType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("note_type_pk");

            entity.ToTable("note_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        modelBuilder.Entity<UsersNote>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("users_notes");

            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Note).WithMany()
                .HasForeignKey(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_notes_notes_id_fk");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_notes_users_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
