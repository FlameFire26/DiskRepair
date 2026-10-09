Public Class Form1
    Public Drives() As IO.DriveInfo = IO.DriveInfo.GetDrives()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Drive As Integer = 0 To Drives.Length - 1
            If Drives(Drive).IsReady Then
                ComboBox1.Items.Add(Replace(Drives(Drive).Name, "\", ""))
            End If
        Next
        ComboBox1.Text = "选择盘符"
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        ComboBox1.Text = UCase(ComboBox1.Text)
        If InComboBoxItems(ComboBox1, ComboBox1.Text) Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Chkdsk(ComboBox1.Text, CheckBox1.Checked, CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("使用命令提示符(cmd)执行chkdsk命令")
    End Sub
End Class