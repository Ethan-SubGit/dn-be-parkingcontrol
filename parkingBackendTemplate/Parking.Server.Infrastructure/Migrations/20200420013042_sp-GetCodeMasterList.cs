using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parking.Server.Infrastructure.Migrations
{
    public partial class spGetCodeMasterList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
				CREATE PROCEDURE [dbo].[SP_Code_List]
					@P_USE_YN	CHAR(1)	= '',	--사용여부 (0:비사용,1:사용, S:시스템)
					@P_CM_CD	VARCHAR(20) = '',
					@P_CD_NM	VARCHAR(50) = ''
	
				AS
				BEGIN
					SET NOCOUNT ON;

					DECLARE @SQL nvarchar(2000), @WHERE_OPTION nvarchar(1000)
					SET @WHERE_OPTION = ' WHERE 1=1 '
					IF @P_USE_YN <> '' SELECT @WHERE_OPTION  = @WHERE_OPTION + ' AND CD_USE_YN = ''' + @P_USE_YN + ''''
					IF @P_CM_CD <> '' SELECT @WHERE_OPTION  = @WHERE_OPTION + ' AND CM_CD LIKE ''' + @P_CM_CD + '%'''
					IF @P_CD_NM <> '' SELECT @WHERE_OPTION  = @WHERE_OPTION + ' AND CD_NM LIKE ''' + @P_CD_NM + '%'''

					SET @SQL = ' SELECT ROW_NUMBER() OVER(ORDER BY CD_CD ASC ) AS rowNo '
					SET @SQL = @SQL + ', CD_IDX, CM_CD, CD_CD, CD_NM, CD_USE_YN '
					SET @SQL = @SQL + ' FROM T_CODE '
					--SET @SQL = @SQL + @WHERE_OPTION

					PRINT @SQL

					EXEC sp_executesql @SQL

				END
            ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
