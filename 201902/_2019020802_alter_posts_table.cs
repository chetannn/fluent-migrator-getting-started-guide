using FluentMigrator;

namespace MyApp.Migration._201902
{
    [Migration(2019020802, "alter posts table")]
  public class _2019020802_alter_posts_table : FluentMigrator.Migration
  {
    public override void Down()
    {
      throw new System.NotImplementedException();
    }

    public override void Up()
    {
        if(!Schema.Schema("public").Table("posts").Column("created_on").Exists())
        {
            Alter.Table("posts").AddColumn("created_on").AsDateTime().Nullable();
        }
    }
  }
}