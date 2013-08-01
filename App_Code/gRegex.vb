Imports Microsoft.VisualBasic

Public Class gRegex
    Function CheckURL(ByVal url As String, ByVal Server As HttpServerUtility, ByVal Cache As Cache) As Boolean
        Dim s As String = ""
        CheckURL(url, s, True, Server, Cache)
        Return (s = "")
    End Function
    Sub CheckURL(ByVal url As String, ByRef StatusText As String, ByVal isFirst As Boolean, ByVal Server As HttpServerUtility, ByVal Cache As Cache)
        StatusText = ""
        Dim pg As String
        Dim wc As New System.Net.WebClient
        Dim b() As Byte
        Try
            b = wc.DownloadData(url)
            If b.Length = 0 Then Throw New Exception("The URL you entered was not valid.")
        Catch ex As Exception
            If isFirst Then
                StatusText = "" 'ex.Message
            End If
            Erase b
            wc.Dispose()
            Exit Sub
        End Try
        Dim i As Integer
        pg = System.Text.ASCIIEncoding.ASCII.GetString(b)
        Dim rx As New Regex(CreateBadWordRegex(Cache), RegexOptions.IgnoreCase)
        Dim mc As MatchCollection = rx.Matches(pg)
        If mc.Count > 0 Then
            StatusText = "Your page contains inappropriate content and so has been rejected:<br><br><ul>"
            For i = 0 To mc.Count - 1
                If i < 10 Then
                    StatusText &= "<li>..." & Server.HtmlEncode(pg.Substring(mc.Item(i).Index - 10, 40)) & "...</li>"
                End If
            Next
            StatusText &= "</ul>"
            wc.Dispose()
            Erase b
            Exit Sub
        End If
        rx = New Regex("top\.location", RegexOptions.IgnoreCase)
        mc = rx.Matches(pg)
        If mc.Count > 0 Then
            StatusText = "Your page breaks out of frames and so has been rejected."
        End If
        'rx = New Regex("(iframe|frameset)", RegexOptions.IgnoreCase)
        'mc = rx.Matches(pg)
        'If mc.Count > 0 Then
        '    StatusText = "Your page contains other frames and cannot be automatically approved. If possible, remove the frames from your page and try again. If the frameset is absolutely unavoidable, please contact support@hotriches.com with your e-mail address, password, and the site URL for manual approval."
        'End If
        rx = New Regex("HTTP\-EQUIV\=\""Refresh\""", RegexOptions.IgnoreCase)
        mc = rx.Matches(pg)
        If mc.Count > 0 Then
            StatusText = "Your page is a redirect or automatically reloads and so has been rejected."
            wc.Dispose()
            Erase b
            Exit Sub
        End If
        If StatusText = "" Then
            rx = New Regex("src\=\""(?<uri>.*?)\""", RegexOptions.IgnoreCase)
            mc = rx.Matches(pg)
            For i = 0 To mc.Count - 1
                Dim uri As String = ""
                Try
                    Dim t As String = mc(i).Groups("uri").Value
                    Dim u As String = t.ToLower
                    If Not (u.EndsWith("jpg") OrElse u.EndsWith("jpeg") OrElse u.EndsWith("png") OrElse u.EndsWith("swf") OrElse u.EndsWith("cab") OrElse u.EndsWith("zip") OrElse u.EndsWith("gif") OrElse u.EndsWith("bmp") OrElse u.EndsWith("tar")) Then
                        If t.StartsWith("http://") Then
                            uri = t
                        ElseIf t.StartsWith("/") Then
                            uri = (New Uri(url)).GetComponents(UriComponents.Host, UriFormat.Unescaped) & t
                        Else
                            uri = (New Uri(New Uri(url), url)).ToString()
                        End If
                    End If
                Catch
                    CheckURL(uri, StatusText, False, Server, Cache)
                End Try
            Next
        End If
        Erase b
        wc.Dispose()
    End Sub

    Function CreateBadWordRegex(ByRef Cache As System.Web.Caching.Cache) As String
        Const cacheItem As String = "wrx_1"
        If Cache.Item(cacheItem) Is Nothing Then
            Dim words() As String = "ass,asshole,fuck.*,bitch.*,lolita.*,assrammer,ayir,b\!\+ch,b17ch,b1tch,bastard,boiolas,bollock.*,buceta,butt\-pirate,c0ck,cock.*,cabron,cawk,cazzo,chink,chraa,chuj,cipa,clit,clits,cum,cunt.*,d4mn,daygo,dego,dick.*,dike.*,dildo,dirsa,dupa,dziwka,ejackulate,ejaculate,ekrem.*,ekto,enculer,faen,fag.*,fanculo,fanny,fatass,fcuk,feces,feg,felcher,ficken,fitt.*,flikker,foreskin,fotze,fuk.*,futkretzn,fux0r,gook,h0r,h4x0r,helvete,hoer.*,honkey,hore,huevon,hui,injun,jism,jizz,kanker.*,kawk,kike,klootzak,kraut,knulle,kuk,kuksuger,kurac,kurwa,kusi.*,kyrpa.*,13itch,l3itch,8itch,lesbian,lesbo,mamhoon,masturbat.*,merd.*,mibun,monkleigh,motherfuck.*,mofo,mouliewop,muie,mulkku,muschi,nepesaurio,nigga,nigger.*,nutsack,orospu,paska.*,perse,phuck,picka,pierdol.*,pillu.*,pimmel,pimpis,piss.*,pizda,poontsee,porn,p0rn,pron,pr0n,preteen,pula,pule,pusse,pussy,puta,puto,qahbeh,qeef.*,rautenberg,schaffer,scheiss,schlampe,schmuck,screw,scrotum,sh\!t,sharmuta,sharmute,shemale,shipal,shiz,skribz,skurwysyn,slut.*,smut,spic,spierdalaj,splooge,suka,teets,b00b.*,teez,testicle,titt.*,tits,twat,vittu,w00se,wank.*,wetback.*,whoar.*,wichser,wop.*,yed,zabourah,nazi".Split(","c)
            Dim i As Integer
            Dim rx As New System.Text.StringBuilder("(")
            For i = 0 To words.Length - 1
                rx.Append("(\b")
                rx.Append(words(i))
                rx.Append("\b)")
                If i < words.Length - 1 Then rx.Append("|")
            Next
            rx.Append(")")
            Cache.Add(cacheItem, rx.ToString, Nothing, Now.AddHours(1), Nothing, CacheItemPriority.Normal, Nothing)
        End If
        Return CStr(Cache.Item(cacheItem))
    End Function
End Class
