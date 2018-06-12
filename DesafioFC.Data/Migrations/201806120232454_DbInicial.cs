namespace DesafioFC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataConsulta = c.DateTime(nullable: false),
                        Medico_Id = c.Int(),
                        Paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Medico_Id)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.Paciente_Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Rg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Endereco = c.String(),
                        NumeroEndereco = c.Int(nullable: false),
                        Telefone = c.String(),
                        Rg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Agendamentoes", "Medico_Id", "dbo.Medicos");
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Medico_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Agendamentoes");
        }
    }
}
