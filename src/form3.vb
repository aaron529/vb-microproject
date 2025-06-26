Public Class Add_Item

Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Items.count = Items.count + 1
    Items.DataGridView1.Rows.Add(Items.count, _
                                  TextBox1.Text, _
                                  TextBox2.Text, _
                                  TextBox3.Text, _
                                  TextBox4.Text, _
                                  TextBox5.Text, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), _
                                  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))

    Call clearAllTextBox()
    Home.Label2.Text = "ITEMS: " & Items.DataGridView1.RowCount
    Items.DataGridView1.Rows(0).Cells(0).Selected = False
    MsgBox("Successfully added item with ID: " & Items.count)
End Sub

Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Call clearAllTextBox()
End Sub

Private Function clearAllTextBox()
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox3.Text = ""
    TextBox4.Text = ""
    TextBox5.Text = ""
End Function
End Class