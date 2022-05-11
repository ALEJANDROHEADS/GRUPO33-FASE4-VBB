
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Configuration.ApplicationSettingsBase
Imports System.Data.SqlClient

Public Class BD_SqlMdf

    Dim SQLQuery As New StringBuilder
    Public Function Ejecutar_SqlMDF(ByVal SQLstr As String) As DataTable
        Dim StrPathApp = Path.GetFullPath("..\..\..\") & "BDD\DBSqlF4.mdf"
        Dim DtResp As New DataTable
        Dim SqlConnect As SqlConnection
        Dim SqlAdap As SqlDataAdapter
        Dim SqlComan As SqlCommand


        'Dim StrConeccion_0 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""H:\UNAD\PERIODO 16-01 2022\VISUAL BASIC BASICO\APLICATIVOS VBB\VVB_FASE4_GRUPO33\AppWinGrp33_2019\AppWinGrupo33\AppWinGrupo33\BDD\DBSqlF4.mdf"";Integrated Security=True"
        'Dim StrConeccion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" & StrPathApp & """;Integrated Security=True"
        'Dim sOleDBConect As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & StrPathApp & ";"
        'string oledbConnectString = "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=SSPI";
        'Dim strConect As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringBD").ConnectionString


        '<<<═══════════════════════════════════════════════════════════════════════════════════════
        '<<< (CesarAlejandroCabezas) 09/mayo/2022//  Fase 4 - Multimedia
        '>>> Se Agrega en APPSeting la cadena de conección para poder accederla desde la Boblioteca 
        Dim strConect As String = Configuration.ConfigurationSettings.AppSettings("StrConectDB")


        Try
            SqlConnect = New SqlConnection(strConect)
            SqlConnect.Open()
            SqlComan = New SqlCommand(SQLstr, SqlConnect)
            SqlAdap = New SqlDataAdapter(SqlComan)
            SqlAdap.Fill(DtResp)

            'Using con As New SqlConnection(strConect)
            '    Using cmd As New SqlCommand(sSQL, con)
            '        cmd.CommandType = CommandType.Text
            '        Using sda As New SqlDataAdapter(cmd)
            '            sda.Fill(DtResp)
            '        End Using
            '    End Using
            'End Using

        Catch ex As Exception
            DtResp = New DataTable
        Finally
            SqlConnect.Close()
            SqlConnect.Dispose()
            If Not IsNothing(SqlConnect) Then
                SqlConnect.Dispose()
                SqlConnect = Nothing
            End If
        End Try

        Return DtResp
    End Function
End Class
