Imports Oracle.DataAccess.Client

Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SalesPersonTable As New DataTable
        Form2.populateDS1()
        SalesPersonTable = Form2.ds1.Tables("DT_storedCars")
        DataGridView2.DataSource = SalesPersonTable
    End Sub
    Private Function fillGridWithCars()

    End Function

    'Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
    'Dim ds As New DataSet
    '   ds = Form1.populateDS()
    '  DataGridView2.DataSource = ds.Tables("DT_storedCars")
    'End Sub

    Private Sub AddRec_Click(sender As Object, e As EventArgs) Handles AddRec.Click
        Dim cmd As New OracleCommand("Conor.ADDSTOREDCARS", Form1.Connect())

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SPID", Val(spid.Text))
        cmd.Parameters.Add("@MAKE", (CarMake.Text))
        cmd.Parameters.Add("@CARMODEL", (CarModel.Text))
        cmd.Parameters.Add("@REG", (CarReg.Text))
        cmd.Parameters.Add("@VEHICLEID", (CarId.Text))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("AddRecord")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim ds1 As New DataSet
        ds1 = Form2.populateDS1()
        DataGridView2.DataSource = ds1.Tables("DT_storedCars")
    End Sub

    Private Sub CarDelete_Click(sender As Object, e As EventArgs) Handles CarDelete.Click
        Dim ds1 As New DataSet
        Dim con As New OracleConnection
        con = Form1.Connect()

        Dim cmd As New OracleCommand("Conor.DELETESTOREDCARS", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@s_VEHICLEID", CarId.Text)
        'cmd.Parameters.Add("@VEHICLEID", Val(CarId.Text))
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Vehicle deleted")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ds1 = Form2.populateDS1()
        DataGridView2.DataSource = ds1.Tables("DT_storedCars")

    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        spid.Clear()
        CarMake.Clear()
        CarModel.Clear()
        CarReg.Clear()
        CarId.Clear()
    End Sub

    Private Sub EditTable_Click(sender As Object, e As EventArgs) Handles EditTable.Click
        Dim ds1 As New DataSet
        Dim con As New OracleConnection
        con = Form1.Connect()

        Dim cmd As New OracleCommand("Conor.EDITSTOREDCARS", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@SPID", Val(spid.Text))
        cmd.Parameters.Add("@MAKE", (CarMake.Text))
        cmd.Parameters.Add("@CARMODEL", (CarModel.Text))
        cmd.Parameters.Add("@REG", (CarReg.Text))
        cmd.Parameters.Add("@VEHICLEID", (CarId.Text))
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Sales Person updated")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ds1 = Form2.populateDS1()
        DataGridView2.DataSource = ds1.Tables("DT_storedcars")
    End Sub
End Class