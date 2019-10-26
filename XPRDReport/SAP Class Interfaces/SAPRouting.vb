Imports Sap.Data.Hana
Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data
Public Class RoutingSAP
    Public Property Kode As String
    Public Property Lokasi As String
End Class

Public Class SAPRouting : Implements IDataLookup
    Public Function Read(ByVal Kriteria As String) As DataSet
        Dim DB As New SAPDBConnection
        Dim SQL As String

        SQL = "SELECT " +
              "     ""Code""              AS ""Kode"", " +
              "     ""Name""              AS ""Rounting"", " +
              "     ""U_HSP_ACCT""        AS ""Acct"" " +
              "FROM ""@SOL_ROUTING"" " +
              "WHERE ""Code"" ||' '||""Name"" LIKE '%" + Kriteria + "%' AND ""U_HSP_ACCT"" IS NOT NULL " +
              "ORDER BY ""Name"" "

        Using DBX As IDbConnection = DB.Connection()

            Dim CMD As New HanaCommand(SQL, DBX)
            Dim DA As New HanaDataAdapter
            Dim DS As New DataSet

            DA.SelectCommand = CMD
            DA.Fill(DS, "View")

            Read = DS
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
