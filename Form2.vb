Imports Oracle.DataAccess.Client
Public Class Form2
    Public con As New OracleConnection
    Public ds1 As New DataSet

    'Public Function Connect() As OracleConnection
    'Dim username = "password"
    'Dim password = "conor"
    'Dim connectString As String = “Data Source=XE; user id=" & username & ";" & "Password=" & password & ";”
    '
    'Dim con As New OracleConnection(connectString)
    '   con.Open()

    '  MsgBox("You are now on Stored Cars")


    'Return con

    'End Function

    Public Function populateDS1() As DataSet
        ds1 = New DataSet
        Dim sql As String
        Dim da As OracleDataAdapter
        sql = "Select * from storedcars"
        da = New OracleDataAdapter(sql, Form1.Connect())
        da.Fill(ds1, "DT_StoredCars")
        con.Close()
        Return ds1
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.populateDS()
        Dim SalesPersonTable As New DataTable

        SalesPersonTable = Form1.ds.Tables("DT_SalesPerson")
        DataGridView1.DataSource = SalesPersonTable

    End Sub


    Private Sub AddRec_Click(sender As Object, e As EventArgs) Handles AddRec.Click
        Dim ds As New DataSet
        Dim cmd As New OracleCommand("Conor.ADDSALESPERSON", Form1.Connect())

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SPID", Val(spid.Text))
        cmd.Parameters.Add("@SPNAME", (SPName.Text))
        cmd.Parameters.Add("@SPPHONENUMBER", Val(Number.Text))
        cmd.Parameters.Add("@SPADDRESS", (Address.Text))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("AddRecord")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ds = Form1.populateDS()
        DataGridView1.DataSource = ds.Tables("DT_salesperson")
    End Sub

    Private Sub DeleteRec_Click(sender As Object, e As EventArgs) Handles DeleteRec.Click
        Dim ds As New DataSet
        Dim con As New OracleConnection
        con = Form1.Connect()

        Dim cmd As New OracleCommand("Conor.DELETESALESPERSON", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SPID", Val(spid.Text))
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Sales Person deleted")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ds = Form1.populateDS()
        DataGridView1.DataSource = ds.Tables("DT_salesperson")
    End Sub

    ' Private Sub Reload_Click(sender As Object, e As EventArgs) Handles Reload.Click
    'Dim ds As New DataSet
    '   ds = Form1.populateDS()
    '  DataGridView1.DataSource = ds.Tables("DT_salesperson")

    'End Sub

    Private Sub EditTable_Click(sender As Object, e As EventArgs) Handles EditTable.Click
        Dim ds As New DataSet
        Dim con As New OracleConnection
        con = Form1.Connect()

        Dim cmd As New OracleCommand("Conor.EDITSALESPERSON", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SPID", Val(spid.Text))
        cmd.Parameters.Add("@SPNAME", (SPName.Text))
        cmd.Parameters.Add("@SPPHONENUMBER", Val(Number.Text))
        cmd.Parameters.Add("@SPADDRESS", (Address.Text))
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Sales Person updated")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ds = Form1.populateDS()
        DataGridView1.DataSource = ds.Tables("DT_salesperson")
    End Sub

    Private Sub VehicleTable_Click(sender As Object, e As EventArgs) Handles VehicleTable.Click
        'populateDS1()
        Form3.Show()
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        spid.Clear()
        SPName.Clear()
        Number.Clear()
        Address.Clear()

    End Sub

    Public Function CloseDB() As OracleConnection
        con.Close()
    End Function
End Class