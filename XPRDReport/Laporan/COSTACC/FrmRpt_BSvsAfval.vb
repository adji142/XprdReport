Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data

Public Class FrmRpt_BSvsAfval

    Private WithEvents txtTglAwal As New DateTimePicker
    Private WithEvents txtTglAkhir As New DateTimePicker

    Private Sub FrmRpt_BSvsAfval_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        RPT.ShowGroupTreeButton = False

        Toolbar.Items.Insert(1, New ToolStripControlHost(txtTglAwal))
        txtTglAwal.Format = DateTimePickerFormat.Custom
        txtTglAwal.CustomFormat = "dd/MM/yyyy"
        txtTglAwal.Width = 95

        Toolbar.Items.Insert(3, New ToolStripControlHost(txtTglAkhir))
        txtTglAkhir.Format = DateTimePickerFormat.Custom
        txtTglAkhir.CustomFormat = "dd/MM/yyyy"
        txtTglAkhir.Width = 95

        cboTipeLaporan.SelectedIndex = 0
        FillCombo()
        cboStatus.ComboBox.SelectedIndex = 0
    End Sub
    Private Sub FillCombo()
        Dim DS As DataSet
        Dim Drow As DataRow

        Dim DaftarShiftProduksi As New DaftarShiftProduksi(ActiveSession)

        DS = DaftarShiftProduksi.Read("%")
        CboShift.ComboBox.DataSource = DS.Tables("View")
        CboShift.ComboBox.DisplayMember = "Nama Shift"
        CboShift.ComboBox.ValueMember = "Kode"

        Drow = DS.Tables("View").Rows.Add
        Drow("Kode") = ""
        Drow("Nama Shift") = "<SEMUA>"

        Dim DaftarMesinProduksi As New DaftarMesin(ActiveSession)

        DS = DaftarMesinProduksi.Read("%", "014")
        CboMesin.ComboBox.DataSource = DS.Tables("View")
        CboMesin.ComboBox.DisplayMember = "Nama Mesin"
        CboMesin.ComboBox.ValueMember = "Kode"

        Drow = DS.Tables("View").Rows.Add
        Drow("Kode") = ""
        Drow("Nama Mesin") = "<SEMUA>"

        CboMesin.ComboBox.SelectedIndex = CboMesin.Items.Count - 1
        CboShift.ComboBox.SelectedIndex = CboShift.Items.Count - 1
    End Sub
    Private Sub AmbilStockSap()
        Dim SAP As New SAPInventory()
        Dim DS As DataSet

        DS = SAP.ReadMasterItem("CUTTING_CEMENT_BAG")

        Dim DaftarTempStock As New TempMasterItem(ActiveSession)
        Dim TempStock As New TmpMasterItemSAP

        'Hapus Temporary
        DaftarTempStock.Delete()

        Dim Record As Integer = DS.Tables("View").Rows.Count
        ProgressBar.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Maximum = Record

        For Each DR As DataRow In DS.Tables("View").Rows
            TempStock.ItemCode = DR("ItemCode")
            TempStock.ItemName = DR("ItemName")
            TempStock.UnitProduksi = DR("U_SOL_ROUTING")
            TempStock.PjgStandar = DR("PjgStandar")
            TempStock.BeratSTD = DR("BeratSTD")

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
        'MessageBox.Show(ActiveSession.KodeUser)
        Me.Cursor = Cursors.WaitCursor
        '-----------------------------------------------------------------------------------------   

        '-----------------------------------------------------------------------------------------   
        Dim DBX As Object = New DBConnection(ActiveSession).ConnectionSetting()
        AmbilStockSap()
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
        Select Case cboTipeLaporan.SelectedIndex + 1
            Case 1
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt20001_AnalisaBSvsAfval.rpt")
            Case 2
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt20002_AnalisaBSvsAfval.rpt")
        End Select

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next

        'Parameter
        RPTObject.ParameterFields("Fromdate").CurrentValues.AddValue(txtTglAwal.Value.Date)
        RPTObject.ParameterFields("Todate").CurrentValues.AddValue(txtTglAkhir.Value.Date)
        RPTObject.ParameterFields("KodeMesin").CurrentValues.AddValue(CboMesin.ComboBox.SelectedValue)
        RPTObject.ParameterFields("KodeShift").CurrentValues.AddValue(CboShift.ComboBox.SelectedValue)
        If cboStatus.SelectedIndex = 0 Then
            RPTObject.ParameterFields("Status").CurrentValues.AddValue(0)
        Else
            RPTObject.ParameterFields("Status").CurrentValues.AddValue(1)
        End If
        'Informasi
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + ActiveSession.KodeUser + "'"
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"
        If txtTglAwal.Value.ToString("dd/MM/yy") = txtTglAkhir.Value.ToString("dd/MM/yy") Then
            RPTObject.DataDefinition.FormulaFields("Periode").Text = "'TANGGAL :  " + txtTglAkhir.Value.ToString("dd-MM-yyyy") + "'"
        Else
            RPTObject.DataDefinition.FormulaFields("Periode").Text = "'" + txtTglAwal.Value.ToString("dd-MM-yy") + " S/D " + txtTglAkhir.Value.ToString("dd-MM-yy") + "'"
        End If
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
