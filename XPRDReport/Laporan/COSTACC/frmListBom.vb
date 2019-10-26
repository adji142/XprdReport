Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data
Public Class frmListBom

    Private Sub frmListBom_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        RPT.ShowGroupTreeButton = False
        Dim DS As DataSet
        Dim Drow As DataRow

        Dim DaftarKelompokItem As New DaftarSAPKelompokItem()

        DS = DaftarKelompokItem.Read("%", "187,188,189,190,191,192,193,194,195,197")
        cboRouting.ComboBox.DataSource = DS.Tables("View")
        cboRouting.ComboBox.DisplayMember = "Kelompok"
        cboRouting.ComboBox.ValueMember = "Kode"

        Drow = DS.Tables("View").Rows.Add
        Drow("Kelompok") = "<SEMUA>"
        Drow("Kode") = ""
        cboRouting.SelectedIndex = -1
    End Sub
    Private Sub cboKodeUnit_Click(sender As Object, e As EventArgs)

    End Sub

    'Tampilkan Laporan
    Private Sub btRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btRefresh.Click
        Dim Server As New ConnectionInfo
        Dim DataTable As Table

        Me.Cursor = Cursors.WaitCursor
        '-----------------------------------------------------------------------------------------   

        '-----------------------------------------------------------------------------------------   
        Dim DBX As Object = New DBConnection(ActiveSession).ConnectionSetting()

        'Setting Koneksi Database
        With Server
            .ServerName = "192.168.1.222:30015"
            .DatabaseName = "HARDO_LIVE"
            .UserID = "SYSTEM"
            .Password = "sys825050SYS"
        End With
        '-----------------------------------------------------------------------------------------

        Dim RPTObject As New ReportDocument

        'Report
        RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "Reports\System\Rpt_ListBOMSAP.RPT")

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next

        'MessageBox.Show(txtTglAwal.Value.Date)
        'Parameter
        RPTObject.ParameterFields("GROUPITEM").CurrentValues.AddValue(cboRouting.ComboBox.SelectedValue)


        'Informasi
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + ActiveSession.KodeUser + "'"
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"

        RPT.ReportSource = RPTObject
        HideTabControl(RPT)

        RPT.Refresh()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub HideTabControl(ByVal RPT As Object)
        For Each control As Control In RPT.Controls
            If TypeOf control Is CrystalDecisions.Windows.Forms.PageView Then
                Dim tab As TabControl = DirectCast(DirectCast(control, CrystalDecisions.Windows.Forms.PageView).Controls(0), TabControl)
                tab.ItemSize = New Size(0, 1)
                tab.SizeMode = TabSizeMode.Fixed
                tab.Appearance = TabAppearance.Buttons
            End If
        Next
    End Sub

End Class
