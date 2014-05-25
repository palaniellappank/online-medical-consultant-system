namespace ApplicationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConversationDetail", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.ConversationDetail", "Content", c => c.String());
            AddColumn("dbo.ConversationDetail", "Attachment", c => c.String());
            AddForeignKey("dbo.ConversationDetail", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            CreateIndex("dbo.ConversationDetail", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConversationDetail", "DoctorId", c => c.Int(nullable: false));
            DropIndex("dbo.ConversationDetail", new[] { "UserId" });
            DropForeignKey("dbo.ConversationDetail", "UserId", "dbo.User");
            DropColumn("dbo.ConversationDetail", "Attachment");
            DropColumn("dbo.ConversationDetail", "Content");
            DropColumn("dbo.ConversationDetail", "UserId");
            CreateIndex("dbo.ConversationDetail", "DoctorId");
            AddForeignKey("dbo.ConversationDetail", "DoctorId", "dbo.Doctor", "UserId", cascadeDelete: true);
        }
    }
}
