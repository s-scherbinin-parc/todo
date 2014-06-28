namespace todo.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_todo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        Done = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Todoes");
        }
    }
}
