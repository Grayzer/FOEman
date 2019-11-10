﻿

Public Class Form1
    Friend BC_name As New List(Of String)
    Friend BC_lvl As New List(Of String)
    Friend BC_MaxCO As New List(Of String)
    Friend BC_COBack As New List(Of String)
    Friend doc As XDocument = XDocument.Load(".\BC_List.xml")
    Friend CO1 As New Integer
    Friend CO2 As New Integer
    Friend CO3 As New Integer
    Friend CO4 As New Integer
    Friend CO5 As New Integer


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox6.Checked Then NumericUpDown1.Value = "1,50"
        If CheckBox7.Checked Then NumericUpDown2.Value = "1,50"
        If CheckBox8.Checked Then NumericUpDown3.Value = "1,50"
        If CheckBox9.Checked Then NumericUpDown4.Value = "1,50"
        If CheckBox10.Checked Then NumericUpDown5.Value = "1,50"
        NumericUpDown1.Refresh()
        NumericUpDown2.Refresh()
        NumericUpDown3.Refresh()
        NumericUpDown4.Refresh()
        NumericUpDown5.Refresh()
        COfill()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CheckBox6.Checked Then NumericUpDown1.Value = "1,80"
        If CheckBox7.Checked Then NumericUpDown2.Value = "1,80"
        If CheckBox8.Checked Then NumericUpDown3.Value = "1,80"
        If CheckBox9.Checked Then NumericUpDown4.Value = "1,80"
        If CheckBox10.Checked Then NumericUpDown5.Value = "1,80"
        NumericUpDown1.Refresh()
        NumericUpDown2.Refresh()
        NumericUpDown3.Refresh()
        NumericUpDown4.Refresh()
        NumericUpDown5.Refresh()
        COfill()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If CheckBox6.Checked Then NumericUpDown1.Value = "1,85"
        If CheckBox7.Checked Then NumericUpDown2.Value = "1,85"
        If CheckBox8.Checked Then NumericUpDown3.Value = "1,85"
        If CheckBox9.Checked Then NumericUpDown4.Value = "1,85"
        If CheckBox10.Checked Then NumericUpDown5.Value = "1,85"
        NumericUpDown1.Refresh()
        NumericUpDown2.Refresh()
        NumericUpDown3.Refresh()
        NumericUpDown4.Refresh()
        NumericUpDown5.Refresh()
        COfill()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If CheckBox6.Checked Then NumericUpDown1.Value = "1,90"
        If CheckBox7.Checked Then NumericUpDown2.Value = "1,90"
        If CheckBox8.Checked Then NumericUpDown3.Value = "1,90"
        If CheckBox9.Checked Then NumericUpDown4.Value = "1,90"
        If CheckBox10.Checked Then NumericUpDown5.Value = "1,90"
        NumericUpDown1.Refresh()
        NumericUpDown2.Refresh()
        NumericUpDown3.Refresh()
        NumericUpDown4.Refresh()
        NumericUpDown5.Refresh()
        COfill()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        BC_name = (From element In doc.Descendants("BCList").Elements("BC").Attributes("name") Select element.Value).ToList()
        Dim BC_lvl As New List(Of String)
        BC_lvl.Clear()


        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox1.DataSource = BC_name


        BC_lvl = (From ccc In doc.Descendants("BCList").Elements("BC")
                  Where ccc.Attribute("name").Value = ComboBox1.SelectedItem
                  From ddd In ccc.Elements("level")
                  Select ddd.Value).ToList()

        BC_MaxCO = (From ccc In doc.Descendants("BCList").Elements("BC")
                    Where ccc.Attribute("name").Value = ComboBox1.SelectedItem
                    From ddd In ccc.Elements("level").Attributes("maxCO")
                    Select ddd.Value).ToList()

        BC_COBack = (From ccc In doc.Descendants("BCList").Elements("BC")
                     Where ccc.Attribute("name").Value = ComboBox1.SelectedItem
                     From ddd In ccc.Elements("level").Attributes("COBack")
                     Select ddd.Value).ToList()

        ComboBox2.DataSource = BC_lvl


        Label12.Text = BC_lvl.Count.ToString()


        COfill()





    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        BC_lvl.Clear()
        BC_MaxCO.Clear()
        BC_COBack.Clear()


        BC_lvl = (From ccc In doc.Descendants("BCList").Elements("BC")
                  Where ccc.Attribute("name").Value = ComboBox1.SelectedItem
                  From ddd In ccc.Elements("level")
                  Select ddd.Value).ToList()

        BC_MaxCO = (From ccc In doc.Descendants("BCList").Elements("BC")
                    Where ccc.Attribute("name").Value = ComboBox1.SelectedItem
                    From ddd In ccc.Elements("level").Attributes("maxCO")
                    Select ddd.Value).ToList()

        BC_COBack = (From ccc In doc.Descendants("BCList").Elements("BC")
                     Where ccc.Attribute("name").Value = ComboBox1.SelectedItem
                     From ddd In ccc.Elements("level").Attributes("COBack")
                     Select ddd.Value).ToList()

        ComboBox2.DataSource = BC_lvl

        Label12.Text = BC_lvl.Count.ToString()


        COfill()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        COfill()
    End Sub

    Public Sub COfill()
        CO1 = BC_COBack.Item(ComboBox2.SelectedIndex)
        CO2 = Math.Round(CO1 / 10, 0, MidpointRounding.AwayFromZero) * 5
        CO3 = Math.Round(CO2 / 15, 0, MidpointRounding.AwayFromZero) * 5
        CO4 = Math.Round(CO3 / 20, 0, MidpointRounding.AwayFromZero) * 5
        CO5 = Math.Round(CO4 / 25, 0, MidpointRounding.AwayFromZero) * 5



        Label1.Text = CO1.ToString
        Label2.Text = CO2.ToString
        Label3.Text = CO3.ToString
        Label4.Text = CO4.ToString
        Label5.Text = CO5.ToString

        Label6.Text = Math.Round(CO1 * NumericUpDown1.Value, 0, MidpointRounding.AwayFromZero)
        Label7.Text = Math.Round(CO2 * NumericUpDown2.Value, 0, MidpointRounding.AwayFromZero)
        Label8.Text = Math.Round(CO3 * NumericUpDown3.Value, 0, MidpointRounding.AwayFromZero)
        Label9.Text = Math.Round(CO4 * NumericUpDown4.Value, 0, MidpointRounding.AwayFromZero)
        Label10.Text = Math.Round(CO5 * NumericUpDown5.Value, 0, MidpointRounding.AwayFromZero)

        Label16.Text = BC_MaxCO.Item(ComboBox2.SelectedIndex).ToString
        Label18.Text = Label16.Text

        If CheckBox5.Checked Then Label18.Text = Label16.Text - (Label10.Text * 2)
        If CheckBox4.Checked Then Label18.Text = Label16.Text - (Label9.Text * 2)
        If CheckBox3.Checked Then Label18.Text = Label16.Text - (Label8.Text * 2)
        If CheckBox2.Checked Then Label18.Text = Label16.Text - (Label7.Text * 2)
        If CheckBox1.Checked Then Label18.Text = Label16.Text - (Label6.Text * 2)

        TextBox6.Text = ComboBox1.SelectedItem + " [" + Label18.Text + "/" + Label16.Text + "]"
        If CheckBox1.Checked Then TextBox6.Text = TextBox6.Text + " 1е " + Label6.Text + "(" + Label1.Text + ")"
        If CheckBox1.Checked And CheckBox11.Checked Then TextBox6.Text = TextBox6.Text + " прикрыто." Else If CheckBox1.Checked Then TextBox6.Text = TextBox6.Text + "."
        If CheckBox2.Checked Then TextBox6.Text = TextBox6.Text + " 2е " + Label7.Text + "(" + Label2.Text + ")"
        If CheckBox2.Checked And CheckBox12.Checked Then TextBox6.Text = TextBox6.Text + " прикрыто." Else If CheckBox2.Checked Then TextBox6.Text = TextBox6.Text + "."
        If CheckBox3.Checked Then TextBox6.Text = TextBox6.Text + " 3е " + Label8.Text + "(" + Label3.Text + ")"
        If CheckBox3.Checked And CheckBox13.Checked Then TextBox6.Text = TextBox6.Text + " прикрыто." Else If CheckBox3.Checked Then TextBox6.Text = TextBox6.Text + "."
        If CheckBox4.Checked Then TextBox6.Text = TextBox6.Text + " 4е " + Label9.Text + "(" + Label4.Text + ")"
        If CheckBox4.Checked And CheckBox14.Checked Then TextBox6.Text = TextBox6.Text + " прикрыто." Else If CheckBox4.Checked Then TextBox6.Text = TextBox6.Text + "."
        If CheckBox5.Checked Then TextBox6.Text = TextBox6.Text + " 5е " + Label10.Text + "(" + Label5.Text + ")"
        If CheckBox5.Checked And CheckBox15.Checked Then TextBox6.Text = TextBox6.Text + " прикрыто." Else If CheckBox5.Checked Then TextBox6.Text = TextBox6.Text + "."


    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.Click
        COfill()
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.Click
        COfill()
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.Click
        COfill()
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.Click
        COfill()
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.Click
        COfill()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.Click, CheckBox11.Click
        COfill()

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.Click, CheckBox12.Click
        COfill()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.Click, CheckBox13.Click
        COfill()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.Click, CheckBox14.Click
        COfill()
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.Click, CheckBox15.Click
        COfill()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clipboard.SetText(TextBox6.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim qqq As New Integer
        Dim www As New Integer
        Dim rrr As New Integer
        qqq = TextBox1.Text
        rrr = TextBox2.Text
        www = Math.Abs(Int(Math.Round((((-(rrr - 25)) + (Math.Round(Math.Sqrt((((rrr - 25) * (rrr - 25)) - (-qqq * 100))), 0, MidpointRounding.ToEven)))) / 50, 0, MidpointRounding.ToEven)))
        TextBox3.Text = www.ToString
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub
End Class