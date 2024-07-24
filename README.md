# Api Localization Demo

A simple API project showing how to use ASP.NET Core Localization

## Run the Code

`dotnet run` should be sufficient.

The simplest way to demo the behavior is using a tool like Postman. Make a GET request to `/Greeting?Name=world` and by default you should see a response with a greeting of "Hello, world!". Note that the `accept-language` header is unchecked, so is not being sent.

![Postman showing request with default greeting](https://user-images.githubusercontent.com/782127/149388908-b23844b3-e50f-4888-92fe-a1382e6f6c6c.png)

Change the `Accept-Language` header to `en-AU` and you should get a different greeting (of "G'day, world!").

![Postman showing request with en-AU greeting](https://user-images.githubusercontent.com/782127/149388754-cf1b4f24-4ffb-4345-908a-6d597eda1bda.png)

## Adding Another Language

To add support for another language, you should copy/paste an existing `Messages.en-US.resx` file, change the name to `Messages.xx-XX.resx` for the language you're adding, and make sure to specify that it will perform code generation (dropdown when you double-click the file).

Then, you need to add it to the list of supported langages in the app startup.

## Referencing Resource Files

The namespace of a resource file **and** its folder path are both important to whether or not it will be found. For instance, imagine you're using Areas and you have an application "Acme.Project" with an area called "Members" and inside of that you have a Resources folder and a `Messages.resx` file. Its namespace might be `Acme.Project.Members.Resources.Messages` for the generated class. But ASP.NET Core Localization likely won't find these resources, even if you inspect the assembly and see them present there, because the actual folder is in the "Areas" folder and "Areas" didn't make it into the namespace. Thus, the physical path and the namespace do not match, which is apparently required.

## Why Inject IStringLocalizer vs. Directly Referencing Resource Strings

It's simpler to just reference things as `MyResource.MessageName` rather than doing the whole `IStringLocalizer` and `LocalizedString` bit. But it is less flexible. Here are some benefits of using the service:

Injecting an instance of `IStringLocalizer<MessageResource>` has several advantages over directly referencing the localized resources in a strongly-typed manner:

### Dynamic Culture Switching

Using IStringLocalizer ensures that the correct resource for the current culture is used, even if the culture changes dynamically during the lifetime of the application. This is particularly useful in web applications where the user can switch languages.

### Resource Fallback

IStringLocalizer automatically handles resource fallback if a specific culture's resource is not found. It will fallback to a default culture or the invariant culture if necessary.

### Missing Resource Detection

IStringLocalizer provides information about whether a resource was found or not via the ResourceNotFound property. This can be useful for logging and debugging purposes.

### Flexibility and Extensibility

By using IStringLocalizer, you can easily extend the localization mechanism to support other ways of retrieving localized strings, such as from a database, without changing your controller code.

### Consistency with ASP.NET Core Localization

It aligns with the ASP.NET Core localization system, which is designed to work with IStringLocalizer. This makes the code more consistent and maintainable, especially for developers who are familiar with ASP.NET Core practices.

### Dependency Injection Benefits

Using dependency injection to inject IStringLocalizer follows the principles of dependency injection, making your code more modular, testable, and adhering to SOLID principles.

## References

- [How to Use Localization in an ASP.NET Core Web API](https://www.syncfusion.com/blogs/post/how-to-use-localization-in-an-asp-net-core-web-api.aspx)
