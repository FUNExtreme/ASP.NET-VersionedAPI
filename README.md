# ASP.NET Versioned API

## Introduction
The project in this repository provides a `GlobalVersionedPrefixProvider` provider and a bare-bones sample implementation of a versioned API with this provider. It implements a custom written GlobalVersionedPrefixProvider and shows how to use an adapter pattern to easily maintain multiple versions of an API within one single project.

## Contents
### src
The source folder contains the `GlobalVersionedPrefixProvider.cs` file, you can copy paste the contents of this class at will and use it wherever you please. If you are so kind attribution to "Robin Maenhaut" is always nice :smile:

### sample
The sample project provides a bare-bones implementation of the `GlobalVersionedPrefixProvider` as well as an adapter pattern implementation to handle changing data sources or required changes in the business logic.

## Implementation
### GlobalVersionedPrefixProvider
Long story short, using this provider gives you an easy way to automatically map a controller to a versioned route.

This class can be passed as an argument of the `config.MapHttpAttributeRoutes` method that can be found in `Register` method of the WebApiConfig class.

The GlobalVersionedPrefixProvider takes one argument in its constructor. This is the prefix that will be appended to all controllers.
For example `config.MapHttpAttributeRoutes(new GlobalVersionedPrefixProvider("api"));` will produce URIs like `<host>/api/<versionandcontroller>`

### Controller Naming convention
As structured developers we like to give our classes meaningful names. When considering a REST API that can return a list of users we may consider using a name like `UsersController` with a GET method that returns all users. When working with a versioned API we can change this name to be `UsersV1Controller` followed by `UsersV2Controller`.

This is where the `GlobalVersionedPrefixProvider` steps in again. The provider reads the controller names and extracts the version number.
For example `UsersV2Controller` with a global prefix `api` will produce the URI `<host>/api/v2/users`.

---

IMPORTANT: Class names do not like dots, so instead we use 'd'. V1.2 becomes V1d2

---

All that without a sweat!

### Adapters
The project also includes an example of the adapter pattern to handle changes in data retrieval.

An interface is used (`IExampleAdapter`) to dictate the methods that an adapter should implement. This ensures interoperability, you can easily use any version of the adapter in any controller.
This becomes possible because the actual implementation is only ever used once, when creating an object within the constructor of the controller.  
There are plenty of ways to handle this (the way the example does it, dependency injection, ..) but it is important that the interface is used to store the implementation object in a variable.

The same logic also applies to the methods defined in the interface, you should avoid using `List` and instead use `IEnumerable`. his way the implementation can change to any data container that implements `IEnumerable` without causing any issues.

## Contributing
I'm always interested in your ideas and visions. If you see something that could be done better feel free to start an issue and we'll discuss it together. A group can do so much more than one person alone.


