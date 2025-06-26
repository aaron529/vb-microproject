Public Class Home

Dim currentPanel As Integer

Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LoadChildForm(Items)
    HomeBtn.Enabled = False
    Label2.Text = "ITEMS" & Items.Count
End Sub

Private Sub LoadChildForm(ByVal childForm As Form)
    childForm.TopLevel = False
    childForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    childForm.Dock = DockStyle.Fill
    Panel1.Controls.Clear()
    Panel1.Controls.Add(childForm)
    childForm.Show()
End Sub

Private Sub HomeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeBtn.Click
    LoadChildForm(Items)
    Call updateButtons(HomeBtn, 1)
    For Each Item As DataGridViewRow In Items.DataGridView1.Rows
        Item.Visible = True
    Next
End Sub

Private Sub AddItemBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click
    LoadChildForm(Add_Item)
    Call updateButtons(AddItemBtn, 2)
End Sub

Private Sub RemItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemItemBtn.Click
    Dim selection As String = ""
    For Each Item As DataGridViewRow In Items.DataGridView1.SelectedRows
        If Not String.IsNullOrEmpty(selection) Then
            selection = selection & ", " & selectedRow.Cells(0).Value
        Else
            selection = selectedRow.Cells(0).Value
        End If
    Next
    If Not String.IsNullOrEmpty(selection) Then
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete item with id: " & selection, _
                                                  "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.Yes Then
            For Each selectedRow As DataGridViewRow In Items.DataGridView1.SelectedRows
                Items.DataGridView1.Rows.Remove(selectedRow.Index)
            Next
            Label2.Text = "ITEMS: " & Items.DataGridView1.RowCount
        End If
    Else
        MessageBox.Show("Please select a row to delete!", "Error")
    End If
End Sub

Private Sub EditItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItemBtn.Click
    If Items.DataGridView1.SelectedRows.Count = 1 Then
        LoadChildForm(EditItem)
        Edit_updateID()
        Call updateButtons(EditItemBtn, 4)
    Else
        MessageBox.Show("Please select a single row!", "Error")
    End If
End Sub

Private Sub SearchItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchItemBtn.Click
    Dim query As String = InputBox("Enter the item name to query...")

    If Not String.IsNullOrEmpty(query) Then
        LoadChildForm(Items)
        For Each Item As DataGridViewRow In Items.DataGridView1.Rows
            Item.Selected = False
        Next
        For Each Item As DataGridViewRow In Items.DataGridView1.Rows
            'LCase for comparing without case sensitive
			If Not (LCase(Item.Cells(1).Value).Contains(LCase(query))) Then
				Item.Visible = False
			End If
		Next
		
		Call updateButtons(SearchItemBtn, 5)
	End If
End Sub

Function updateButtons(ByVal btn As Button, ByVal val As Integer)
	If currentPanel = 1 Then
		HomeBtn.Enabled = True
		btn.Enabled = False
		currentPanel = val
	ElseIf currentPanel = 2 Then
		AddItemBtn.Enabled = True
		btn.Enabled = False
		currentPanel = val
	ElseIf currentPanel = 3 Then
		RemItemBtn.Enabled = True
		btn.Enabled = False
		currentPanel = val
	ElseIf currentPanel = 4 Then
		EditItemBtn.Enabled = True
		btn.Enabled = False
		currentPanel = val
	ElseIf currentPanel = 5 Then
		SearchItemBtn.Enabled = True
		btn.Enabled = False
		currentPanel = val
	End If
	End Function
End Class