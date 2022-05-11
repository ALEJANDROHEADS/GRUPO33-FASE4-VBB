Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports BaseDatosBiblioteca
Imports Eramake.eCryptography
Imports System.Net.Mail

Public Class FrmLogin
    Const sTitulo = "Fase 3 - Multimedia"
    Dim LibDataBase As New BaseDatosBiblioteca.BD_SqLite
    Dim BaseMdf As New BaseDatosBiblioteca.BD_SqlMdf

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
        FrmMdi.Close()
    End Sub

    Private Sub BtnRegistar_MouseHover(sender As Object, e As EventArgs) Handles BtnRegistar.MouseHover

        With TTipMensaje
            .SetToolTip(BtnRegistar, "Crear o Registrar Nuevo Usuario...")
            .ToolTipTitle = sTitulo
            .ToolTipIcon = ToolTipIcon.Info
        End With

    End Sub

    Private Sub BtnRecuperarPass_MouseHover(sender As Object, e As EventArgs) Handles BtnRecuperarPass.MouseHover
        With TTipMensaje
            .SetToolTip(BtnRecuperarPass, "Recuperar Contraseña de ingreso...")
            .ToolTipTitle = sTitulo
            .ToolTipIcon = ToolTipIcon.Info
        End With
    End Sub
    Private Sub TxtUsuario_MouseHover(sender As Object, e As EventArgs) Handles TxtUsuario.MouseHover
        With TTipMensaje
            .SetToolTip(TxtUsuario, "El codigo o usuario es tu Identificación...")
            .ToolTipTitle = sTitulo
            .ToolTipIcon = ToolTipIcon.Info
        End With
    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Dim sEstudiante As String = ""
        If (ValidarDatos()) Then

            If ValidarUsuario(TxtUsuario.Text.Trim(), TxtPassword.Text.Trim(), sEstudiante) Then
                FrmMdi.Show()
                MsgBox("¡Bienvenido!; " & vbCrLf & sEstudiante, vbInformation, sTitulo)

                Me.Close()
            End If
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim bContinuar As Boolean
        Try

            If (TxtPassword.Text.Trim().Length > 0 And TxtUsuario.Text.Trim().Length > 0) Then
                bContinuar = True
            Else
                MsgBox("Los datos Son Obligatorios para el Ingreso... ", vbInformation, sTitulo)
                bContinuar = False
            End If

        Catch ex As Exception
            bContinuar = False
        End Try
        Return bContinuar
    End Function

    Private Function ValidarUsuario(ByVal sUsuario As String, ByVal sPass As String, ByRef sEstudiante As String) As Boolean
        Dim bValido As Boolean = False
        Dim sSqry As String
        Dim DtUsu As New DataTable
        Dim strPassDesEncryp As String
        Try
            '>>> Se agrega a la Variable la Sentencia que deseamos ejecutar en nuestra base Seleccionada.
            sSqry = "select  * from TbEstudiantes "
            sSqry += "where Num_Documento = '" & sUsuario & "'"
            'DtUsu = LibDataBase.BaseDatosLite(sSqry)
            'DtUsu = EjecutaBaseDatos(sSqry) 
            'DtUsu = BaseDatosLite(sSqry)

            DtUsu = BaseMdf.Ejecutar_SqlMDF(sSqry)
            If DtUsu.Rows.Count > 0 Then
                strPassDesEncryp = Eramake.eCryptography.Decrypt(DtUsu.Rows(0)("Password").ToString.Trim())
                If (strPassDesEncryp.Equals(sPass)) Then
                    sEstudiante = Trim(DtUsu.Rows(0)("Nombres").ToString.Trim() & " " & DtUsu.Rows(0)("Apellidos").ToString.Trim())
                    bValido = True
                Else
                    bValido = False
                    MsgBox("Lo Sentimos; Usuario y/o Contraseña Incorrectos ; " & vbCrLf & "Intentalo nuevamente.", vbCritical, sTitulo)
                End If
            Else
                MsgBox("No Existen el Usuario; " & vbCrLf & "Se debe realizar el Registro Correpondiente.", vbExclamation, sTitulo)
                TxtPassword.Text = ""
                TxtUsuario.Text = ""
                TxtUsuario.Select()
            End If

        Catch ex As Exception
            bValido = False
            ' MsgBox("Ups: " & ex.Message, vbExclamation, sTitulo)
        End Try
        Return bValido
    End Function


    Private Function EjecutaBaseDatos(ByVal sSQL As String) As DataTable
        Dim StrPathApp = Path.GetFullPath("..\..\..\") & "BDD\DBSqlF4.mdf"
        Dim DtResp As New DataTable
        Dim SqlConnect As SqlConnection
        Dim SqlAdap As SqlDataAdapter
        Dim SqlComan As SqlCommand

        'Dim StrConeccion_0 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""H:\UNAD\PERIODO 16-01 2022\VISUAL BASIC BASICO\APLICATIVOS VBB\VVB_FASE4_GRUPO33\AppWinGrp33_2019\AppWinGrupo33\AppWinGrupo33\BDD\DBSqlF4.mdf"";Integrated Security=True"
        'Dim StrConeccion As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" & StrPathApp & """;Integrated Security=True"
        'Dim sOleDBConect As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & StrPathApp & ";"
        'string oledbConnectString = "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=SSPI";
        Dim strConect As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringBD").ConnectionString
        Try
            SqlConnect = New SqlConnection(strConect)
            SqlConnect.Open()
            SqlComan = New SqlCommand(sSQL, SqlConnect)
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

    Private Function RecuperarPassword() As Boolean
        Dim DtUsuario As New DataTable
        Dim strQuery As String = ""
        Try
            '>>> Se solicita el codigo o Identificación del Estudiante para comprobar 
            Dim sCodigo As String = InputBox("Por Favor ingresar el Código del Usuario" & vbCrLf & "(Identificación)", sTitulo)

            If Len(sCodigo.Trim()) > 0 Then

                '>>> se Genera Script para Recuperar de la Base lso Datos del Estudiante
                strQuery = "select  * from TbEstudiantes where Num_Documento = '" & sCodigo & "'"
                DtUsuario = BaseMdf.Ejecutar_SqlMDF(strQuery)

                ' se confirma que el codigo corresponde a un estudiante.
                If (DtUsuario.Rows.Count > 0) Then

                    Dim mail As New MailMessage
                    Dim StrMensaje As String
                    Dim AuxEmail As String = DtUsuario.Rows(0)("correo").ToString.Trim()
                    Dim StrPass As String = Decrypt(DtUsuario.Rows(0)("Password").ToString.Trim())


                    StrMensaje = "Se ha Solicitado recordar la Contrasela De ingreso " & vbCrLf
                    StrMensaje += "Para el Aplicativo :  " & "visual Basic Basico - UNAD  ( Fase4 - Multimedia )" & vbCrLf & vbCrLf
                    StrMensaje += "* Contraseña :  " & StrPass & vbCrLf & vbCrLf & vbCrLf & vbCrLf
                    StrMensaje += "Ahora podras Ingresar "

                    '>>> se Organizan y se dan las propiedades para Enviar correos por SmtpClient
                    With mail
                        .From = New MailAddress("HeadsNetPrueba@gmail.com", "Pruebas")
                        .To.Add(AuxEmail)
                        .Subject = "Fase 4 - Multimedia"
                        .Body = StrMensaje
                        .Priority = System.Net.Mail.MailPriority.High
                    End With

                    Dim Server As New SmtpClient("smtp.gmail.com")

                    With Server
                        .Port = 587
                        .EnableSsl = True
                        .Credentials = New System.Net.NetworkCredential("HeadsNetPrueba@gmail.com", "Vbb2022unad*")
                    End With

                    Server.Send(mail)

                    Dim iNum As Integer
                    Dim ArrAuxEmail As String() = AuxEmail.Split("@")

                    '>>> se identifica el tamaño del Correo para REcortar y no mostrar completamente el correo 
                    If ArrAuxEmail(0).Length <= 6 Then
                        iNum = 3
                    ElseIf ArrAuxEmail(0).Length > 6 And ArrAuxEmail(0).Length <= 9 Then
                        iNum = 4
                    ElseIf ArrAuxEmail(0).Length >= 10 Then
                        iNum = 5
                    End If


                    AuxEmail = "( ******" & ArrAuxEmail(0).Substring((ArrAuxEmail(0).Length - iNum), iNum) & "@" & ArrAuxEmail(1) & " )"
                    MessageBox.Show("La contraseña ha sido enviada al correo Registrado " & vbCrLf & AuxEmail, sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("El Código Ingresado No corresponde a un Estudiante Registrado. ", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            Else
                MessageBox.Show("Se Debe ingresar el Codigo Correspondiente al Usuario... ", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error al enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Private Sub BtnRegistar_Click(sender As Object, e As EventArgs) Handles BtnRegistar.Click

        FrmRegister.ShowDialog()

    End Sub

    Private Sub BtnRecuperarPass_Click(sender As Object, e As EventArgs) Handles BtnRecuperarPass.Click
        If (MsgBox("¿Deseas recuperar la Contraseña de Ingreso?", vbQuestion + vbYesNo)) = vbYes Then
            RecuperarPassword()
        End If
    End Sub
End Class
