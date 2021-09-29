using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DoctorWho.Db.Migrations
{
    public partial class CreateSQLObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // create a function to print out companions names for a given episode
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnCompanions (@number int)
                                    RETURNS CHAR(15) AS
                                    BEGIN
                                    DECLARE @return_value CHAR(15);
                                    select @return_value = companionName from tblCompanion com
                                    inner join tblEpisodeCompanion epcom on com.tblCompanionID = epcom.tblCompanionID
                                    where epcom.tblEpisodeID = @number
                                    RETURN @return_value
                                    END;");

            // create a function to print out companions names for a given episode
            migrationBuilder.Sql(@"CREATE FUNCTION dbo.fnEnemies (@number int)
                                    RETURNS CHAR(15) AS
                                    BEGIN
                                    DECLARE @return_value CHAR(15);
                                    select @return_value = EnemyName from tblEnemy en
                                    inner join tblEpisodeEnemy epen on en.tblEnemyId = epen.tblEnemyID
                                    where epen.tblEpisodeID = @number
                                    RETURN @return_value
                                    END;");

            // create Procedure that contain multiple select statment
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.spSummariseEpisodes
                                    AS BEGIN
                                    select Top(3) with ties companionName , count(companionName) As mostFrequentlyAppearingCompanions
                                    from tblCompanion
                                    group by companionName
                                    order by mostFrequentlyAppearingCompanions DESC;
                                    select Top(3) with ties EnemyName , count(EnemyName) As mostFrequentlyAppearingEnemy
                                    from tblEnemy
                                    group by EnemyName
                                    order by mostFrequentlyAppearingEnemy desc
                                    END;");

            // crete view that contain some specific column
            migrationBuilder.Sql(@"create view dbo.viewEpisodes AS
                                select AuthorName, DoctorName, dbo.fnCompanions(e.tblEpisodeID) As viewEpisodes
                                , dbo.fnEnemies(e.tblEpisodeID) As Enemies
                                from tblEpisode e inner join tblAuthor tA on e.tblAuthorID = tA.tblAutorID
                                inner join tblDoctor tD on e.tblDoctorID = tD.tblDoctorID");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.fnCompanions");
            migrationBuilder.Sql("DROP FUNCTION dbo.fnEnemies");
            migrationBuilder.Sql("DROP PROCEDURE dbo.spSummariseEpisodes");
            migrationBuilder.Sql("DROP VIEW dbo.viewEpisodes");
        }
    }
}
