Imports BaseDatosBiblioteca.BD_SqlMdf
Public Class FrmRegister

    Dim LibBaseMdf As New BaseDatosBiblioteca.BD_SqlMdf

    Const sTitulo = "Registro de Estudiantes - UNAD"
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click

        If MsgBox("¿Se desea realizar la limpieza de lso datos. ?", vbQuestion + vbYesNo, sTitulo) = vbYes Then
            LimpiarFormulario()

        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        If MsgBox("¿Deseas cancelar el proceso de registro. ?", vbQuestion + vbYesNo, sTitulo) = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnRegistar_Click(sender As Object, e As EventArgs) Handles BtnRegistar.Click

        ' >>> Se verifica que se hallan ingresados todos los datos para el Registro 
        If ValidarFormulario() Then

            ' >>> se Verifica que no existe Regoistro Con la Identificación 
            If ValidarEstudiante() Then

                '>>> Se procederá a realizar el Registro 
                If RealizarRegistro() Then
                    LimpiarFormulario()
                    Me.Close()
                End If
            Else
                MessageBox.Show("El Código Ingresado ( " & TxtDocumento.Text.Trim() & " )" & vbCrLf & "ya se encuentra Registrado como Estudiante. ", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MsgBox("Cada uno de los campos debe ser diligenciado !", vbExclamation, sTitulo)
        End If
    End Sub

    Private Sub TxtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocumento.KeyPress
        If Not IsNumeric(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub CBoxPerfil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBoxPerfil.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBoxTipoDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBoxTipoDocumento.KeyPress
        e.Handled = True
    End Sub

    Private Function RealizarRegistro() As Boolean
        Dim bContinuar As Boolean
        Dim sQuery As String
        Dim DtReg As New DataTable
        Dim sTipoDoc, sNroDoc, sNombre, sApellidos As String
        Dim sEmail, sTelefono, sPassword, sPerfil As String
        Try
            '>>> Se recuperan los Datos a almacenar 
            sTipoDoc = CBoxTipoDocumento.SelectedItem.ToString.Trim()
            sNroDoc = TxtDocumento.Text.Trim()
            sNombre = TxtNombres.Text.Trim()
            sApellidos = TxtApellidos.Text.Trim()
            sEmail = TxtEmail.Text.Trim()
            sTelefono = TxtTelefono.Text.Trim()
            sPassword = TxtPassword.Text.Trim()
            sPerfil = CBoxPerfil.SelectedItem.ToString.Trim()

            '>>> se Realiza Encriptado de la contraseña a guardar
            sPassword = Eramake.eCryptography.Encrypt(sPassword)

            '>>> se Crea Script para Ejecutar en la de datos e ingresar la informacion en la Tabla Estudiantes.
            '>>> se Obtiene el ultimo registro y se le suma 1 para el siguiente Estudiante.
            sQuery = "Declare @id int  " & vbCrLf
            sQuery += "select @id= max( Id_registro )+1 from TbEstudiantes " & vbCrLf
            sQuery += "insert into TbEstudiantes (Id_registro,Tipo_Documento,Num_Documento,Nombres,Apellidos,Correo,Telefono,Password,Rol)" & vbCrLf
            sQuery += " values (@id,1,'" & sNroDoc & "', '" & sNombre & "','" & sApellidos & "','" & sEmail & "', '" & sTelefono & "','" & sPassword & "','" & sPerfil & "')" & vbCrLf
            sQuery += " select * from TbEstudiantes where Id_registro = @id " & vbCrLf

            LibBaseMdf = New BaseDatosBiblioteca.BD_SqlMdf
            DtReg = LibBaseMdf.Ejecutar_SqlMDF(sQuery)

            If DtReg.Rows.Count > 0 Then

                Dim mail As New System.Net.Mail.MailMessage
                Dim StrMensaje As String

                'Se Crea el Mensaje que se enviará como confiormación del Registro.
                StrMensaje = "Se han Realizado el Registro del Estusdiante de forma Satisfactoria." & vbCrLf & vbCrLf
                StrMensaje += "Datos Del Registro:" & vbCrLf & vbCrLf
                StrMensaje += "* Tipo Documento :  " & sTipoDoc & vbCrLf
                StrMensaje += "* Identificación :  " & sNroDoc & vbCrLf
                StrMensaje += "* Apellidos  :  " & sApellidos & vbCrLf
                StrMensaje += "* Nombres :  " & sNombre & vbCrLf
                StrMensaje += "* Telefono  :  " & sTelefono & vbCrLf
                StrMensaje += "* Rol :  " & sPerfil & vbCrLf & vbCrLf
                StrMensaje += "* Tipo Documento :  " & sTipoDoc & vbCrLf

                StrMensaje += "* Código (Usuario) :  " & sNroDoc & vbCrLf
                StrMensaje += "* Contraseña :  " & TxtPassword.Text.Trim() & vbCrLf & vbCrLf & vbCrLf

                StrMensaje += "Felicitaciones y Bienveniso a Nuestro Aplicativo..."

                '>>> se Organizan y se dan las propiedades para Enviar correos por SmtpClient
                With mail
                    .From = New System.Net.Mail.MailAddress("HeadsNetPrueba@gmail.com", "Pruebas")
                    .To.Add(sEmail)
                    .Subject = "Registro Estudiante  - Fase 4 "
                    .Body = StrMensaje
                    .Priority = System.Net.Mail.MailPriority.High
                End With

                Dim Server As New System.Net.Mail.SmtpClient("smtp.gmail.com")

                With Server
                    .Port = 587
                    .EnableSsl = True
                    .Credentials = New System.Net.NetworkCredential("HeadsNetPrueba@gmail.com", "Vbb2022unad*")
                End With

                Server.Send(mail)

                MessageBox.Show("Excelente el Registro se ha realizado de forma Satisfactoria. " & vbCrLf & "Se ha enviado la información al correo del Estudiante.", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                bContinuar = True
            Else
                MessageBox.Show("Upss!!, No se ha logrado realizar el Registro del Estudiante... ", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                bContinuar = False
            End If

        Catch ex As Exception
            bContinuar = False
        End Try
        Return bContinuar
    End Function

    Private Function ValidarFormulario() As Boolean
        Dim bContinuar As Boolean
        Dim sTipoDoc, sNroDoc, sNombre, sApellidos As String
        Dim sEmail, sTelefono, sPassword, sPerfil As String
        Try
            '>>> Se recupera la información de cada uno de los campos del Formulario 
            sTipoDoc = CBoxTipoDocumento.SelectedItem.ToString.Trim()
            sNroDoc = TxtDocumento.Text.Trim()
            sNombre = TxtNombres.Text.Trim()
            sApellidos = TxtApellidos.Text.Trim()
            sEmail = TxtEmail.Text.Trim()
            sTelefono = TxtTelefono.Text.Trim()
            sPassword = TxtPassword.Text.Trim()
            sPerfil = CBoxPerfil.SelectedItem.ToString.Trim()


            '>>> Se Verifica que todos lso campos posea información al momento de Realizar el Registro
            If IsNothing(sTipoDoc) Or IsNothing(sNroDoc) Or IsNothing(sNombre) Or IsNothing(sApellidos) _
                Or IsNothing(sEmail) Or IsNothing(sTelefono) Or IsNothing(sPassword) Or IsNothing(sPerfil) Then

                bContinuar = False
            Else
                If sTipoDoc.Trim().Length = 0 Or sNroDoc.Trim().Length = 0 Or sNombre.Trim().Length = 0 Or sApellidos.Trim().Length = 0 _
                    Or sEmail.Trim().Length = 0 Or sTelefono.Trim().Length = 0 Or sPassword.Trim().Length = 0 Or sPerfil.Trim().Length = 0 Then
                    bContinuar = False
                Else
                    bContinuar = True
                End If
            End If

        Catch ex As Exception
            '>>> si se genera algun Error no podrás ingresar al Registro  
            bContinuar = False
        End Try
        Return bContinuar
    End Function
    Private Function LimpiarFormulario() As Boolean
        Dim bContinuar As Boolean
        Try
            CBoxTipoDocumento.SelectedIndex = 0
            TxtDocumento.Text = ""
            TxtNombres.Text = ""
            TxtApellidos.Text = ""
            TxtEmail.Text = ""
            TxtTelefono.Text = ""
            TxtPassword.Text = ""
            CBoxPerfil.SelectedIndex = 0
            LblCodigo.Text = ""
            TxtDocumento.Select()
            bContinuar = True
        Catch ex As Exception
            bContinuar = False
        End Try
        Return bContinuar
    End Function


    Private Function ValidarEstudiante() As Boolean
        Dim bResp As Boolean
        Dim Dt As New DataTable
        Dim SQuery As String = ""
        Dim sCodigo As String
        Try

            '>>> Se Realiza Consulta en la base de datos con el Codigo o identificación del Estudiante.
            sCodigo = TxtDocumento.Text.Trim()
            SQuery = "select  * from TbEstudiantes where Num_Documento = '" & sCodigo & "'"
            Dt = LibBaseMdf.Ejecutar_SqlMDF(SQuery)

            '>>> al REcuperar información no se permitirá el Registro 
            If Dt.Rows.Count > 0 Then
                bResp = False
            Else
                bResp = True
            End If

        Catch ex As Exception

            bResp = False
        End Try

        Return bResp
    End Function


    Private Sub TxtDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtDocumento.TextChanged

        LblCodigo.Text = TxtDocumento.Text.Trim()
    End Sub
End Class
