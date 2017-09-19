# CronEspresso

C# library for generating cron expressions from given times and dates.

CronEspresso allows the creation of cron strings at run time, removing the need to hard code cron string values into the source code. This can be helpful in projects where cron strings need to be created on the fly or are generated based on variable values within the code (e.g. run every 2 hours from the current time), CronEspresso has easy to read methods that can be called to produce a cron string to suit the given parameters.

Example Usage:
```csharp
    //// Once the package is installed include this in your using
    using CronEspresso;

    //// Cron a cron that runs every 12 hours
    var hourlyCron = CronGenerator.GenerateHourlyCronExpression(6); 
    Console.WriteLine(cron); //// This would output "0 0 6 1/1 * ? *"
    
    //// Cron a cron that runs every day at 14:00
    var dailyCron = CronGenerator.GenerateDailyCronExpression(new TimeSpan(14, 0, 0));
    Console.WriteLine(cron); //// This would output "0 0 14 1/1 * ? *"
    
    //// For a full list of methods and how to use them please visit the github wiki page.
```

## Installing

To use CronEspresso in your solution download the NuGet package via Visual Studio's package manager (search for 'CronEspresso') or run the following line to get the most recent version

```
Install-Package CronEspresso
```

## Documention

For detailed documention on how to use the package, visit the GitHub [Wiki](https://github.com/conway91/CronEspresso/wiki "CronEspresso Wiki")

## Version History

### v2.0 (Latest NuGet Version)

```
* Implementation of cron validation method which validates a given cron string
```

### v1.3

```
* Removal of empty deserialization class until version 2 is released
```

### v1.2

```
* Additon of yearly cron creation implemented
* Refactor of the validation within the cron generator
```

### v1.1

```
* Initial Release
```
