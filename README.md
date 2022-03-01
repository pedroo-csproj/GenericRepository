# GenericRepository

[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/pedro-octavio/GenericRepository/blob/main/LICENSE)

**GenericRepository** is a library to facility the creation of repositories in **.Net** projects.

## Tech

**GenericRepository** uses a number of open source projects to work properly:

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.Net](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework](https://docs.microsoft.com/en-us/aspnet/entity-framework#:~:text=Entity%20Framework%20%28EF%29%20is%20an%20object-relational%20mapper%20that,data-access%20code%20that%20developers%20usually%20need%20to%20write.)
- [Git](https://git-scm.com/)

## Installation

**GenericRepository** requires [.Net Framework](https://docs.microsoft.com/en-us/dotnet/framework/install/guide-for-developers#:~:text=1%20Open%20the%20download%20page%20for%20the%20.NET,architecture%2C%20and%20then%20choose%20Next.%20More%20items...%20) 6+ to run.

### Nuget Package manager
```sh
Install-Package Octasharp.GenericRepository
```

### .Net CLI
```sh
dotnet add package Octasharp.GenericRepository
```

You can see more ways to install **GenericRepository** in your project [here](https://www.nuget.org/packages/Octasharp.GenericRepository/).

## Implementing

### add Interfaces namespace in repository interface

```sh
using GenericRepository.Interfaces;
```

### implement IRepository in repository interface

```sh
public interface IWaifuRepository : IRepository
```

### add Implementations namespace in repository class

```sh
using GenericRepository.Implementations;
```

### implement Repository and created repository interface in created repository class, and inject in constructor the data context

```sh
public class WaifuRepository : Repository, IWaifuRepository
{
    public WaifuRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
    {
    }
}
```

### configure inversion of control of created repository interface and repository class

```sh
services.AddTransient<IWaifuRepository, WaifuRepository>();
```

### It's all done! Just inject the created repository interface in anywhere you want to use

```sh
public WaifusController(IWaifuRepository waifuRepository) =>
    _waifuRepository = waifuRepository;

private readonly IWaifuRepository _waifuRepository;
```