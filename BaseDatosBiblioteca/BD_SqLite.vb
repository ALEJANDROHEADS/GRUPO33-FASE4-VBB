Imports System.IO
Imports Microsoft.Data.Sqlite

Public Class BD_SqLite


    Public Function BaseDatosLite(ByVal SQLstr As String) As DataTable

        'Dim StrConeccion_0 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""H:\UNAD\PERIODO 16-01 2022\VISUAL BASIC BASICO\APLICATIVOS VBB\VVB_FASE4_GRUPO33\AppWinGrp33_2019\AppWinGrupo33\AppWinGrupo33\BDD\DBSqlF4.mdf"";Integrated Security=True"
        'Dim StrConeccion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" & StrPathApp & """;Integrated Security=True"
        'Dim sOleDBConect As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & StrPathApp & ";"
        Dim StrPathApp = Path.GetFullPath("..\..\..\") & "BDD\BDLiteF4.sqlite" '"DBSqlF4.mdf"

        Dim DtResp As New DataTable

        Dim SqlConn As New SqliteConnection
        Dim SqlCmd As New SqliteCommand
        Dim SqlReader As SqliteDataReader

        Try

            Dim connection As String = "Data Source=" & StrPathApp & ";"
            SqlConn = New SqliteConnection(connection)
            SqlCmd = New SqliteCommand(SQLstr, SqlConn)
            SqlConn.Open()
            SqlReader = SqlCmd.ExecuteReader
            DtResp.Load(SqlReader)

        Catch ex As Exception
            DtResp = New DataTable
        Finally

            If Not IsNothing(SqlReader) Then
                SqlReader.Close()
            End If

            SqlConn.Close()
            SqlConn.Dispose()
        End Try
        Return DtResp
    End Function

End Class
