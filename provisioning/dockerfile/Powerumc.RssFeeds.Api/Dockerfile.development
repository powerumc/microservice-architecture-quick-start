FROM microsoft/dotnet:2.1.301-sdk as base

# Envrionment
ENV Name=Powerumc.RssFeeds.Api
ENV ProvisioningDir=./provisioning/dockerfile/${Name}
ENV BuildDir=/src/${Name}
ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS http://localhost:5000

EXPOSE 80

# Install nginx
RUN apt-get update 
RUN apt-get install nginx -y

# Copy nginx configuration
RUN rm -v /etc/nginx/nginx.conf
RUN rm -v /etc/nginx/sites-available/default
COPY ${ProvisioningDir}/nginx.conf.development /etc/nginx/nginx.conf
COPY ${ProvisioningDir}/default.development /etc/nginx/sites-available/default


############# Build #############
FROM microsoft/dotnet:2.1.301-sdk as build
ENV Name=Powerumc.RssFeeds.Api
ENV BuildDir=/src/${Name}
COPY /src /src
WORKDIR ${BuildDir}
RUN dotnet restore -nowarn:msb3202,nu1503


############ Publish ##############
FROM build as publish
ENV Name=Powerumc.RssFeeds.Api
ENV BuildDir=/src/${Name}
WORKDIR ${BuildDir}
RUN dotnet publish --no-restore -o /app/out


FROM base as final
COPY --from=publish /app/out /app/out
COPY --from=publish /src/DataProtection-Keys /app/DataProtection-Keys
WORKDIR /app/out
CMD service nginx restart && dotnet /app/out/${Name}.dll
