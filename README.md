# Mail Service Provider

This is a simple yet fast C# library to send emails to to clients through code.

## Getting Started

You can either copy the source code into your own project, compile the source code into a DLL or simply download the already compiled version from Releases (preferred).

### Building from source
To build from source you will need:

- Dotnet 8 SDK or later

### Building from IDE (Windows)
If you are using Visual Studio or any other IDE you can simply right click on the `MailServiceProvider` project and click `Build`.

### Building from CLI (Linux/Mac)

If you are using the `dotnet` command line interface run the following command from the root directory (where the solution (.sln) file is):
```shell
dotnet build MailServiceProvider
```

### Linking API to your project

Simply reference the `MailServiceProvider.dll` in Dependencies within your own project.

## API Guide

The API has 3 main classes you must configure to use:

- `IMail`
- `IProvider`
- `IBody`

Each class has an example implementation that you can use.

- `IMail` -> `Mail`
- `IProvider` -> `GMProvider`
- `IBody` -> `HTMLBody` OR `PlainTextBody`

First begin by importing all the namespaces we will need:
```csharp
using MailServiceProvider.Body;
using MailServiceProvider.Mail;
using MailServiceProvider.Provider;
```

Now create a list of all the emails you'd like to send to.
```csharp
List<string> emails = new()
{
    "dev@callums005.net",
    "contactme@callums005.net"
};
```
Next you want to create the body of the email. For this example we will use the `HTMLBody`.
```csharp
HTMLBody body = new();
```
This has created an empty email body, so now we need to add some content to the body, using these HTML functions:
```csharp
body.DivStart("container");
body.H1("Heading");
body.H2("Subheading");
body.H3("Subheading within a subheading");
body.P("Some paragraph text");
body.Span("Some default test");
body.A("A clickable link", "www.example.com");
body.Img("www.example.com/static/my-image.png", "Alternative text to support screen readers");
body.Img("www.example.com/static/my-image.png"); // Uses default alternative text
body.DivEnd();
```
Now we have a mailing list and body content, we can now build the email:
```csharp
Mail exampleMail = new()
{};
```
First we must specify a provider (the email client you are using). For this example we will use gmail.
<br>_Luck for us, I've already created a Gmail provider class, `GMProvider`_
```csharp
Mail exampleMail = new()
{
    Provider = new GMProvider("send.from@email.com", "applcation password")
};
```
When setting up your provider you MUST configure SMTP support within your email client, typically you will need to create an application password too (usually a 16 character string: "AAAA BBBB CCCC DDDD").
<br>Please read your client's documentation regarding this setup.
_Always use environment variables when pushing sensitive data to a pubic site or souce control_.

Now we will populate the rest of the fields with the appropriate data:
```csharp
Mail exampleMail = new()
{
    Provider = new GMProvider("send.from@email.com", "applcation password"),
    MailingList = emails,
    FromAddress = "send.from@email.com",
    Subject = "The email subject header",
    Body = body
};
```
Now that we have created a template of the email, you can hit send!
```csharp
exampleMail.Send();
```
This will send the same email to everyone in your mailing list.

Your final implementation should look like this:
```csharp
using MailServiceProvider.Body;
using MailServiceProvider.Mail;
using MailServiceProvider.Provider;

class Program
{
    public static void Main(string[] args)
    {
       List<string> emails = new()
        {
            "dev@callums005.net",
            "contactme@callums005.net"
        };
        
        HTMLBody body = new();
        body.DivStart("container");
        body.H1("Heading");
        body.H2("Subheading");
        body.H3("Subheading within a subheading");
        body.P("Some paragraph text");
        body.Span("Some default test");
        body.A("A clickable link", "www.example.com");
        body.Img("www.example.com/static/my-image.png", "Alternative text to support screen readers");
        body.Img("www.example.com/static/my-image.png"); // Uses default alternative text
        body.DivEnd();
        
        Mail exampleMail = new()
        {
            Provider = new GMProvider("send.from@email.com", "applcation password"), // Don't forget to set the correct login information!
            MailingList = emails,
            FromAddress = "send.from@email.com",
            Subject = "The email subject header",
            Body = body
        };
        
        exampleMail.Send();
    }
    
}
```