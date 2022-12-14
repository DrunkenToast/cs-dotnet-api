# cs-dotnet-api

## Setup

### Secrets

Make sure all your secrets are in order:  
`cp db.env.example db.env`  
`cp appsettings.json.example appsettings.json`  

Also for development if needed.

### Database

If you haven't applied migrations or updated your database you can use the included dockerfile:

`docker build -f Dockerfile.migrations -t dotnet-ef .`  
`docker run -it --rm dotnet-ef /root/.dotnet/tools/dotnet-ef migrations add init`  
`docker run -it --rm dotnet-ef /root/.dotnet/tools/dotnet-ef database update`  

Don't forget to add `--network` to the commands with the network of the docker compose (eg: `--network cs-dotnet-api_default`).  
You can also supply --connection with you connection string if it differs from production and development.

## Running

`docker compose up`  
`docker compose stop/down` to stop the container (/and remove the containers)
