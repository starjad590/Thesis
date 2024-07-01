#!/bin/bash

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start up
echo "Waiting for SQL Server to start..."
sleep 30

# Run the SQL script(s)
for f in /var/opt/mssql/init-db/*.sql; do
  echo "Executing $f"
  /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i "$f"
done

# Keep the container running
wait