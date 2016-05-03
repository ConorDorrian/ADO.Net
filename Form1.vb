Imports Oracle.DataAccess.Client

Public Class Form1
    Public con As New OracleConnection
    Public ds As New DataSet



    Public Function Connect() As OracleConnection

        Dim username As String = TextBox1.Text
            Dim password As String = TextBox2.Text

            Dim connectString As String = “Data Source=XE; user id=" & username & ";" & "Password=" & password & ";”

            Dim con As New OracleConnection(connectString)
            con.Open()

            'MsgBox("You are now logged on")


            Return con



    End Function

    Public Function populateDS() As DataSet
        ds = New DataSet
        Dim sql As String
        Dim da As OracleDataAdapter
        sql = "Select * from salesperson"
        da = New OracleDataAdapter(sql, Connect())
        da.Fill(ds, "DT_Salesperson")
        con.Close()
        Return ds
    End Function


    Private Sub Open_Click(sender As Object, e As EventArgs) Handles Open.Click
        'populateDS()
        Try
            Connect()
            Form2.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function CloseDB() As OracleConnection
        con.Close()
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
