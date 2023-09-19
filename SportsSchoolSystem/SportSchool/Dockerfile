FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src


# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

# copy over all the projects

#Base
COPY BLL.Contracts.Base/*.csproj ./BLL.Contracts.Base/
COPY Contracts.Base/*.csproj ./Contracts.Base/
COPY DAL.Contracts.Base/*.csproj ./DAL.Contracts.Base/
COPY Domain.Contracts.Base/*.csproj ./Domain.Contracts.Base/
COPY BLL.Base/*.csproj ./BLL.Base/
COPY DAL.Base/*.csproj ./DAL.Base/
COPY DAL.EF.Base/*.csproj ./DAL.EF.Base/
COPY Domain.Base/*.csproj ./Domain.Base/
COPY Helpers.Base/*.csproj ./Helpers.Base/

#App

COPY BLL.Contracts.App/*.csproj ./BLL.Contracts.App/
COPY DAL.Contracts.App/*.csproj ./DAL.Contracts.App/
COPY BLL.App/*.csproj ./BLL.App/
COPY BLL.DTO/*.csproj ./BLL.DTO/
COPY DAL.DTO/*.csproj ./DAL.DTO/
COPY DAL.EF.APP/*.csproj ./DAL.EF.APP/
COPY Domain.App/*.csproj ./Domain.App/
COPY Public.DTO/*.csproj ./Public.DTO/
COPY Test/*.csproj ./Test/
COPY SportSchool/*.csproj ./SportSchool/


RUN dotnet restore


# copy everything else and build app
#Base
COPY BLL.Contracts.Base/. ./BLL.Contracts.Base/
COPY Contracts.Base/. ./Contracts.Base/
COPY DAL.Contracts.Base/. ./DAL.Contracts.Base/
COPY Domain.Contracts.Base/. ./Domain.Contracts.Base/
COPY BLL.Base/. ./BLL.Base/
COPY DAL.Base/. ./DAL.Base/
COPY DAL.EF.Base/. ./DAL.EF.Base/
COPY Domain.Base/. ./Domain.Base/
COPY Helpers.Base/. ./Helpers.Base/

#App

COPY BLL.Contracts.App/. ./BLL.Contracts.App/
COPY DAL.Contracts.App/. ./DAL.Contracts.App/
COPY BLL.App/. ./BLL.App/
COPY BLL.DTO/. ./BLL.DTO/
COPY DAL.DTO/. ./DAL.DTO/
COPY DAL.EF.APP/. ./DAL.EF.APP/
COPY Domain.App/. ./Domain.App/
COPY Public.DTO/. ./Public.DTO/
COPY Test/. ./Test/
COPY SportSchool/. ./SportSchool/

WORKDIR /src/SportSchool
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
EXPOSE 80

COPY --from=build /src/SportSchool/out ./

ENTRYPOINT ["dotnet", "SportSchool.dll"]