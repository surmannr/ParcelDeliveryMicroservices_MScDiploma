@ECHO OFF
CD Microservices\_Common\Common
ECHO %cd%
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
CD Microservices\Employees\Employees.API
ECHO %cd%
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
CD Microservices\PackageDelivery\PackageDelivery.API
ECHO %cd%
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
CD Microservices\PackageSending\PackageSending.API
ECHO %cd%
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
ECHO "Typescript model generating is done."
PAUSE