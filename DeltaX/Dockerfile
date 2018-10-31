FROM microsoft/dotnet:2.1.3-aspnetcore-runtime
WORKDIR /app
EXPOSE 80
COPY "bin/Release/DeltaX" .
ENTRYPOINT ["dotnet", "DeltaX.dll"]