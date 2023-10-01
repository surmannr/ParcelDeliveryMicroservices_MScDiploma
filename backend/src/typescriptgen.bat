@ECHO OFF
CD Microservices\_Common\Common
ECHO %cd%
ECHO "Generating common models, filters and dtos."
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
CD Microservices\Employees\Employees.API
ECHO %cd%
ECHO "Generating employees models, filters and dtos."
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
CD Microservices\PackageDelivery\PackageDelivery.BL
ECHO %cd%
ECHO "Generating packagedelivery dtos."
dotnet-typegen generate --config-path  "../../../tgconfig.json"
CD ..
CD ..
CD ..
CD Microservices\PackageDelivery\PackageDelivery.DAL
ECHO %cd%
ECHO "Generating packagedelivery models and filters."
dotnet-typegen generate --config-path  "../../../tgconfig.json"
ECHO "Typescript model generating is done."
PAUSE