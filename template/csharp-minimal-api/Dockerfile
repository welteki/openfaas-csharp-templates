FROM --platform=${TARGETPLATFORM:-linux/amd64} ghcr.io/openfaas/of-watchdog:0.9.15 as watchdog

FROM --platform=${BUILDPLATFORM:-linux/amd64} mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG TARGETPLATFORM
ARG BUILDPLATFORM

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

WORKDIR /src
COPY function/function.csproj .
RUN dotnet restore
COPY function/ .
RUN dotnet publish -c release -o /app

FROM --platform=${TARGETPLATFORM:-linux/amd64}  mcr.microsoft.com/dotnet/aspnet:8.0
COPY --from=watchdog /fwatchdog /usr/bin/fwatchdog
RUN chmod +x /usr/bin/fwatchdog

WORKDIR /app
COPY --from=build /app .

USER app

ENV ASPNETCORE_HTTP_PORTS=3000
ENV fprocess="dotnet function.dll"
ENV upstream_url="http://127.0.0.1:3000"
ENV mode="http"

ENTRYPOINT ["fwatchdog"]