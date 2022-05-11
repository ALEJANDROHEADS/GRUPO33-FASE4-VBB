<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.PBoxLogo = New System.Windows.Forms.PictureBox()
        Me.TTipMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnRegistar = New System.Windows.Forms.Button()
        Me.BtnRecuperarPass = New System.Windows.Forms.Button()
        Me.LblLogin = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnCancelar.Location = New System.Drawing.Point(202, 375)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(155, 35)
        Me.BtnCancelar.TabIndex = 0
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'PBoxLogo
        '
        Me.PBoxLogo.Image = Global.AppFase4Grupo33.My.Resources.Resources.UNAD
        Me.PBoxLogo.Location = New System.Drawing.Point(122, 51)
        Me.PBoxLogo.Name = "PBoxLogo"
        Me.PBoxLogo.Size = New System.Drawing.Size(119, 122)
        Me.PBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBoxLogo.TabIndex = 1
        Me.PBoxLogo.TabStop = False
        '
        'TxtPassword
        '
        Me.TxtPassword.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPassword.Location = New System.Drawing.Point(71, 315)
        Me.TxtPassword.MaxLength = 30
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(236, 27)
        Me.TxtPassword.TabIndex = 2
        Me.TTipMensaje.SetToolTip(Me.TxtPassword, "Contraseña de Ingreso... ")
        '
        'TxtUsuario
        '
        Me.TxtUsuario.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtUsuario.Location = New System.Drawing.Point(71, 232)
        Me.TxtUsuario.MaxLength = 30
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(236, 27)
        Me.TxtUsuario.TabIndex = 1
        Me.TxtUsuario.Tag = ""
        Me.TTipMensaje.SetToolTip(Me.TxtUsuario, "Usuario de Ingreso... ")
        '
        'BtnAceptar
        '
        Me.BtnAceptar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnAceptar.Location = New System.Drawing.Point(41, 375)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(155, 35)
        Me.BtnAceptar.TabIndex = 4
        Me.BtnAceptar.Text = "Ingresar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnRegistar
        '
        Me.BtnRegistar.Image = Global.AppFase4Grupo33.My.Resources.Resources.AddUser_36
        Me.BtnRegistar.Location = New System.Drawing.Point(321, 51)
        Me.BtnRegistar.Name = "BtnRegistar"
        Me.BtnRegistar.Size = New System.Drawing.Size(51, 50)
        Me.BtnRegistar.TabIndex = 5
        Me.BtnRegistar.UseVisualStyleBackColor = True
        '
        'BtnRecuperarPass
        '
        Me.BtnRecuperarPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnRecuperarPass.Image = Global.AppFase4Grupo33.My.Resources.Resources.Key_24x24
        Me.BtnRecuperarPass.Location = New System.Drawing.Point(12, 439)
        Me.BtnRecuperarPass.Name = "BtnRecuperarPass"
        Me.BtnRecuperarPass.Size = New System.Drawing.Size(37, 33)
        Me.BtnRecuperarPass.TabIndex = 6
        Me.BtnRecuperarPass.UseVisualStyleBackColor = True
        '
        'LblLogin
        '
        Me.LblLogin.AutoSize = True
        Me.LblLogin.Font = New System.Drawing.Font("Times New Roman", 14.0!)
        Me.LblLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblLogin.Location = New System.Drawing.Point(54, 9)
        Me.LblLogin.Name = "LblLogin"
        Me.LblLogin.Size = New System.Drawing.Size(273, 21)
        Me.LblLogin.TabIndex = 7
        Me.LblLogin.Text = "FASE 4 - DISEÑO MULTIMEDIA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(71, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Código de Usuario "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(71, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Contraseña"
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(384, 484)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblLogin)
        Me.Controls.Add(Me.BtnRecuperarPass)
        Me.Controls.Add(Me.BtnRegistar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.PBoxLogo)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 500)
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancelar As Button
    Friend WithEvents PBoxLogo As PictureBox
    Friend WithEvents TTipMensaje As ToolTip
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnRegistar As Button
    Friend WithEvents BtnRecuperarPass As Button
    Friend WithEvents LblLogin As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
