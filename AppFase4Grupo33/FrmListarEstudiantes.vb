Imports BaseDatosBiblioteca.BD_SqlMdf

Public Class FrmListarEstudiantes

    Dim LibBaseDatos As BaseDatosBiblioteca.BD_SqlMdf
    Private Sub FrmListarEstudiantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Dt As New DataTable
        '>>> se crea la consulta a Realizar "Todos lo Usuarios Existente en la Base de Datos "
        Dim sQuery As String = "select Id_registro,Tipo_Documento,Num_Documento,Nombres,Apellidos,Correo,Telefono,Password,Rol from TbEstudiantes "
        LibBaseDatos = New BaseDatosBiblioteca.BD_SqlMdf
        Dt = LibBaseDatos.Ejecutar_SqlMDF(sQuery)

        DGridEstudiantes.DataSource = Dt
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class