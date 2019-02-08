using FluentMigrator;

namespace MyApp.Migration._201902
{
    [Migration(2019020801, "create posts table")]
  public class _2019020801_create_posts_table : FluentMigrator.Migration
  {
    public override void Down()
    {
        Delete.Table("posts");
    }

    public override void Up()
    {
        if(!Schema.Schema("public").Table("posts").Exists())
        {
            Create.Table("posts").WithColumn("id").AsInt32().Identity().PrimaryKey()
            .WithColumn("title").AsAnsiString(50).Nullable()
            .WithColumn("description").AsAnsiString(200).Nullable()
            .WithColumn("status").AsBoolean().WithDefaultValue(true).Nullable();
        }
    }
  }
}