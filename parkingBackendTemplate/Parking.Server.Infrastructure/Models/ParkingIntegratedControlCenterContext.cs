using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Parking.Server.Infrastructure.Models
{
    public partial class ParkingIntegratedControlCenterContext : DbContext
    {
        public ParkingIntegratedControlCenterContext()
        {
        }

        public ParkingIntegratedControlCenterContext(DbContextOptions<ParkingIntegratedControlCenterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuditLog> TAuditLogs { get; set; }
        public virtual DbSet<TBoard> TBoards { get; set; }
        public virtual DbSet<TBoardAttachmentFile> TBoardAttachmentFiles { get; set; }
        public virtual DbSet<TCode> TCodes { get; set; }
        public virtual DbSet<TCodeMaster> TCodeMasters { get; set; }
        public virtual DbSet<TDiscountInfo> TDiscountInfos { get; set; }
        public virtual DbSet<TManagerMember> TManagerMembers { get; set; }
        public virtual DbSet<TMessageSendLog> TMessageSendLogs { get; set; }
        public virtual DbSet<TMessageTemplate> TMessageTemplates { get; set; }
        public virtual DbSet<TParkingDeviceInfo> TParkingDeviceInfos { get; set; }
        public virtual DbSet<TParkingLotBasicInfo> TParkingLotBasicInfos { get; set; }
        public virtual DbSet<TParkingMonitoringAlert> TParkingMonitoringAlerts { get; set; }
        public virtual DbSet<TParkingMonitoringLog> TParkingMonitoringLogs { get; set; }
        public virtual DbSet<TParkingSeasonTicket> TParkingSeasonTickets { get; set; }
        public virtual DbSet<TParkingTicketInfo> TParkingTicketInfos { get; set; }
        public virtual DbSet<TParkingTicketPginfo> TParkingTicketPginfos { get; set; }
        public virtual DbSet<TParkingTicketUseDiscount> TParkingTicketUseDiscounts { get; set; }
        public virtual DbSet<TParkingUncollectedCharge> TParkingUncollectedCharges { get; set; }
        public virtual DbSet<TSiteConfig> TSiteConfigs { get; set; }
        public virtual DbSet<TUserCarDocumentInfo> TUserCarDocumentInfos { get; set; }
        public virtual DbSet<TUserCarInfo> TUserCarInfos { get; set; }
        public virtual DbSet<TUserInfo> TUserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1535;Database=ParkingIntegratedControlCenter;user id=users;password=userpasswdTrusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuditLog>(entity =>
            {
                entity.HasKey(e => e.AIdx)
                    .HasName("PK_T_AUDITLOG");

                entity.ToTable("T_AuditLog");

                entity.HasComment("감사로그");

                entity.HasIndex(e => e.EmpId)
                    .HasName("T_AuditLog_Index_1");

                entity.HasIndex(e => e.EventSorce)
                    .HasName("T_AuditLog_Index_2");

                entity.Property(e => e.AIdx)
                    .HasColumnName("aIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.ContextSource).HasComment("변경데이타");

                entity.Property(e => e.DataModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("생성일");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasComment("직원ID");

                entity.Property(e => e.EventSorce)
                    .HasMaxLength(1000)
                    .HasComment("변경이벤트");

                entity.Property(e => e.UserIpAddr)
                    .HasMaxLength(50)
                    .HasComment("접근IP");
            });

            modelBuilder.Entity<TBoard>(entity =>
            {
                entity.HasKey(e => e.BoardNo)
                    .HasName("PK_T_BOARD");

                entity.ToTable("T_Board");

                entity.HasComment("게시판");

                entity.Property(e => e.BoardNo).HasComment("게시글번호");

                entity.Property(e => e.BoardCategory)
                    .HasMaxLength(50)
                    .HasComment("카테고리코드");

                entity.Property(e => e.BoardDepth).HasComment("Depth");

                entity.Property(e => e.BoardGroupCode)
                    .HasMaxLength(50)
                    .HasComment("게시판종류");

                entity.Property(e => e.BoardSeq).HasComment("원글번호");

                entity.Property(e => e.Contents).HasComment("내용");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.HitCnt).HasComment("조회수");

                entity.Property(e => e.IsNotice).HasComment("공지여부");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");

                entity.Property(e => e.RegUserIp)
                    .HasMaxLength(20)
                    .HasComment("등록IP");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .HasComment("제목");
            });

            modelBuilder.Entity<TBoardAttachmentFile>(entity =>
            {
                entity.HasKey(e => e.AIdx)
                    .HasName("PK_T_BOARDATTACHMENTFILE");

                entity.ToTable("T_BoardAttachmentFile");

                entity.HasComment("첨부파일");

                entity.Property(e => e.AIdx)
                    .HasColumnName("aIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.BoardNo).HasComment("게시글번호");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DownloadCount).HasComment("다운로드카운트");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("파일명");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("파일경로");

                entity.Property(e => e.FileSize).HasComment("파일사이즈");

                entity.HasOne(d => d.BoardNoNavigation)
                    .WithMany(p => p.TBoardAttachmentFile)
                    .HasForeignKey(d => d.BoardNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_BoardAttachmentFile_BoardNo_T_Board_BoardNo");
            });

            modelBuilder.Entity<TCode>(entity =>
            {
                entity.HasKey(e => new { e.CmCd, e.CdCd })
                    .HasName("PK_T_CODE");

                entity.ToTable("T_Code");

                entity.HasComment("서브코드");

                entity.HasIndex(e => e.CdCd)
                    .HasName("T_Code_Index_2");

                entity.HasIndex(e => e.CdUseYn)
                    .HasName("T_Code_Index_3");

                entity.HasIndex(e => e.CmCd)
                    .HasName("T_Code_Index_1");

                entity.Property(e => e.CmCd)
                    .HasColumnName("CM_CD")
                    .HasMaxLength(50)
                    .HasComment("마스터코드");

                entity.Property(e => e.CdCd)
                    .HasColumnName("CD_CD")
                    .HasMaxLength(50)
                    .HasComment("서브 코드");

                entity.Property(e => e.CdIdx)
                    .HasColumnName("CD_IDX")
                    .HasComment("시퀀스")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CdNm)
                    .HasColumnName("CD_NM")
                    .HasMaxLength(50)
                    .HasComment("서브코드명");

                entity.Property(e => e.CdUseYn)
                    .HasColumnName("CD_USE_YN")
                    .HasComment("사용여부");

                entity.Property(e => e.DisplayOrder).HasComment("노출순서");

                entity.HasOne(d => d.CmCdNavigation)
                    .WithMany(p => p.TCode)
                    .HasForeignKey(d => d.CmCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Code_CM_CD_T_CodeMaster_CM_CD");
            });

            modelBuilder.Entity<TCodeMaster>(entity =>
            {
                entity.HasKey(e => e.CmCd)
                    .HasName("PK_T_CODEMASTER");

                entity.ToTable("T_CodeMaster");

                entity.HasComment("마스터코드");

                entity.Property(e => e.CmCd)
                    .HasColumnName("CM_CD")
                    .HasMaxLength(50)
                    .HasComment("마스터코드");

                entity.Property(e => e.CmNm)
                    .HasColumnName("CM_NM")
                    .HasMaxLength(50)
                    .HasComment("마스터코드명");

                entity.Property(e => e.CmUseYn)
                    .IsRequired()
                    .HasColumnName("CM_USE_YN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("사용여부");

                entity.Property(e => e.FNm)
                    .HasColumnName("F_NM")
                    .HasMaxLength(50)
                    .HasComment("F_NM");

                entity.Property(e => e.TNm)
                    .HasColumnName("T_NM")
                    .HasMaxLength(50)
                    .HasComment("T_NM");
            });

            modelBuilder.Entity<TDiscountInfo>(entity =>
            {
                entity.HasKey(e => e.DiscountCd)
                    .HasName("PK_T_DISCOUNTINFO");

                entity.ToTable("T_DiscountInfo");

                entity.HasComment("할인코드 정보");

                entity.HasIndex(e => e.DIdx)
                    .HasName("UC_dIdx")
                    .IsUnique();

                entity.HasIndex(e => e.DiscountCd)
                    .HasName("UC_DiscountCD")
                    .IsUnique();

                entity.Property(e => e.DiscountCd)
                    .HasColumnName("DiscountCD")
                    .HasMaxLength(50)
                    .HasComment("할인코드");

                entity.Property(e => e.DIdx)
                    .HasColumnName("dIdx")
                    .HasComment("시퀀스")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DiscountCdnm)
                    .IsRequired()
                    .HasColumnName("DiscountCDNM")
                    .HasMaxLength(100)
                    .HasComment("할인코드명");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(2, 2)")
                    .HasComment("할인율");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");
            });

            modelBuilder.Entity<TManagerMember>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_T_MANAGERMEMBER");

                entity.ToTable("T_ManagerMember");

                entity.HasComment("관리자정보");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasComment("직원ID");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("직원명");

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("직원사번");

                entity.Property(e => e.EmpPwd)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("직원비밀번호");

                entity.Property(e => e.EmpRole)
                    .HasMaxLength(50)
                    .HasComment("직원권한");

                entity.Property(e => e.EmpStatus)
                    .HasMaxLength(50)
                    .HasComment("직원상태");

                entity.Property(e => e.EncKey)
                    .HasMaxLength(100)
                    .HasComment("암호키");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasComment("마지막로그인");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");
            });

            modelBuilder.Entity<TMessageSendLog>(entity =>
            {
                entity.HasKey(e => e.SIdx)
                    .HasName("PK_T_MESSAGESENDLOG");

                entity.ToTable("T_MessageSendLog");

                entity.Property(e => e.SIdx)
                    .HasColumnName("sIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.CallbackNo)
                    .HasMaxLength(20)
                    .HasComment("발신번호");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.MessageContent)
                    .HasMaxLength(500)
                    .HasComment("메시지내용");

                entity.Property(e => e.MessageTitle)
                    .HasMaxLength(100)
                    .HasComment("메시지제목");

                entity.Property(e => e.ReceiveNo)
                    .HasMaxLength(20)
                    .HasComment("수신번호");

                entity.Property(e => e.RefKey).HasComment("참조키");

                entity.Property(e => e.SendDate)
                    .HasColumnType("datetime")
                    .HasComment("전송요청일시");
            });

            modelBuilder.Entity<TMessageTemplate>(entity =>
            {
                entity.HasKey(e => e.MIdx)
                    .HasName("PK_T_MESSAGETEMPLATE");

                entity.ToTable("T_MessageTemplate");

                entity.HasComment("메시지템플릿");

                entity.Property(e => e.MIdx)
                    .HasColumnName("mIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.Etc)
                    .HasMaxLength(200)
                    .HasComment("비고");

                entity.Property(e => e.IsActive).HasComment("사용여부");

                entity.Property(e => e.MessageLength).HasComment("메시지길이");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .HasComment("메시지종류");

                entity.Property(e => e.RegEmpId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("등록직원");

                entity.Property(e => e.TemplateTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("템플릿타이틀");

                entity.Property(e => e.TemplteContent)
                    .IsRequired()
                    .HasComment("템플릿컨텐츠");
            });

            modelBuilder.Entity<TParkingDeviceInfo>(entity =>
            {
                entity.HasKey(e => e.DIdx)
                    .HasName("PK_T_PARKINGDEVICEINFO");

                entity.ToTable("T_ParkingDeviceInfo");

                entity.HasComment("주차장 Device (모니터링대상)");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("T_ParkingDeviceInfo_Index_1");

                entity.HasIndex(e => e.IsHealthCheck)
                    .HasName("T_ParkingDeviceInfo_Index_3");

                entity.HasIndex(e => e.Plcode)
                    .HasName("T_ParkingDeviceInfo_Index_2");

                entity.Property(e => e.DIdx)
                    .HasColumnName("dIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DeviceDescription)
                    .HasMaxLength(1000)
                    .HasComment("단말기 설명");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .HasComment("단말기ID");

                entity.Property(e => e.DeviceIpAddr)
                    .HasMaxLength(50)
                    .HasComment("네트워크 주소");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .HasComment("단말기명");

                entity.Property(e => e.DisplayOrder).HasComment("노출순서");

                entity.Property(e => e.Etc)
                    .HasMaxLength(500)
                    .HasComment("비고");

                entity.Property(e => e.HealthStatus)
                    .HasMaxLength(50)
                    .HasComment("모니터링 결과");

                entity.Property(e => e.IsHealthCheck)
                    .HasColumnName("isHealthCheck")
                    .HasComment("모니터링 대상");

                entity.Property(e => e.Plcode)
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장 코드");

                //entity.HasOne(d => d.PlcodeNavigation)
                //    .WithMany(p => p.TParkingDeviceInfo)
                //    .HasForeignKey(d => d.Plcode)
                //    .HasConstraintName("FK_T_ParkingDeviceInfo_PLCode_T_ParkingLotBasicInfo_PLCode");
            });

            modelBuilder.Entity<TParkingLotBasicInfo>(entity =>
            {
                entity.HasKey(e => e.Plcode)
                    .HasName("PK_T_PARKINGLOTBASICINFO");

                entity.ToTable("T_ParkingLotBasicInfo");

                entity.HasComment("주차장 기본정보");

                entity.HasIndex(e => e.Plcode)
                    .HasName("T_ParkingLotBasicInfo_Index_2");

                entity.HasIndex(e => e.PlisActive)
                    .HasName("T_ParkingLotBasicInfo_Index_1");

                entity.Property(e => e.Plcode)
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장 코드");

                entity.Property(e => e.PIdx)
                    .HasColumnName("pIdx")
                    .HasComment("시퀀스")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pladdress)
                    .IsRequired()
                    .HasColumnName("PLAddress")
                    .HasMaxLength(50)
                    .HasComment("주차장 주소");

                entity.Property(e => e.PlcodeName)
                    .IsRequired()
                    .HasColumnName("PLCodeName")
                    .HasMaxLength(50)
                    .HasComment("주차장 명");

                entity.Property(e => e.PlencKey)
                    .HasColumnName("PLEncKey")
                    .HasMaxLength(100)
                    .HasComment("암호화키");

                entity.Property(e => e.PlisActive)
                    .HasColumnName("PLIsActive")
                    .HasComment("활성여부");

                entity.Property(e => e.PlmodDate)
                    .HasColumnName("PLModDate")
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.PlregDate)
                    .HasColumnName("PLRegDate")
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.Pltype)
                    .HasColumnName("PLType")
                    .HasMaxLength(50)
                    .HasComment("주차장 타입");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");
            });

            modelBuilder.Entity<TParkingMonitoringAlert>(entity =>
            {
                entity.HasKey(e => e.AIdx)
                    .HasName("PK_T_PARKINGMONITORINGALERT");

                entity.ToTable("T_ParkingMonitoringAlert");

                entity.Property(e => e.AIdx)
                    .HasColumnName("aIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.AlertReceiveNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("알람번호");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.IsActive).HasComment("사용여부");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장코드");

                entity.Property(e => e.RegEmpId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("등록직원");

                //entity.HasOne(d => d.PlcodeNavigation)
                //    .WithMany(p => p.TParkingMonitoringAlert)
                //    .HasForeignKey(d => d.Plcode)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_T_ParkingMonitoringAlert_PLCode_T_ParkingLotBasicInfo_PLCode");
            });

            modelBuilder.Entity<TParkingMonitoringLog>(entity =>
            {
                entity.HasKey(e => e.LIdx)
                    .HasName("PK_T_PARKINGMONITORINGLOG");

                entity.ToTable("T_ParkingMonitoringLog");

                entity.HasComment("모니터링 로그테이블");

                entity.Property(e => e.LIdx)
                    .HasColumnName("lIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.HealthStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("모니터링 상태");

                entity.Property(e => e.RefDdix)
                    .HasColumnName("refDDix")
                    .HasComment("모니터링시퀀스");

                entity.HasOne(d => d.RefDdixNavigation)
                    .WithMany(p => p.TParkingMonitoringLog)
                    .HasForeignKey(d => d.RefDdix)
                    .HasConstraintName("FK_T_ParkingMonitoringLog_refDDix_T_ParkingDeviceInfo_dIdx");
            });

            modelBuilder.Entity<TParkingSeasonTicket>(entity =>
            {
                entity.HasKey(e => e.SIdx)
                    .HasName("PK_T_PARKINGSEASONTICKET");

                entity.ToTable("T_ParkingSeasonTicket");

                entity.HasComment("정기권 정보");

                entity.HasIndex(e => e.CarDisplayNo)
                    .HasName("T_ParkingSeasonTicket_Index_3");

                entity.HasIndex(e => e.Plcode)
                    .HasName("T_ParkingSeasonTicket_Index_2");

                entity.HasIndex(e => e.UserId)
                    .HasName("T_ParkingSeasonTicket_Index_1");

                entity.Property(e => e.SIdx)
                    .HasColumnName("sIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.CarDisplayNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("차량번호");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DiscountPrice).HasComment("할인가격");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장코드");

                entity.Property(e => e.RealPrice).HasComment("실제가격");

                entity.Property(e => e.ServiceEndDate)
                    .HasColumnType("datetime")
                    .HasComment("정기권종료일");

                entity.Property(e => e.ServiceStartDate)
                    .HasColumnType("datetime")
                    .HasComment("정기권시작일");

                entity.Property(e => e.TicketPrice).HasComment("티켓가격");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("사용자아이디");

                //entity.HasOne(d => d.PlcodeNavigation)
                //    .WithMany(p => p.TParkingSeasonTicket)
                //    .HasForeignKey(d => d.Plcode)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_T_ParkingSeasonTicket_PLCode_T_ParkingLotBasicInfo_PLCode");
            });

            modelBuilder.Entity<TParkingTicketInfo>(entity =>
            {
                entity.HasKey(e => e.TicketNo)
                    .HasName("PK_T_ParkingTicketInfo_1");

                entity.ToTable("T_ParkingTicketInfo");

                entity.HasComment("주차권 정보");

                entity.HasIndex(e => e.CarDisplayNo)
                    .HasName("T_ParkingTicketInfo_Index_2");

                entity.HasIndex(e => e.IsCancel)
                    .HasName("T_ParkingTicketInfo_Index_7");

                entity.HasIndex(e => e.IsPaid)
                    .HasName("T_ParkingTicketInfo_Index_5");

                entity.HasIndex(e => e.IsValidData)
                    .HasName("T_ParkingTicketInfo_Index_3");

                entity.HasIndex(e => e.PayStatus)
                    .HasName("T_ParkingTicketInfo_Index_6");

                entity.HasIndex(e => e.PayTypeCd)
                    .HasName("T_ParkingTicketInfo_Index_4");

                entity.HasIndex(e => e.Pidx)
                    .HasName("UC_PIdx")
                    .IsUnique();

                entity.HasIndex(e => e.Plcode)
                    .HasName("T_ParkingTicketInfo_Index_1");

                entity.Property(e => e.TicketNo)
                    .HasMaxLength(50)
                    .HasComment("티켓번호");

                entity.Property(e => e.CarDisplayNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("차량번호");

                entity.Property(e => e.ChargePrice).HasComment("정상요금");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DiscountPrice).HasComment("할인요금");

                entity.Property(e => e.Etc)
                    .HasMaxLength(1000)
                    .HasComment("비고");

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(200)
                    .HasComment("차량 이미지 정보");

                entity.Property(e => e.IsCancel).HasComment("취소");

                entity.Property(e => e.IsPaid).HasComment("결제여부");

                entity.Property(e => e.IsValidData).HasComment("번호인식여부");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("datetime")
                    .HasComment("결제일자");

                entity.Property(e => e.PayStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("결제상태");

                entity.Property(e => e.PayTypeCd)
                    .IsRequired()
                    .HasColumnName("PayTypeCD")
                    .HasMaxLength(50)
                    .HasComment("결제방법");

                entity.Property(e => e.Pidx)
                    .HasColumnName("PIdx")
                    .HasComment("시퀀스")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장 코드");

                entity.Property(e => e.RealPayPrice).HasComment("실 지불요금");

                entity.Property(e => e.RefundPrice).HasComment("환불금액");

                entity.Property(e => e.TicketCloseDate)
                    .HasColumnType("datetime")
                    .HasComment("출차일시");

                entity.Property(e => e.TicketOpenDate)
                    .HasColumnType("datetime")
                    .HasComment("입차일시");

                entity.Property(e => e.UseTime).HasComment("주차이용시간(분)");

                //entity.HasOne(d => d.PlcodeNavigation)
                //    .WithMany(p => p.TParkingTicketInfo)
                //    .HasForeignKey(d => d.Plcode)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_T_ParkingTicketInfo_PLCode_T_ParkingLotBasicInfo_PLCode");
            });

            modelBuilder.Entity<TParkingTicketPginfo>(entity =>
            {
                entity.HasKey(e => e.PIdx)
                    .HasName("PK_T_PARKINGTICKETPGINFO");

                entity.ToTable("T_ParkingTicketPGInfo");

                entity.HasComment("주차권 PG정보");

                entity.Property(e => e.PIdx)
                    .HasColumnName("pIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .HasComment("매입사명");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.PayPrice).HasComment("결제요금");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장코드");

                entity.Property(e => e.ResultCode)
                    .HasMaxLength(50)
                    .HasComment("결과코드");

                entity.Property(e => e.TicketNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("티켓번호");

                entity.Property(e => e.TransactionNo)
                    .HasMaxLength(50)
                    .HasComment("승인번호");
            });

            modelBuilder.Entity<TParkingTicketUseDiscount>(entity =>
            {
                entity.HasKey(e => e.DIdx)
                    .HasName("PK_T_PARKINGTICKETUSEDISCOUNT");

                entity.ToTable("T_ParkingTicketUseDiscount");

                entity.HasComment("할인코드 사용내역");

                entity.HasIndex(e => e.DiscountCd)
                    .HasName("T_ParkingTicketUseDiscount_Index_3");

                entity.HasIndex(e => e.Plcode)
                    .HasName("T_ParkingTicketUseDiscount_Index_2");

                entity.HasIndex(e => e.TicketNo)
                    .HasName("T_ParkingTicketUseDiscount_Index_1");

                entity.Property(e => e.DIdx)
                    .HasColumnName("dIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.DiscountCd)
                    .IsRequired()
                    .HasColumnName("DiscountCD")
                    .HasMaxLength(50)
                    .HasComment("할인코드");

                entity.Property(e => e.Etc)
                    .HasMaxLength(100)
                    .HasComment("비고");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장코드");

                entity.Property(e => e.TicketNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("티켓번호");

                entity.Property(e => e.UseCount)
                    .HasColumnName("useCount")
                    .HasComment("사용갯수");

                //entity.HasOne(d => d.DiscountCdNavigation)
                //    .WithMany(p => p.TParkingTicketUseDiscount)
                //    .HasForeignKey(d => d.DiscountCd)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_T_ParkingTicketUseDiscount_DiscountCD_T_DiscountInfo_DiscountCD");

                //entity.HasOne(d => d.TicketNoNavigation)
                //    .WithMany(p => p.TParkingTicketUseDiscount)
                //    .HasForeignKey(d => d.TicketNo)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_T_ParkingTicketUseDiscount_T_ParkingTicketInfo");
            });

            modelBuilder.Entity<TParkingUncollectedCharge>(entity =>
            {
                entity.HasKey(e => e.MIdx)
                    .HasName("PK_T_PARKINGUNCOLLECTEDCHARGE");

                entity.ToTable("T_ParkingUncollectedCharge");

                entity.HasComment("주차요금 미수정보");

                entity.Property(e => e.MIdx)
                    .HasColumnName("mIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(50)
                    .HasComment("가상계좌");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(50)
                    .HasComment("가상계좌발급은행");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.IsDeposit).HasComment("입금여부");

                entity.Property(e => e.NoticeDatae)
                    .HasColumnType("datetime")
                    .HasComment("안내일시");

                entity.Property(e => e.OverDueNo).HasComment("연체차수");

                entity.Property(e => e.Plcode)
                    .IsRequired()
                    .HasColumnName("PLCode")
                    .HasMaxLength(50)
                    .HasComment("주차장코드");

                entity.Property(e => e.ReceiveEndDate)
                    .HasColumnType("datetime")
                    .HasComment("입금기간일시");

                entity.Property(e => e.ReceiveTelno)
                    .HasMaxLength(20)
                    .HasComment("안내핸드폰");

                entity.Property(e => e.TicketNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("티켓번호");

                entity.Property(e => e.TransactionNo)
                    .HasMaxLength(50)
                    .HasComment("트랜잭션정보");
            });

            modelBuilder.Entity<TSiteConfig>(entity =>
            {
                entity.HasKey(e => e.ServiceKey)
                    .HasName("PK_T_SITECONFIG");

                entity.ToTable("T_SiteConfig");

                entity.HasComment("서비스 설정");

                entity.HasIndex(e => e.IsUse)
                    .HasName("T_SiteConfig_Index_1");

                entity.HasIndex(e => e.ServiceDomain)
                    .HasName("T_SiteConfig_Index_2");

                entity.Property(e => e.ServiceKey)
                    .HasMaxLength(100)
                    .HasComment("키");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.IsUse).HasComment("사용여부");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");

                entity.Property(e => e.ServiceDomain)
                    .HasMaxLength(100)
                    .HasComment("적용도메인");

                entity.Property(e => e.ServiceExtValue)
                    .HasMaxLength(100)
                    .HasComment("확장값");

                entity.Property(e => e.ServiceValue)
                    .HasMaxLength(100)
                    .HasComment("값");
            });

            modelBuilder.Entity<TUserCarDocumentInfo>(entity =>
            {
                entity.HasKey(e => e.DIdx)
                    .HasName("PK_T_USERCARDOCUMENTINFO");

                entity.ToTable("T_UserCarDocumentInfo");

                entity.HasComment("차량등록서류");

                entity.HasIndex(e => e.CarDisplayNo)
                    .HasName("T_UserCarDocumentInfo_Index_1");

                entity.Property(e => e.DIdx)
                    .HasColumnName("dIdx")
                    .HasComment("시퀀스");

                entity.Property(e => e.CarDisplayNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("차량번호");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DocType)
                    .HasMaxLength(50)
                    .HasComment("파일타입");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("파일명");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(200)
                    .HasComment("파일경로");
            });

            modelBuilder.Entity<TUserCarInfo>(entity =>
            {
                entity.HasKey(e => e.CarDisplayNo)
                    .HasName("PK_T_USERCARINFO");

                entity.ToTable("T_UserCarInfo");

                entity.HasComment("사용자차랑정보");

                entity.HasIndex(e => e.CIdx)
                    .HasName("UC_cIdx")
                    .IsUnique();

                entity.Property(e => e.CarDisplayNo)
                    .HasMaxLength(50)
                    .HasComment("차량번호");

                entity.Property(e => e.CIdx)
                    .HasColumnName("cIdx")
                    .HasComment("시퀀스")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CarIdentificationNo)
                    .HasMaxLength(100)
                    .HasComment("차량등록정보");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.DocumentFilePath)
                    .HasMaxLength(200)
                    .HasComment("차량등록서류경로");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(200)
                    .HasComment("차량등록서류");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("사용자아이디");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TUserCarInfo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_UserCarInfo_UserId_T_UserInfo_UserId");
            });

            modelBuilder.Entity<TUserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_T_USERINFO");

                entity.ToTable("T_UserInfo");

                entity.HasComment("사용자정보");

                entity.HasIndex(e => e.UIdx)
                    .HasName("UC_uIdx")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasComment("사용자아이디");

                entity.Property(e => e.DataModDate)
                    .HasColumnType("datetime")
                    .HasComment("수정일");

                entity.Property(e => e.DataRegDate)
                    .HasColumnType("datetime")
                    .HasComment("등록일");

                entity.Property(e => e.RegEmpId)
                    .HasMaxLength(50)
                    .HasComment("등록직원");

                entity.Property(e => e.UIdx)
                    .HasColumnName("uIdx")
                    .HasComment("시퀀스")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasComment("사용자이름");

                entity.Property(e => e.UserPwd)
                    .HasMaxLength(100)
                    .HasComment("사용자비번");

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(50)
                    .HasComment("사용자상태");

                entity.Property(e => e.UserTelno)
                    .HasMaxLength(20)
                    .HasComment("전화번호");

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .HasComment("사용자타입");

                entity.HasOne(d => d.RegEmp)
                    .WithMany(p => p.TUserInfo)
                    .HasForeignKey(d => d.RegEmpId)
                    .HasConstraintName("FK_T_UserInfo_RegEmpId_T_ManagerMember_EmpId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
