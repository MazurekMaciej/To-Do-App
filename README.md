# To-Do-App
To-Do app repository which contains <b>Console Application, WinForms application, Web API and Web MVC applications with IoC and Logger.</b>

Some of the frameworks used in repository: <b>ASP.NET, Entity Framework, Unity, log4net</b>

<b>ToDoList.Lib.Data</b>
Data access layer which contains Database Context based on Domain Model.

<b>ToDoList.Lib.Common</b>
Common layer for all projects, contains Domain Model, Exceptions and all interfaces used in repository.

<b>ToDoList.Lib.Business</b>
Business logic layer, contains general implementations of interfaces.

<b>ToDoList.Lib.Unity</b>
Custom implementations of Unity's lifetime managers and SessionContextManagers.

<b>ToDoList.Lib.Applications.Console</b>
Console application performing simple ToDo App which uses Business and Common layers.

<b>ToDoList.Lib.Applications.ApplicationWinForms</b>
WinForms application performing simple ToDo App which uses Business and Common layers.

<b>ToDoList.Lib.Applications.ApplicationWebApi</b>
Implementation of Web Api which uses Business and Common layers.

<b>ToDoList.Lib.Applications.ApplicationWeb</b>
ASP.NET MVC application which uses Business and Common layers.
