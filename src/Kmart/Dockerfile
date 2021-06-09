FROM mcr.microsoft.com/dotnet/sdk:5.0 AS installer-env

COPY . /src/app
RUN cd /src/app && \
    mkdir -p /kmart
    
FROM installer-env as test
WORKDIR /src/app/Kmart.Tests
LABEL unittests=true
RUN dotnet test -c Release --logger trx /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/out/testresults/coverage/ /p:Exclude="[xunit.*]*" --results-directory /out/testresults

FROM installer-env as publish
WORKDIR /src/app/Kmart
LABEL Kmart=true
RUN dotnet publish -c Release --output /kmart

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as remote

COPY --from=publish ["/kmart", "/kmart"]
WORKDIR /kmart
ENTRYPOINT ["dotnet", "Kmart.dll"]