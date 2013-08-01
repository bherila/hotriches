Imports com.statsxp.svc

Public Class StatsXP
    Private Const SiteID As Integer = 9
    Private Const UserName As String = "bherila"
    Private Const EncryptedPassword As String = "ZQBnAGcAYgBlAHIAdAA="

    Public Function RegisterHitFromHTTPRequest(ByRef HTTPRequest As System.Web.HttpRequest) As Boolean
        Return RegisterHitFromHTTPRequest(HTTPRequest, "Unknown", "Unknown")
    End Function

    Public Function RegisterHitFromHTTPRequest(ByRef HTTPRequest As System.Web.HttpRequest, ByVal ScreenResolution As String, ByVal ColorDepth As String) As Boolean
        Dim svc As New StatsXP_Service
        With HTTPRequest
            Dim ref As String = ""
            If Not (.UrlReferrer Is Nothing) Then ref = .UrlReferrer.ToString
            svc.RegisterHit(UserName, EncryptedPassword, SiteID, _
                .RawUrl, .UserHostAddress, ref, .UserAgent, .Browser.Browser.ToString, _
                .Browser.Version.ToString, .Browser.Platform.ToString, .Browser.Cookies, _
                .Browser.ActiveXControls, .Browser.CDF, .Browser.Frames, .Browser.JavaApplets, _
                (.Browser.EcmaScriptVersion.Major > 1), .Browser.Tables, .Browser.VBScript, _
                .Browser.ClrVersion.ToString, .Browser.W3CDomVersion.ToString, ScreenResolution, _
                ColorDepth, .Browser.EcmaScriptVersion.ToString, .Browser.IsMobileDevice, _
                .Browser.MobileDeviceManufacturer, .Browser.MobileDeviceModel)
        End With
        svc.Dispose()
    End Function

End Class
