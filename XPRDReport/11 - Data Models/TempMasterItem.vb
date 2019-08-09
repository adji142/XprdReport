Imports Dapper
Imports XPRDSystem.HSP.Data
Namespace HSP.Data
    Public Class TmpMasterItemSAP
        Public Property ItemCode As String
        Public Property ItemName As String
        Public Property UnitProduksi As String
        Public Property PjgStandar As Double
        Public Property BeratSTD As Double
    End Class

    Public Class TempMasterItem
        Private _DBConnection As DBConnection

        Sub New(ByVal Session As Object)
            _DBConnection = New DBConnection(Session)
        End Sub

        Public Function Add(ByVal Data As XPRDReport.TmpMasterItemSAP) As Integer
            Dim SQL As String

            SQL = "INSERT INTO TmpMasterItemSAP " +
                  "(ItemCode, ItemName, UnitProduksi, PjgStandar,BeratSTD,LastUpdated) " +
                  "VALUES " +
                  "(@ItemCode, @ItemName, @UnitProduksi, @PjgStandar,@BeratSTD,now())"

            Using DBX As IDbConnection = _DBConnection.Connection
                Add = DBX.Execute(SQL, Data)
            End Using
        End Function

        Public Function Delete() As Integer
            Dim SQL As String

            SQL = "DELETE FROM TmpMasterItemSAP "

            Using DBX As IDbConnection = _DBConnection.Connection
                Delete = DBX.Execute(SQL)
            End Using
        End Function

    End Class
End Namespace

