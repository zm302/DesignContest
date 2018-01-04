using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DesignContest.Entity.Models.Mapping;

namespace DesignContest.Entity.Models
{
    public partial class SmartLaboratoryContext : DbContext
    {
        static SmartLaboratoryContext()
        {
            Database.SetInitializer<SmartLaboratoryContext>(null);
        }

        public SmartLaboratoryContext()
            : base("Name=SmartLaboratoryContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<T_ClassRoom> T_ClassRoom { get; set; }
        public DbSet<T_Devices> T_Devices { get; set; }
        public DbSet<T_DevicesFixRecord> T_DevicesFixRecord { get; set; }
        public DbSet<T_DevicesMaintenance> T_DevicesMaintenance { get; set; }
        public DbSet<T_Dictionary> T_Dictionary { get; set; }
        public DbSet<T_Environment> T_Environment { get; set; }
        public DbSet<T_Function> T_Function { get; set; }
        public DbSet<T_Log> T_Log { get; set; }
        public DbSet<T_LoginCertificate> T_LoginCertificate { get; set; }
        public DbSet<T_Notice> T_Notice { get; set; }
        public DbSet<T_Role> T_Role { get; set; }
        public DbSet<T_RoleFunction> T_RoleFunction { get; set; }
        public DbSet<T_Sign> T_Sign { get; set; }
        public DbSet<T_Staff> T_Staff { get; set; }
        public DbSet<T_StaffRecord> T_StaffRecord { get; set; }
        public DbSet<T_StaffSign> T_StaffSign { get; set; }
        public DbSet<T_SysLog> T_SysLog { get; set; }
        public DbSet<T_User> T_User { get; set; }
        public DbSet<T_UserRole> T_UserRole { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new T_ClassRoomMap());
            modelBuilder.Configurations.Add(new T_DevicesMap());
            modelBuilder.Configurations.Add(new T_DevicesFixRecordMap());
            modelBuilder.Configurations.Add(new T_DevicesMaintenanceMap());
            modelBuilder.Configurations.Add(new T_DictionaryMap());
            modelBuilder.Configurations.Add(new T_EnvironmentMap());
            modelBuilder.Configurations.Add(new T_FunctionMap());
            modelBuilder.Configurations.Add(new T_LogMap());
            modelBuilder.Configurations.Add(new T_LoginCertificateMap());
            modelBuilder.Configurations.Add(new T_NoticeMap());
            modelBuilder.Configurations.Add(new T_RoleMap());
            modelBuilder.Configurations.Add(new T_RoleFunctionMap());
            modelBuilder.Configurations.Add(new T_SignMap());
            modelBuilder.Configurations.Add(new T_StaffMap());
            modelBuilder.Configurations.Add(new T_StaffRecordMap());
            modelBuilder.Configurations.Add(new T_StaffSignMap());
            modelBuilder.Configurations.Add(new T_SysLogMap());
            modelBuilder.Configurations.Add(new T_UserMap());
            modelBuilder.Configurations.Add(new T_UserRoleMap());
        }
    }
}
