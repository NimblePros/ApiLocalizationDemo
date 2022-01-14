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

## References

- [How to Use Localization in an ASP.NET Core Web API](https://www.syncfusion.com/blogs/post/how-to-use-localization-in-an-asp-net-core-web-api.aspx)
