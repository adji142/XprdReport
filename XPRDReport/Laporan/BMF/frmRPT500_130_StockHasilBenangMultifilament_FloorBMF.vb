Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDSystem.HSP.Data
Imports XPRDReport.HSP.Data

Public Class frmRPT500_130_StockHasilBenangMultifilament_FloorBMF
    Private ID As String
    Private WithEvents txtTglAwal As New DateTimePicker
    Private WithEvents txtTglAkhir As New DateTimePicker

    Private Sub FillCombo()
        Dim DaftarLokasiProduksi As New DaftarLokasi(ActiveSession)
        Dim DS As DataSet

        DS = New DataSet
        DS = DaftarLokasiProduksi.Read(XPRDReport.HSP.Data.Lokasi.enumLokasiProduksi.FloorBMF)
        cboKodeLokasi.ComboBox.DataSource = DS.Tables("View")
        cboKodeLokasi.ComboBox.DisplayMember = "Nama Lokasi"
        cboKodeLokasi.ComboBox.ValueMember = "Kode"

        Dim Drow As DataRow = DS.Tables("View").Rows.Add
        Drow("Kode") = ""
        Drow("Nama Lokasi") = "<SEMUA>"
    End Sub

    Private Sub frmReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ID = ActiveSession.KodeUser & Now.ToString("ddMMyyyyHHmmss") & cboKodeLokasi.ComboBox.SelectedValue & ActiveSession.KodeUser

        RPT.ShowGroupTreeButton = False

        FillCombo()

        Toolbar.Items.Insert(1, New ToolStripControlHost(txtTglAwal))
        txtTglAwal.Format = DateTimePickerFormat.Custom
        txtTglAwal.CustomFormat = "dd/MM/yyyy"
        txtTglAwal.Width = 95

        Toolbar.Items.Insert(3, New ToolStripControlHost(txtTglAkhir))
        txtTglAkhir.Format = DateTimePickerFormat.Custom
        txtTglAkhir.CustomFormat = "dd/MM/yyyy"
        txtTglAkhir.Width = 95

        txtTglAkhir.Visible = False
        txtTglAwal.Visible = False
        ToolStripLabel3.Visible = False
        ToolStripLabel4.Visible = False

        cboLaporan.SelectedIndex = 0
        ProgressBar.Visible = False
    End Sub

    Private Sub AmbilStockSap()
        Dim SAP As New SAPInventory()
        Dim DS As DataSet

        DS = SAP.ReadStock("MULTIFILAMENT", cboKodeLokasi.ComboBox.SelectedValue)

        Dim DaftarTempStock As New DaftarTempStock(ActiveSession)
        Dim TempStock As New TempStockSAP

        'Hapus Temporary
        DaftarTempStock.Delete(ID)

        Dim Record As Integer = DS.Tables("View").Rows.Count
        ProgressBar.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Maximum = Record

        For Each DR As DataRow In DS.Tables("View").Rows
            TempStock.ID = ID
            TempStock.KodeItem = DR("KodeItem")
            TempStock.NamaItem = DR("NamaItem")
            TempStock.KodeProduksi = DR("KodeProduksi")
            TempStock.Qty = DR("Qty")

            DaftarTempStock.Add(TempStock)

            ProgressBar.Value += 1
        Next
        If ProgressBar.Value = Record Then
            ProgressBar.Visible = False
        End If
    End Sub

    'Tampilkan Laporan
    Private Sub btRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btRefresh.Click
        Dim Server As New ConnectionInfo
        Dim DataTable As Table

        Me.Cursor = Cursors.WaitCursor
        '----------------------------------------------------------------------------------------- 

        'Ambil data stock SAP
        AmbilStockSap()

        '-----------------------------------------------------------------------------------------   
        Dim DBX As Object = New DBConnection(ActiveSession).ConnectionSetting()

        'Setting Koneksi Database
        With Server
            .ServerName = "DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=" + DBX.Server + "; PORT = " + DBX.Port.ToString + "; "
            .DatabaseName = DBX.Database
            .UserID = DBX.UserID
            .Password = DBX.Password
        End With
        '-----------------------------------------------------------------------------------------

        Dim RPTObject As New ReportDocument

        'Report
        Select Case cboLaporan.SelectedIndex + 1
            Case 1
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\rpt500131_Bmf.RPT")
            Case 2
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\rpt500132_Bmf.RPT")
            Case 3
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\rpt500133_Bmf.RPT")
        End Select

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next
        If cboLaporan.SelectedIndex + 1 = 3 Then
            RPTObject.ParameterFields("TglAwal").CurrentValues.AddValue(txtTglAwal.Value.Date)
            RPTObject.ParameterFields("TglAkhir").CurrentValues.AddValue(txtTglAkhir.Value.Date)
        Else
            RPTObject.ParameterFields("ID").CurrentValues.AddValue(ID)
        End If
        'Informasi
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + ActiveSession.KodeUser + "'"
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"
        RPTObject.DataDefinition.FormulaFields("Periode").Text = "'PER " + Now.ToString("dd-MM-yyyy hh:mm:ss") + "'"

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
        If cboLaporan.SelectedIndex + 1 = 3 Then
            txtTglAkhir.Visible = True
            txtTglAwal.Visible = True
            ToolStripLabel3.Visible = True
            ToolStripLabel4.Visible = True
        Else
            txtTglAkhir.Visible = False
            txtTglAwal.Visible = False
            ToolStripLabel3.Visible = False
            ToolStripLabel4.Visible = False
        End If
    End Sub
End Class
