rm -rf bin
rm -rf obj
dotnet publish -c Release -r rhel.7-x64 --self-contained=false customer.csproj
