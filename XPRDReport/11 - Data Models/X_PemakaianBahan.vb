Imports Dapper
Imports XPRDSystem.HSP.Data
Namespace HSP.Data
    Public Class X_PemakaianBahan
        Public Property NoTransaksi As String
        Public Property NomorWO As String
        Public Property KodeItem As String
        Public Property NamaItem As String
    End Class
    Public Class TmpWO
        Public Property NoTransaksi As String
        Public Property NomorWO As String
    End Class

    Public Class X_DaftarPemakaianBahan
        Private _DBConnection As DBConnection

        Sub New(ByVal Session As Object)
            _DBConnection = New DBConnection(Session)
        End Sub

        Public Function Add(ByVal Data As X_PemakaianBahan) As Integer
            Dim SQL As String

            SQL = "INSERT INTO x_pemakaianbahan " +
                  "(NoTransaksi, NomorWO, KodeItem, NamaItem) " +
                  "VALUES " +
                  "(@NoTransaksi, @NomorWO, @KodeItem, @NamaItem)"

            Using DBX As IDbConnection = _DBConnection.Connection
                Add = DBX.Execute(SQL, Data)
            End Using
        End Function

        Public Function Delete(ByVal NoTransaksi As String) As Integer
            Dim SQL As String

            SQL = "DELETE FROM x_pemakaianbahan " +
                  "WHERE NoTransaksi = @NoTransaksi"

            Using DBX As IDbConnection = _DBConnection.Connection
                Delete = DBX.Execute(SQL, New With {.NoTransaksi = NoTransaksi})
            End Using
        End Function

        Public Function Add_RMWO(ByVal Data As XPRDReport.TmpWO) As Integer
            Dim SQL As String

            SQL = "INSERT INTO tmp_RMWO " +
                  "VALUES " +
                  "(@NoTransaksi, @NomorWO, now())"

            Using DBX As IDbConnection = _DBConnection.Connection
                Add_RMWO = DBX.Execute(SQL, Data)
            End Using
        End Function
        Public Function Delete_RMWO()
            Dim SQL As String

            SQL = "DELETE FROM tmp_RMWO "

            Using DBX As IDbConnection = _DBConnection.Connection
                Delete_RMWO = DBX.Execute(SQL)
            End Using
        End Function

    End Class
End Namespace

