  
# Scritp by tometchy https://github.com/tometchy
# Wait to be sure that SQL Server came up
sleep 90s

echo ""
echo "+----------------------+"
echo "|                      |"
echo "| Database Initializer |"
echo "|                      |"
echo "+----------------------+"
echo ""

# Run the setup script to create the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "yourStrong(!)Password" -d master -i create-database.sql
