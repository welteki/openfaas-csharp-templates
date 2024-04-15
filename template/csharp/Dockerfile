FROM  ghcr.io/openfaas/of-watchdog:0.9.15 as watchdog

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

WORKDIR /src
COPY root.csproj .
COPY function/function.csproj function/
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY --from=watchdog /fwatchdog /usr/bin/fwatchdog
RUN chmod +x /usr/bin/fwatchdog


WORKDIR /app
COPY --from=build /app .

USER app

ENV fprocess="dotnet openfaas-api.dll"
ENV upstream_url="http://127.0.0.1:3000"
ENV mode="http"

ENTRYPOINT ["fwatchdog"]