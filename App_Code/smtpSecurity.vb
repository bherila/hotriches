Imports Microsoft.VisualBasic

Public Class smtpSecurity
    Implements System.Net.ICredentialsByHost


    Public Function GetCredential(ByVal host As String, ByVal port As Integer, ByVal authType As String) As System.Net.NetworkCredential Implements System.Net.ICredentialsByHost.GetCredential
        Return New System.Net.NetworkCredential("system@hotriches.com", "eggbert")
    End Function

End Class
