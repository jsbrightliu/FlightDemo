# 添加实体
* Flight.Models\Entities 增加Class: Abc
* Flight.Models\EntityConfigurations 增加对应的Class: AbcTypeConfiguration
* FlightContext 中增进属性:public DbSet<Abc> Abcs { get; set; }
* FlightContext的OnModelCreating中增加: builder.ApplyConfiguration(new AbcTypeConfiguration());
* 更新数据库结构
* Flight.IServices中增加interface: public interface IAbcService
* Flight.Services中增加class: public class AbcService:IAbcService
* Flight.Services中ServiceDependencyInjection增加DI映射: services.AddScoped<IAbcService, AbcService>();
* 在其他class中愉快的使用IAbcService

# 数据库操作
## 更新数据库结构
* 更改目录: cd ./Flight
* 生成Migrations: dotnet ef migrations add "Initial" 
* 升级数据库: dotnet ef database update

## 撤销数据更改
* 更改目录: cd ./Flight
* 撤销最后一次数据库: dotnet ef database drop
* 撤销最后一次生成Migrations: dotnet ef migrations remove
