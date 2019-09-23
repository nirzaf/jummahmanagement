REM Workbench Table Data copy script
REM Workbench Version: 8.0.17
REM 
REM Execute this to copy table data from a source RDBMS to MySQL.
REM Edit the options below to customize it. You will need to provide passwords, at least.
REM 
REM Source DB: Mssql@JummahManagement (Microsoft SQL Server)
REM Target DB: Mysql@127.0.0.1:3306


@ECHO OFF
REM Source and target DB passwords
set arg_source_password=
set arg_target_password=
set arg_source_ssh_password=
set arg_target_ssh_password=


REM Set the location for wbcopytables.exe in this variable
set "wbcopytables_path=C:\Program Files\MySQL\MySQL Workbench 8.0 CE"

if not [%wbcopytables_path%] == [] set wbcopytables_path=%wbcopytables_path%
set wbcopytables=%wbcopytables_path%\wbcopytables.exe

if not exist "%wbcopytables%" (
	echo "wbcopytables.exe doesn't exist in the supplied path. Please set 'wbcopytables_path' with the proper path(e.g. to Workbench binaries)"
	exit 1
)

IF [%arg_source_password%] == [] (
    IF [%arg_target_password%] == [] (
        IF [%arg_source_ssh_password%] == [] (
            IF [%arg_target_ssh_password%] == [] (
                ECHO WARNING: All source and target passwords are empty. You should edit this file to set them.
            )
        )
    )
)
set arg_worker_count=2
REM Uncomment the following options according to your needs

REM Whether target tables should be truncated before copy
REM set arg_truncate_target=--truncate-target
REM Enable debugging output
REM set arg_debug_output=--log-level=debug3


REM Creation of file with table definitions for copytable

set table_file=%TMP%\wb_tables_to_migrate.txt
TYPE NUL > %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Branches]	`JummahManagement`	`tbl_Branches`	-	-	[Branch_ID], [Branch_Name], [JIP_Name], [JIP_Contact], [No], [Street_Name], [City], [District] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Dhae]	`JummahManagement`	`tbl_Dhae`	-	-	[Dhae_ID], [Dhae_Name], [Dhae_Contact], [House_No], [Street_Name], [City], [District] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_City]	`JummahManagement`	`tbl_City`	-	-	[City_ID], [City] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Dhae_temp]	`JummahManagement`	`tbl_Dhae_temp`	-	-	[Dhae_ID], [Dhae_Name], [Dhae_Contact], [House_No], [Street_Name], [City], [District] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Jummah_Schedule_temp]	`JummahManagement`	`tbl_Jummah_Schedule_temp`	-	-	[ID], [Row_Count], [Dhae_Name], [Dhae_Contact], [Branch_Name], [JIP_Name], [JIP_Contact], [Date] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Jummah_Schedule]	`JummahManagement`	`tbl_Jummah_Schedule`	-	-	[ID], [Row_Count], [Dhae_Name], [Dhae_Contact], [Branch_Name], [JIP_Name], [JIP_Contact], [Date] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Branches_temp]	`JummahManagement`	`tbl_Branches_temp`	-	-	[Branch_ID], [Branch_Name], [JIP_Name], [JIP_Contact], [No], [Street_Name], [City], [District] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Branches_Deleted]	`JummahManagement`	`tbl_Branches_Deleted`	-	-	[Branch_ID], [Branch_Name], [JIP_Name], [JIP_Contact], [No], [Street_Name], [City], [District] >> %TMP%\wb_tables_to_migrate.txt
ECHO [JummahManagement]	[dbo].[tbl_Dhae_Deleted]	`JummahManagement`	`tbl_Dhae_Deleted`	-	-	[Dhae_ID], [Dhae_Name], [Dhae_Contact], [House_No], [Street_Name], [City], [District] >> %TMP%\wb_tables_to_migrate.txt


"%wbcopytables%" ^
 --odbc-source="DSN=JummahManagement;DATABASE=;UID=sa" ^
 --source-rdbms-type=Mssql ^
 --target="root@127.0.0.1:3306" ^
 --source-password="%arg_source_password%" ^
 --target-password="%arg_target_password%" ^
 --table-file="%table_file%" ^
 --target-ssh-port="22" ^
 --target-ssh-host="" ^
 --target-ssh-user="" ^
 --source-ssh-password="%arg_source_ssh_password%" ^
 --target-ssh-password="%arg_target_ssh_password%" --thread-count=%arg_worker_count% ^
 %arg_truncate_target% ^
 %arg_debug_output%

REM Removes the file with the table definitions
DEL %TMP%\wb_tables_to_migrate.txt


