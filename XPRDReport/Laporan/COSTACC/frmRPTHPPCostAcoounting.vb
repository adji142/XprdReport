Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDSystem.HSP.Data
Imports XPRDReport.HSP.Data

Public Class frmRPTHPPCostAcoounting
    Private WithEvents txtTglAwal As New DateTimePicker
    Private WithEvents txtTglAkhir As New DateTimePicker
    Private Sub frmReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        RPT.ShowGroupTreeButton = False
        Toolbar.Items.Insert(4, New ToolStripControlHost(txtTglAwal))
        txtTglAwal.Format = DateTimePickerFormat.Custom
        txtTglAwal.CustomFormat = "dd/MM/yyyy"
        txtTglAwal.Width = 95

        Toolbar.Items.Insert(6, New ToolStripControlHost(txtTglAkhir))
        txtTglAkhir.Format = DateTimePickerFormat.Custom
        txtTglAkhir.CustomFormat = "dd/MM/yyyy"
        txtTglAkhir.Width = 95
        cboLaporan.SelectedIndex = 0
    End Sub
    Private Sub FillCombo()
        Dim DS As DataSet

        'Unit Produksi
        Dim DaftarUnitProduksi As New SAPRouting()

        DS = DaftarUnitProduksi.Read_Account("%")
        cboUnitProduksi.ComboBox.DataSource = DS.Tables("View")
        cboUnitProduksi.ComboBox.DisplayMember = "Rounting"
        cboUnitProduksi.ComboBox.ValueMember = "Kode"

        cboUnitProduksi.ComboBox.SelectedIndex = cboUnitProduksi.Items.Count - 1
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
        Select Case cboLaporan.SelectedIndex
            Case 1
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_PerhitunganHargaPokok_A.RPT")
            Case 2
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_PerhitunganHargaPokok_B.RPT")
            Case 3
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_PerhitunganHargaPokok_C.RPT")
            Case 4
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_PerhitunganHargaPokok_D.RPT")
        End Select

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next

        'Parameter
        'RPTObject.ParameterFields("NOWO").CurrentValues.AddValue(txtNomorWO.Text.Trim)
        RPTObject.ParameterFields("TGLAWAL").CurrentValues.AddValue(txtTglAwal.Value.Date)
        RPTObject.ParameterFields("TGLAKHIR").CurrentValues.AddValue(txtTglAkhir.Value.Date)
        Select Case cboLaporan.SelectedIndex
            Case 1
                RPTObject.ParameterFields("NOWO").CurrentValues.AddValue(txtNoWO.Text)
            Case 2
                RPTObject.ParameterFields("UNIT").CurrentValues.AddValue(cboUnitProduksi.ComboBox.SelectedValue)
            Case 3
                RPTObject.ParameterFields("ROUTING").CurrentValues.AddValue(cboUnitProduksi.ComboBox.SelectedValue)
        End Select

        'Informasi
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"
        RPTObject.DataDefinition.FormulaFields("Periode").Text = "'PER :  " + Now.ToString("dd-MM-yyyy HH:mm:ss") + "'"

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

    Private Sub cboLaporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLaporan.SelectedIndexChanged
        Select Case cboLaporan.SelectedIndex
            Case 1
                lblunit.Visible = False
                cboUnitProduksi.Visible = False

                lblnowo.Visible = True
                txtNoWO.Visible = True
            Case 2
                lblnowo.Visible = False
                txtNoWO.Visible = False

                lblunit.Visible = True
                cboUnitProduksi.Visible = True

                FillCombo()
            Case 3
                lblnowo.Visible = False
                txtNoWO.Visible = False

                lblunit.Visible = True
                cboUnitProduksi.Visible = True

                FillCombo()
            Case 4
                lblunit.Visible = False
                cboUnitProduksi.Visible = False

                lblnowo.Visible = False
                txtNoWO.Visible = False
        End Select
    End Sub
End Class
