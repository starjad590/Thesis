# Use the official Microsoft SQL Server 2022 image as a base
FROM mcr.microsoft.com/mssql/server:2022-latest

# Copy initialization scripts to a directory inside the container
COPY init-db /var/opt/mssql/init-db

# Copy the custom entrypoint script into the container
COPY entrypoint.sh /usr/local/bin/entrypoint.sh

USER root
RUN chmod +x /usr/local/bin/entrypoint.sh

# Use the custom entrypoint script to start the SQL Server
ENTRYPOINT ["/usr/local/bin/entrypoint.sh"]