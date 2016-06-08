Imports System.IO
Imports System.Web
Imports System.Configuration

Public Interface IRepositoryPathFinder
    Function Find(repository As String) As String
End Interface

Public Class RepositoryPathFinder
    Implements IRepositoryPathFinder
    Public Const RepoBasePathKey As String = "GroupDocsRepoBasePath"

    Public Function Find(repository As String) As String Implements IRepositoryPathFinder.Find
        Dim ctx = HttpContext.Current
        If ctx Is Nothing Then
            Return GetConfiguredPath(repository)
        End If

        Dim basePath = (If(ctx.Application IsNot Nothing, DirectCast(ctx.Application(RepoBasePathKey), String), Nothing))
        Return (If(String.IsNullOrWhiteSpace(basePath), (If(ctx.Server IsNot Nothing, ctx.Server.MapPath(String.Format("~/App_Data/{0}", repository)), GetConfiguredPath(repository))), Path.Combine(basePath, repository)))
    End Function

    Private Shared Function GetConfiguredPath(repository As String) As String
        Return Path.Combine(If(ConfigurationManager.AppSettings(RepoBasePathKey), AppDomain.CurrentDomain.SetupInformation.ApplicationBase), repository)
    End Function
End Class
