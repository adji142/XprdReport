Imports Dapper
Imports XPRDSystem.HSP.Data
Namespace HSP.Data
    Public Class TempStockSAP
        Public Property ID As String
        Public Property KodeItem As String
        Public Property NamaItem As String
        Public Property KodeProduksi As String
        Public Property Qty As Double
    End Class

    Public Class DaftarTempStock
        Private _DBConnection As DBConnection

        Sub New(ByVal Session As Object)
            _DBConnection = New DBConnection(Session)
        End Sub

        Public Function Add(ByVal Data As TempStockSAP) As Integer
            Dim SQL As String

            SQL = "INSERT INTO tempitemstocksap " +
                  "(ID,KodeItem, NamaItem, KodeProduksi, Qty) " +
                  "VALUES " +
                  "(@ID,@KodeItem, @NamaItem, @KodeProduksi, @Qty)"

            Using DBX As IDbConnection = _DBConnection.Connection
                Add = DBX.Execute(SQL, Data)
            End Using
        End Function

        Public Function Delete(ByVal ID As String) As Integer
            Dim SQL As String

            SQL = "DELETE FROM tempitemstocksap WHERE ID = '" + ID + "'"

            Using DBX As IDbConnection = _DBConnection.Connection
                Delete = DBX.Execute(SQL)
            End Using
        End Function
    End Class
End Namespace

