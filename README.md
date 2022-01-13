# Api Localization Demo

A simple API project showing how to use ASP.NET Core Localization

## Run the Code

`dotnet run` should be sufficient.

The simplest way to demo the behavior is using a tool like Postman. Make a GET request to `/Greeting?Name=world` and by default you should see a response with a greeting of "Hello, world!".

Change the `Accept-Language` header to `en-AU` and you should get a different greeting (of "G'day, world!").

![Postman showing request with en-AU greeting](https://user-images.githubusercontent.com/782127/149388754-cf1b4f24-4ffb-4345-908a-6d597eda1bda.png)
