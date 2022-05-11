Public Class FrmMdi
    Private Sub FrmMdi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FrmLogin.ShowDialog()
    End Sub

    Private Sub ListaDeEstudiantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeEstudiantesToolStripMenuItem.Click

        Dim FrmChild As Form
        FrmChild = FrmListarEstudiantes
        FrmChild.MdiParent = Me
        FrmChild.Show()


    End Sub
End Class