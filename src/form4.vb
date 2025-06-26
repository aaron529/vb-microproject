Public Class Form4

Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim ItemRow As DataGridViewRow = Items.DataGridView1.SelectedRows(0)
    If Not String.IsNullOrEmpty(TextBox1.Text) Then
        ItemRow.Cells(1).Value = TextBox1.Text
    End If
    If Not String.IsNullOrEmpty(TextBox2.Text) Then
        ItemRow.Cells(2).Value = TextBox2.Text
    End If
    If Not String.IsNullOrEmpty(TextBox3.Text) Then
        ItemRow.Cells(3).Value = TextBox3.Text
    End If
    If Not String.IsNullOrEmpty(TextBox4.Text) Then
        ItemRow.Cells(4).Value = TextBox4.Text
    End If
    If Not String.IsNullOrEmpty(TextBox5.Text) Then
        ItemRow.Cells(5).Value = TextBox5.Text
    End If

    ItemRow.Cells(7).Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

    Call clearAllTextBox()
    MessageBox.Show("Updated the item", "Success")
    Home.LoadChildForm(Items)
    Call Home.updateButtons(Home.HomeBtn, 1)
End Sub

Private Function clearAllTextBox()
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    TextBox4.Text = ""
    TextBox5.Text = ""
    TextBox6.Text = ""
End Function

Function updateID()
    TextBox6.Text = Items.DataGridView1.SelectedRows(0).Cells(0).Value
End Function

Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Home.LoadChildForm(Items)
    Call Home.updateButtons(Home.HomeBtn, 1)
End Sub
End Class