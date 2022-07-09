using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Parking.Server.Infrastructure.Models.DtoModels;
using Parking.Server.Infrastructure.SeedWork;

namespace Parking.Server.Infrastructure.Models
{
    //public partial class parkingInfoContext : DbContext, IUnitOfWork
    public partial class parkingInfoContext : DbContext
    {

        #region DbSet Stored Procedure 연결위해 분리
        public DbSet<SPCodeList> SPCodeLists { get; set; }
        public DbSet<ProcedureDefaultDto> SPCodeMasterInserts { get; set; }
        #endregion


        public parkingInfoContext()
        {
        }

        public parkingInfoContext(DbContextOptions<parkingInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuditLog> TAuditLogs { get; set; }
        public virtual DbSet<TCode> TCodes { get; set; }
        public virtual DbSet<TCodeMaster> TCodeMasters { get; set; }
        public virtual DbSet<TManagerMember> TManagerMembers { get; set; }
        public virtual DbSet<TMemberManagerRole> TMemberManagerRoles { get; set; }
        public virtual DbSet<TParkingDeviceInfo> TParkingDeviceInfos { get; set; }
        public virtual DbSet<TParkingLotBasicInfo> TParkingLotBasicInfos { get; set; }
        public virtual DbSet<TParkingTicketInfo> TParkingTicketInfos { get; set; }
        public virtual DbSet<TSiteConfig> TSiteConfigs { get; set; }
        public virtual DbSet<TTicketRefImage> TTicketRefImages { get; set; }

        
        #region ## UnitOfWork

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntitiesWithMessagingAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        } 
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=221.143.42.175,1435;Database=ParkingIntegratedControlCenter;user id=sa;password=eoqkrskwk2);Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuditLog>(entity =>
            {
                entity.HasKey(e => e.AIdx);

                entity.ToTable("T_AuditLog");

                entity.HasIndex(e => e.AIdx)
                    .HasName("IX_T_AuditLog_UserUd");

                entity.Property(e => e.AIdx).HasColumnName("aIdx");

                entity.Property(e => e.DataModifyDate).HasColumnType("datetime");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventSource).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasMaxLength(100);

                entity.Property(e => e.UserIpAddr).HasMaxLength(50);
            });

            modelBuilder.Entity<TCode>(entity =>
            {
                entity.HasKey(e => e.CdIdx)
                    .HasName("PK_T_CODE");

                entity.ToTable("T_Code");

                entity.Property(e => e.CdIdx).HasColumnName("CD_IDX");

                entity.Property(e => e.CdCd)
                    .HasColumnName("CD_CD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CdNm)
                    .HasColumnName("CD_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CdUseYn)
                    .IsRequired()
                    .HasColumnName("CD_USE_YN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmCd)
                    .HasColumnName("CM_CD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayOrder)
                    .HasColumnName("displayOrder")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TCodeMaster>(entity =>
            {
                entity.HasKey(e => e.CmCd)
                    .HasName("PK_T_CODE_MASTER");

                entity.ToTable("T_CodeMaster");

                entity.Property(e => e.CmCd)
                    .HasColumnName("CM_CD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CmNm)
                    .HasColumnName("CM_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CmUseYn)
                    .IsRequired()
                    .HasColumnName("CM_USE_YN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FNm)
                    .HasColumnName("F_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TNm)
                    .HasColumnName("T_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TManagerMember>(entity =>
            {
                entity.HasKey(e => e.UIdx);

                entity.ToTable("T_ManagerMember");

                entity.HasIndex(e => e.EmpId)
                    .HasName("IX_T_ManagerMember_Id");

                entity.HasIndex(e => e.IsActive)
                    .HasName("IX_T_ManagerMember_isActive");

                entity.Property(e => e.UIdx)
                    .HasColumnName("uIdx")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataModDate).HasColumnType("datetime");

                entity.Property(e => e.DataRegDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.EmpNo).HasMaxLength(50);

                entity.Property(e => e.EmpPwd).HasMaxLength(100);

                entity.Property(e => e.Etc).HasMaxLength(1000);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TMemberManagerRole>(entity =>
            {
                entity.HasKey(e => e.Ridx);

                entity.ToTable("T_MemberManagerRole");

                entity.HasIndex(e => e.EmpId);

                entity.Property(e => e.Ridx)
                    .HasColumnName("RIdx")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataRegDate).HasColumnType("datetime");

                entity.Property(e => e.EmpId).HasMaxLength(50);

                entity.Property(e => e.MemberRole).HasMaxLength(100);
            });

            modelBuilder.Entity<TParkingDeviceInfo>(entity =>
            {
                entity.HasKey(e => e.DIdx);

                entity.ToTable("T_ParkingDeviceInfo");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("IX_T_ParkingDeviceInfo_DeviceId")
                    .IsUnique();

                entity.HasIndex(e => e.Plcode)
                    .HasName("IX_T_ParkingDeviceInfo_plCode");

                entity.Property(e => e.DIdx)
                    .HasColumnName("dIdx")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataModDate).HasColumnType("datetime");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceDescription).HasMaxLength(1000);

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("DeviceID")
                    .HasMaxLength(100);

                entity.Property(e => e.DeviceIpAddr).HasMaxLength(50);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Etc).HasMaxLength(500);

                entity.Property(e => e.HealthStatus).HasMaxLength(50);

                entity.Property(e => e.IsHealthCheck).HasDefaultValueSql("((0))");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(100);

                entity.HasOne(d => d.PlcodeNavigation)
                    .WithMany(p => p.TParkingDeviceInfo)
                    .HasPrincipalKey(p => p.Plcode)
                    .HasForeignKey(d => d.Plcode)
                    .HasConstraintName("FK_T_ParkingDeviceInfo_T_ParkingLotBasicInfo");
            });

            modelBuilder.Entity<TParkingLotBasicInfo>(entity =>
            {
                entity.HasKey(e => e.PIdx);

                entity.ToTable("T_ParkingLotBasicInfo");

                entity.HasIndex(e => e.Plcode)
                    .HasName("IX_T_ParkingLotBasicInfo_Code")
                    .IsUnique();

                entity.Property(e => e.PIdx).HasColumnName("pIdx");

                entity.Property(e => e.Pladdress)
                    .HasColumnName("PLAddress")
                    .HasMaxLength(300);

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(100);

                entity.Property(e => e.PlencKey)
                    .HasColumnName("PLEncKey")
                    .HasMaxLength(100);

                entity.Property(e => e.PlisActive).HasColumnName("PLIsActive");

                entity.Property(e => e.PlmodDate)
                    .HasColumnName("PLModDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlregDate)
                    .HasColumnName("PLRegDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PlregEmpId)
                    .HasColumnName("PLRegEmpId")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TParkingTicketInfo>(entity =>
            {
                entity.HasKey(e => e.PIdx);

                entity.ToTable("T_ParkingTicketInfo");

                entity.HasIndex(e => e.CarDisplayNo)
                    .HasName("IX_T_ParkingTicketInfo_carDisplayNo");

                entity.HasIndex(e => e.TicketNo)
                    .IsUnique();

                entity.Property(e => e.PIdx).HasColumnName("pIdx");

                entity.Property(e => e.CarDisplayNo).HasMaxLength(50);

                entity.Property(e => e.DiscountPrice).HasColumnName("DIscountPrice");

                entity.Property(e => e.ImgPath).HasMaxLength(100);

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(100);

                entity.Property(e => e.TicketCloseDate).HasColumnType("datetime");

                entity.Property(e => e.TicketNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TicketOpenDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PlcodeNavigation)
                    .WithMany(p => p.TParkingTicketInfo)
                    .HasPrincipalKey(p => p.Plcode)
                    .HasForeignKey(d => d.Plcode)
                    .HasConstraintName("FK_T_ParkingTicketInfo_T_ParkingLotBasicInfo");
            });

            modelBuilder.Entity<TSiteConfig>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("T_SiteConfig");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(100);

                entity.Property(e => e.AddDescription)
                    .HasColumnName("addDescription")
                    .HasColumnType("text");

                entity.Property(e => e.AddValue1)
                    .HasColumnName("addValue1")
                    .HasMaxLength(10);

                entity.Property(e => e.AddValue2)
                    .HasColumnName("addValue2")
                    .HasMaxLength(10);

                entity.Property(e => e.Controller)
                    .HasColumnName("controller")
                    .HasMaxLength(100);

                entity.Property(e => e.Decription)
                    .HasColumnName("decription")
                    .HasColumnType("text");

                entity.Property(e => e.Moddt)
                    .HasColumnName("moddt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Regdt)
                    .HasColumnName("regdt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Site)
                    .HasColumnName("site")
                    .HasMaxLength(100);

                entity.Property(e => e.Useyn).HasColumnName("useyn");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TTicketRefImage>(entity =>
            {
                entity.HasKey(e => e.RIdx);

                entity.ToTable("T_TicketRefImage");

                entity.HasIndex(e => e.TicketNo)
                    .HasName("IX_T_TicketRefImage_ticketNo");

                entity.Property(e => e.RIdx).HasColumnName("rIdx");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Etc).HasMaxLength(200);

                entity.Property(e => e.ImgFileName).HasMaxLength(100);

                entity.Property(e => e.ImgFilePath)
                    .HasColumnName("imgFilePath")
                    .HasMaxLength(100);

                entity.Property(e => e.Plcode)
                    .HasColumnName("PLCode")
                    .HasMaxLength(100);

                entity.Property(e => e.Ptype)
                    .HasColumnName("PType")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.TicketNo).HasMaxLength(50);

                entity.HasOne(d => d.PlcodeNavigation)
                    .WithMany(p => p.TTicketRefImage)
                    .HasPrincipalKey(p => p.Plcode)
                    .HasForeignKey(d => d.Plcode)
                    .HasConstraintName("FK_T_TicketRefImage_T_ParkingLotBasicInfo");

                entity.HasOne(d => d.TicketNoNavigation)
                    .WithMany(p => p.TTicketRefImage)
                    .HasPrincipalKey(p => p.TicketNo)
                    .HasForeignKey(d => d.TicketNo)
                    .HasConstraintName("FK_T_TicketRefImage_T_ParkingTicketInfo");
            });



            this.AddModelBuilder(modelBuilder);
            OnModelCreatingPartial(modelBuilder);

        }

        private void AddModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SPCodeList>().HasNoKey();
            modelBuilder.Entity<ProcedureDefaultDto>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region ## transaction
        private IDbContextTransaction _transaction;

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        } 
        #endregion
    }
}
