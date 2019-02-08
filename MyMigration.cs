using System;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Migration
{
  public class MyMigration
  {
    //Create service collection
    public static IServiceProvider CreateServices()
    {

      var assembly = Assembly.GetExecutingAssembly();

      return new ServiceCollection().AddFluentMigratorCore()
       .ConfigureRunner(runner => runner
       .AddPostgres()
       .WithGlobalConnectionString("Server=localhost;Database=test2db;User Id=postgres; Password=chetan;")
       .ScanIn(assembly).For.Migrations()
       )
       .AddLogging(lg => lg.AddFluentMigratorConsole())
       .Configure<FluentMigratorLoggerOptions>(
           cfg =>
           {
             cfg.ShowSql = true;
             cfg.ShowElapsedTime = true;
           }
       )
       .BuildServiceProvider(false);

    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();

    }

    public void InitMigration()
    {
        var serviceProvider = CreateServices();

        using(var scope = serviceProvider.CreateScope())
        {
            UpdateDatabase(scope.ServiceProvider);
        }
    }


  }
}