Imports Dapper
Imports XPRDSystem.HSP.Data
Namespace HSP.Data
    Public Class X_Transaksi
        Public Property NoTransaksi As String
        Public Property TglTransaksi As Date
        Public Property KodeItem As String
        Public Property NamaItem As String
        Public Property Transaksi As String
        Public Property Qty As Double
        Public Property satuan As String
        Public Property KodeUnitSAP As String
        Public Property LokasiAsal As String
        Public Property LokasiTujuan As String
    End Class
    Public Class StockSAP
        Public Property KodeLokasi As String
        Public Property KodeItem As String
        Public Property NamaItem As String
        Public Property Stock As Double
        Public Property Satuan As String
    End Class

    Public Class Tmp_Transaksi
        Private _DBConnection As DBConnection

        Sub New(ByVal Session As Object)
            _DBConnection = New DBConnection(Session)
        End Sub

        Public Function Add(ByVal Data As X_Transaksi) As Integer
            Dim SQL As String

            SQL = "INSERT INTO tmp_saptransaction " +
                  "(NoTransaksi,TglTransaksi,KodeItem,NamaItem,Transaksi,Qty,satuan,KodeUnitSAP,LokasiAsal,LokasiTujuan,LastUpdatedon) " +
                  "VALUES " +
                  "(@NoTransaksi,@TglTransaksi,@KodeItem, @NamaItem,@Transaksi,@Qty,@satuan,@KodeUnitSAP,@LokasiAsal,@LokasiTujuan,now())"

            Using DBX As IDbConnection = _DBConnection.Connection
                Add = DBX.Execute(SQL, Data)
            End Using
        End Function

        Public Function Add_Stock(ByVal Data As StockSAP) As Integer
            Dim SQL As String

            SQL = "INSERT INTO tmp_stockSAP " +
                  "(KodeLokasi,KodeItem,NamaItem,Stock,satuan,LastUpdatedon) " +
                  "VALUES " +
                  "(@KodeLokasi,@KodeItem, @NamaItem,@Stock,@satuan,now())"

            Using DBX As IDbConnection = _DBConnection.Connection
                Add_Stock = DBX.Execute(SQL, Data)
            End Using
        End Function

        Public Function DeleteStock() As Integer
            Dim SQL As String

            SQL = "DELETE FROM tmp_stockSAP "

            Using DBX As IDbConnection = _DBConnection.Connection
                DeleteStock = DBX.Execute(SQL)
            End Using
        End Function

        Public Function Delete(ByVal Transaksi As String) As Integer
            Dim SQL As String

            SQL = "DELETE FROM tmp_saptransaction " +
                  "WHERE Transaksi = @Transaksi"

            Using DBX As IDbConnection = _DBConnection.Connection
                Delete = DBX.Execute(SQL, New With {.Transaksi = Transaksi})
            End Using
        End Function

    End Class
End Namespace

