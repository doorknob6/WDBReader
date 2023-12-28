# WdbReader 

This library provides services to read WoW .wdb files.

The services can be added to any dependency injection container implementing [IServiceCollection](https://learn.microsoft.com/en-gb/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection?view=dotnet-plat-ext-8.0) using the `AddWdbReaderServices` extension method.

There are currently implementations for the 1.12.1 client's `itemcache.wdb` and `gameobjectcache.wdb` in the `wdbsettings.json`. This can be extended or overridden by implementing a custom `wdbsettings.json` in a client program.