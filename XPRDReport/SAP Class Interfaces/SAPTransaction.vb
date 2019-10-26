Imports Sap.Data.Hana
Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data
Public Class Transaksi
    Public Property Kode As String
    Public Property Lokasi As String
End Class

Public Class SAPTransaction : Implements IDataLookup
    Public Function Read(ByVal TglAwal As Date, ByVal TglAkhit As Date, ByVal Transaksi As String, ByVal Unit As String) As DataSet
        Dim DB As New SAPDBConnection
        Dim SQL As String

        SQL = "SELECT * FROM HSP_TRANSACTION_PER_REF2 WHERE ""DocDate"" BETWEEN '" + TglAwal.ToString("yyyy-M-dd") + "' AND '" + TglAkhit.ToString("yyyy-M-dd") + "' AND ""Transaksi"" = '" + Transaksi + "'  "
        If Unit <> "" Then
            SQL += "AND (U_SOL_ROUTING = '" + Unit + "')"
        End If

        Using DBX As IDbConnection = DB.Connection()

            Dim CMD As New HanaCommand(SQL, DBX)
            Dim DA As New HanaDataAdapter
            Dim DS As New DataSet

            DA.SelectCommand = CMD
            DA.Fill(DS, "View")

            Read = DS
        End Using
    End Function
    Public Function Read_StockPerLokasi(ByVal KodeLokasi) As DataSet
        Dim DB As New SAPDBConnection
        Dim SQL As String

        SQL = "SELECT " +
            "A.""WhsCode""								AS ""KodeLokasi"", " +
            "A.""ItemCode""							    AS ""KodeItem"", " +
            "B.""ItemName""							    AS ""NamaItem"", " +
            "A.""OnHand""								AS ""Stock""," +
            "B.""InvntryUom""							AS ""Satuan"" " +
            "FROM	OITW A " +
            "LEFT JOIN OITM B ON B.""ItemCode""=A.""ItemCode"" " +
            "WHERE 	A.""OnHand""<>0 AND A.""WhsCode"" = '" + KodeLokasi + "' " +
            "AND B.""ItmsGrpCod"" IN (187,188,189,190,191,192,193,194,195,197) " +
            "ORDER BY A.""ItemCode"" "

        Using DBX As IDbConnection = DB.Connection()

            Dim CMD As New HanaCommand(SQL, DBX)
            Dim DA As New HanaDataAdapter
            Dim DS As New DataSet

            DA.SelectCommand = CMD
            DA.Fill(DS, "View")

            Read_StockPerLokasi = DS
        End Using
    End Function
    Public Function Read_Account(ByVal Kriteria As String) As DataSet
        Dim DB As New SAPDBConnection
        Dim SQL As String

        SQL = "SELECT " +
              "     ""AcctCode""              AS ""Kode"", " +
              "     ""AcctName""              AS ""Rounting"" " +
              "FROM OACT " +
              "WHERE LEFT(""AcctCode"",4) = '1163' " +
              "ORDER BY ""AcctCode"" "

        Using DBX As IDbConnection = DB.Connection()

            Dim CMD As New HanaCommand(SQL, DBX)
            Dim DA As New HanaDataAdapter
            Dim DS As New DataSet

            DA.SelectCommand = CMD
            DA.Fill(DS, "View")

            Read_Account = DS
        End Using
    End Function
    Public Function GetLookup(TextSearch As String, Parameter As Object) As DataSet Implements IDataLookup.GetLookup
        Dim DB As New SAPDBConnection
        Dim SQL As String

        SQL = "SELECT " +
              "     ""Code""        AS ""Kode"", " +
              "     ""Name""        AS ""Rounting"" " +
              "FROM ""@SOL_ROUTING"" " +
              "WHERE ""Code"" ||' '||""Name"" LIKE '%" + TextSearch + "%' " +
              "ORDER BY ""Name"" "

        Using DBX As IDbConnection = DB.Connection()

            Dim CMD As New HanaCommand(SQL, DBX)
            Dim DA As New HanaDataAdapter
            Dim DS As New DataSet

            DA.SelectCommand = CMD
            DA.Fill(DS, "Lookup")

            GetLookup = DS
        End Using
    End Function
End Class
