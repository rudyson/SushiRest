## SSL certificates for HTTPS SSL connection
### Generate and install certificates using dev-certs
Enter the commands provided below into terminal to generate PFX certificate "aspnetapp.pfx"
```shell
dotnet dev-certs https --clean
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p YourSSLPassword
dotnet dev-certs https --trust
```
Note: use "$env:USERPROFILE" instead of "%USERPROFILE%" if you are using Powershell
### Split your PFX certificate into CRT and KEY files using OpenSSL
Use this operations to get:
- Certificate file (aspnetapp.crt)
- Private key to decrypt HTTP requests (aspnetapp.key)
- File which will store password of key for Nginx (aspnetapp.pass)
```shell
openssl pkcs12 -in aspnetapp.pfx -clcerts -nokeys -out aspnetapp.crt
openssl pkcs12 -in aspnetapp.pfx -nocerts -out aspnetapp.key
echo "YourSSLPassword" > aspnetapp.pass
```
## Environment variables
Create file `.env` in the `/server/SushiRest.Api/` which contains configuration provided below.

Specify:
- Docker's container root name
- PostgreSQL user and password
- ASP.NET ports, PFX certificate path and its key's password

```dotenv
# Docker-compose
COMPOSE_PROJECT_NAME=sushirest
# PostgreSQL
POSTGRES_DB=SushiRest
POSTGRES_USER=pguser
POSTGRES_PASSWORD=pgpassword
# ASP.NET Web API
ASPNETCORE_ENVIRONMENT=Release
ASPNETCORE_URLS=https://+:443;http://+:80
ASPNETCORE_HTTPS_PORT=8001
ASPNETCORE_HTTP_PORT=8000
ASPNETCORE_Kestrel__Certificates__Default__Password=SSLCertificatePassword
ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
```
## Launch project
```shell
docker-compose up
```