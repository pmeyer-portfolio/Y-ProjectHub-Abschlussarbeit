﻿namespace ProjectHub.Blazor.Constants;

public abstract class ProjectHubRoute
{
    public const string Home = "/";
    public const string Authentication = "/authentication/{action}";
    public const string AuthenticationLogout = "/authentication/logout";
    public const string AuthenticationLogin = "/authentication/login";
    public const string Logout = "logout";
    public const string Create = "create";
    public const string Projects = "projects";
    public const string Details = "/project/details/{id:int}";
    public const string EditStatus = "/projects/edit/status";
    public const string EditTribe = "/projects/edit/tribe";
    public const string EditProgrammingLanguages = "/projects/edit/languages";
    public const string EditTitle = "/projects/edit/title";
    public const string EditDescription = "/projects/edit/description";
}