# Cat Gallery

A simple demonstration of some basic [Coalesce](https://github.com/IntelliTect/Coalesce) features.

## Launch Instructions

- `cd CatGallery.Web`
- `dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "<secret>"` (secret must be for the clientID defined in appsettings.json - see instructions [here](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/social/microsoft-logins?view=aspnetcore-7.0#create-the-app-in-microsoft-developer-portal) to create your own.)
- `npm ci`
- `dotnet run`
