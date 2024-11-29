using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemasDeRegistros.Models;

public partial class DbControlAsistenciaEscolarContext : DbContext
{
    public DbControlAsistenciaEscolarContext()
    {
    }

    public DbControlAsistenciaEscolarContext(DbContextOptions<DbControlAsistenciaEscolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnoApoderado> AlumnoApoderados { get; set; }

    public virtual DbSet<Apoderado> Apoderados { get; set; }

    public virtual DbSet<Asistencium> Asistencia { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ConfiguracionSistema> ConfiguracionSistemas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Justificacion> Justificacions { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<NivelEducativo> NivelEducativos { get; set; }

    public virtual DbSet<PeriodoAcademico> PeriodoAcademicos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Seccion> Seccions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=DB_ControlAsistenciaEscolar;Trusted_Connection=true;User Id= 'MSI/Carmen';Password= '';TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__ALUMNO__460B47400EE4FF64");

            entity.ToTable("ALUMNO");

            entity.HasIndex(e => e.Codigo, "UQ__ALUMNO__06370DACF9B47EB4").IsUnique();

            entity.HasIndex(e => e.Dni, "UQ__ALUMNO__C035B8DD02316C7A").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.EstadoAcademico)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__ALUMNO__IdUsuari__73BA3083");
        });

        modelBuilder.Entity<AlumnoApoderado>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoApoderado).HasName("PK__ALUMNO_A__33A2F15D8B95C226");

            entity.ToTable("ALUMNO_APODERADO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.EsPrincipal).HasDefaultValue(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnoApoderados)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__ALUMNO_AP__IdAlu__7E37BEF6");

            entity.HasOne(d => d.IdApoderadoNavigation).WithMany(p => p.AlumnoApoderados)
                .HasForeignKey(d => d.IdApoderado)
                .HasConstraintName("FK__ALUMNO_AP__IdApo__7F2BE32F");
        });

        modelBuilder.Entity<Apoderado>(entity =>
        {
            entity.HasKey(e => e.IdApoderado).HasName("PK__APODERAD__6A9DEDFCB5DBAB11");

            entity.ToTable("APODERADO");

            entity.HasIndex(e => e.Dni, "UQ__APODERAD__C035B8DDDAB4469E").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Parentesco)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Asistencium>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PK__ASISTENC__3956DEE69594B768");

            entity.ToTable("ASISTENCIA");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.EstadoAsistencia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK__ASISTENCI__IdHor__1BC821DD");

            entity.HasOne(d => d.IdMatriculaNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdMatricula)
                .HasConstraintName("FK__ASISTENCI__IdMat__1AD3FDA4");

            entity.HasOne(d => d.RegistradoPorNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.RegistradoPor)
                .HasConstraintName("FK__ASISTENCI__Regis__1DB06A4F");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PK__AULA__2C89573C66F3BA37");

            entity.ToTable("AULA");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Icon).HasMaxLength(5);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(10);
        });

        modelBuilder.Entity<ConfiguracionSistema>(entity =>
        {
            entity.HasKey(e => e.IdConfiguracion).HasName("PK__CONFIGUR__F6E145D0B6A13D03");

            entity.ToTable("CONFIGURACION_SISTEMA");

            entity.HasIndex(e => e.Clave, "UQ__CONFIGUR__E8181E1198D8EF41").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Valor)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__CURSO__085F27D6F43F6BBB");

            entity.ToTable("CURSO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__DOCENTE__64A8726EE2960A48");

            entity.ToTable("DOCENTE");

            entity.HasIndex(e => e.Codigo, "UQ__DOCENTE__06370DAC24D684BC").IsUnique();

            entity.HasIndex(e => e.Dni, "UQ__DOCENTE__C035B8DDE62FF105").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__DOCENTE__IdUsuar__6D0D32F4");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.IdGrado).HasName("PK__GRADO__393DFCB864F245F5");

            entity.ToTable("GRADO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNivelEducativoNavigation).WithMany(p => p.Grados)
                .HasForeignKey(d => d.IdNivelEducativo)
                .HasConstraintName("FK__GRADO__IdNivelEd__5EBF139D");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__HORARIO__1539229B9C80E637");

            entity.ToTable("HORARIO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DiaSemana)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdAulaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdAula)
                .HasConstraintName("FK__HORARIO__IdAula__0D7A0286");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__HORARIO__IdCurso__0B91BA14");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("FK__HORARIO__IdDocen__0C85DE4D");

            entity.HasOne(d => d.IdGradoNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdGrado)
                .HasConstraintName("FK__HORARIO__IdGrado__09A971A2");

            entity.HasOne(d => d.IdPeriodoAcademicoNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdPeriodoAcademico)
                .HasConstraintName("FK__HORARIO__IdPerio__08B54D69");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK__HORARIO__IdSecci__0A9D95DB");
        });

        modelBuilder.Entity<Justificacion>(entity =>
        {
            entity.HasKey(e => e.IdJustificacion).HasName("PK__JUSTIFIC__D77EE98C3C8B43ED");

            entity.ToTable("JUSTIFICACION");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.DocumentoAdjunto)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EstadoAprobacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MotivoJustificacion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AprobadoPorNavigation).WithMany(p => p.Justificacions)
                .HasForeignKey(d => d.AprobadoPor)
                .HasConstraintName("FK__JUSTIFICA__Aprob__245D67DE");

            entity.HasOne(d => d.IdAsistenciaNavigation).WithMany(p => p.Justificacions)
                .HasForeignKey(d => d.IdAsistencia)
                .HasConstraintName("FK__JUSTIFICA__IdAsi__22751F6C");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula).HasName("PK__MATRICUL__AD06C20FD58C6FB9");

            entity.ToTable("MATRICULA");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__MATRICULA__IdAlu__123EB7A3");

            entity.HasOne(d => d.IdGradoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdGrado)
                .HasConstraintName("FK__MATRICULA__IdGra__14270015");

            entity.HasOne(d => d.IdPeriodoAcademicoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdPeriodoAcademico)
                .HasConstraintName("FK__MATRICULA__IdPer__1332DBDC");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK__MATRICULA__IdSec__151B244E");
        });

        modelBuilder.Entity<NivelEducativo>(entity =>
        {
            entity.HasKey(e => e.IdNivelEducativo).HasName("PK__NIVEL_ED__5035CA163E4F3611");

            entity.ToTable("NIVEL_EDUCATIVO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PeriodoAcademico>(entity =>
        {
            entity.HasKey(e => e.IdPeriodoAcademico).HasName("PK__PERIODO___E57AB3874610744B");

            entity.ToTable("PERIODO_ACADEMICO");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__2A49584C5172249B");

            entity.ToTable("ROL");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__SECCION__CD2B049F6EAEFCF4");

            entity.ToTable("SECCION");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Transactions_CategoryId");

            entity.Property(e => e.Note).HasMaxLength(75);

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97C6C119CB");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.NombreUsuario, "UQ__USUARIO__6B0F5AE0E0FC79ED").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__USUARIO__A9D105341FC98E27").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CuentaBloqueada).HasDefaultValue(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IntentosAccesoFallidos).HasDefaultValue(0);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__USUARIO__IdRol__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
