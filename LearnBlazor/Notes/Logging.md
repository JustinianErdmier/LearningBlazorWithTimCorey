# Logging

* The log level is set in appsettings.json.
* There are 5 log levels:
    * Critical
    * Error
    * Warning
    * Information
    * Debug
    * Trace
* A set log level means that only logs logged at that level or higher will be recorded (i.e., if the log level is set to Information, then only logs logged at Information or higher
  are written. Debug and Trace logs would not be written).
* In addition to appsettings.json, there can exist more specific versions (e.g., appsettings.Development.json).
    * The appsettings.json assumes the default settings and is applied during Production. If you make a change to appsettings.json and there exists a similar settings in a more
      specific version (e.g., appsettings.Development.json), the change will not take effect because the more specific setting takes precedence.

### Critical

* Highest level.
* Fatal problem in our application.

### Error

* Errors are "We caught this exception and there's not really anything we can do about it."

### Warning

* For exceptions you've caught and dealt with, but would still like to know that there's a problem.

### Information

* Logs activity (e.g., "Something happened" or "{user} navigated to {page}", etc.)

### Debug

* Put these throughout the code to get information about the code itself.

### Trace

* Least likely used.
* Shows a TON of information; used just for debugging purposes.

## Best Practices

* Inject the ILogger or ask for it via Dependency Injection. This allows you to get a logger instance of a specified type.  
  **Example**  
  _Index.razor_

```
// Gives a logger that indicates it's logging information about/on the Index page.
@inject ILogger<Index> Logger

@code
{
  Logger.LogInformation("This is a log");
}
```

* Do not use string concatenation or interpolation to build your log messages. Instead, best log messages use Structured Logging.  
  **Example**

```
// Given some data...
int id = 25;

// Log it using Structured Logging...
Logger.LogInformation("User created with id {UserId}", id);

// The name used in the curly braces does not need to match the variable name. It's purely positional. 

// Log the same data twice in one message...
Logger.LogInformation("User created with id {UserId} (repeat: id {Id})", id, id);

// The name in the curly braces does have to be different, but the same variable is passed in twice.
```

* Configure Logging in appsettings.json, not in code.
    * Configuring logging (e.g., setting the minimum log level) in appsettings.json allows for easily updating your configurations during runtime.  
      **Example**

```
// appsettings.json
"Logging":        {
    "LogLevel": {
      "Default":              "Information",
      "Microsoft":            "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  }
  
 // Program.cs
 builder.Host.ConfigureLogging(logger =>
                              {
                                  logger.ClearProviders();
                                  logger.SetMinimumLevel(LogLevel.Information);
                                  logger.AddConsole();
                                  logger.AddDebug();
                              });
```
