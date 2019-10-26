Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data
Public Class frmRPT_cosacc_SAPVsConsole
    Private ID As String
    Private WithEvents txtTglAwal As New DateTimePicker
    Private WithEvents txtTglAkhir As New DateTimePicker
    Private Sub frmReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        RPT.ShowGroupTreeButton = False

        Toolbar.Items.Insert(1, New ToolStripControlHost(txtTglAwal))
        txtTglAwal.Format = DateTimePickerFormat.Custom
        txtTglAwal.CustomFormat = "dd/MM/yyyy"
        txtTglAwal.Width = 95
        txtTglAwal.Value = Now.Date

        Toolbar.Items.Insert(3, New ToolStripControlHost(txtTglAkhir))
        txtTglAkhir.Format = DateTimePickerFormat.Custom
        txtTglAkhir.CustomFormat = "dd/MM/yyyy"
        txtTglAkhir.Width = 95
        txtTglAkhir.Value = Now.Date
        FillCombo()
        cboTipe.SelectedIndex = 0
        cboLaporan.SelectedIndex = 0
    End Sub
    Private Sub FillCombo()
        Dim DS As DataSet
        Dim Drow As DataRow

        'Unit Produksi
        Dim DaftarUnitProduksi As New DaftarUnitProduksi(ActiveSession)


        DS = DaftarUnitProduksi.Read("%")
        cboUnit.ComboBox.DataSource = DS.Tables("View")
        cboUnit.ComboBox.DisplayMember = "Unit SAP"
        cboUnit.ComboBox.ValueMember = "Kode"

        Drow = DS.Tables("View").Rows.Add
        Drow("Kode") = ""
        Drow("Unit SAP") = "<SEMUA UNIT PRODUKSI>"


        Dim DaftarLokasi As New DaftarLokasi(ActiveSession)

        DS = DaftarLokasi.Read("%")
        cbolokasi.ComboBox.DataSource = DS.Tables("View")
        cbolokasi.ComboBox.DisplayMember = "Nama Lokasi"
        cbolokasi.ComboBox.ValueMember = "Kode"

        cbolokasi.ComboBox.SelectedIndex = 0
    End Sub
    Private Sub AmbilData()
        Dim SAP As New SAPTransaction()
        Dim DS As DataSet

        Dim trx = ""
        Dim Unit = ""

        Select Case cboTipe.SelectedIndex
            Case 0
                trx = "ISSUE"
            Case 1
                trx = "RECIEPT"
            Case 2
                trx = "TRANSFER"
        End Select

        If cboTipe.SelectedIndex <> 2 Then
            Unit = cboUnit.Text
        End If

        DS = SAP.Read(txtTglAwal.Value.Date, txtTglAkhir.Value.Date, trx, Unit)

        Dim DaftarTransaksi As New Tmp_Transaksi(ActiveSession)

        DaftarTransaksi.Delete(trx)

        Dim tmptrx As New X_Transaksi
        'Dim DaftarRptPlanWO As New DaftarRptPlanWO(ActiveSession)

        'Dim RptPlanWO As New RptPlanWO

        Dim Record As Integer = DS.Tables("View").Rows.Count
        ProgressBar.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Maximum = Record

        For Each DR As DataRow In DS.Tables("View").Rows
            tmptrx.NoTransaksi = DR("Ref2")
            tmptrx.TglTransaksi = DR("DocDate")
            tmptrx.KodeItem = DR("ItemCode")
            tmptrx.Transaksi = DR("Transaksi")
            tmptrx.Qty = DR("Total")
            tmptrx.satuan = DR("unitMsr")
            tmptrx.KodeUnitSAP = DR("U_SOL_ROUTING")
            tmptrx.LokasiAsal = DR("UnitAsal")
            tmptrx.LokasiTujuan = DR("UnitTujuan")
            tmptrx.NamaItem = DR("ItemName")

            DaftarTransaksi.Add(tmptrx)

            ProgressBar.Value += 1
        Next
        If ProgressBar.Value = Record Then
            ProgressBar.Visible = False
        End If
    End Sub
    Private Sub AmbilDataStock()
        Dim SAP As New SAPTransaction()
        Dim DS As DataSet

        DS = SAP.Read_StockPerLokasi(cbolokasi.ComboBox.SelectedValue)

        Dim DaftarStockSAP As New Tmp_Transaksi(ActiveSession)

        DaftarStockSAP.DeleteStock()

        Dim AppendStock As New StockSAP

        Dim Record As Integer = DS.Tables("View").Rows.Count
        ProgressBar.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Maximum = Record

        For Each DR As DataRow In DS.Tables("View").Rows
            AppendStock.KodeLokasi = DR("KodeLokasi")
            AppendStock.KodeItem = DR("KodeItem")
            AppendStock.NamaItem = DR("NamaItem")
            AppendStock.Stock = DR("Stock")
            AppendStock.Satuan = DR("Satuan")

            DaftarStockSAP.Add_Stock(AppendStock)

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

        ID = ActiveSession.KodeUser & Now.ToString("ddMMyyyyHHmmss")

        'Ambil Data Work Order Dari SAP
        If cboLaporan.ComboBox.SelectedIndex = 1 Then
            AmbilData()
        Else
            AmbilDataStock()
        End If

        '-----------------------------------------------------------------------------------------   
        Dim DBX As Object = New DBConnection(ActiveSession).ConnectionSetting()

        'Setting Koneksi Database
        With Server
            .ServerName = "DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=" + DBX.Server + "; PORT = " + DBX.Port.ToString + "; "
            .DatabaseName = DBX.Database
            .UserID = DBX.UserID
            .Password = DBX.Password
        End With
        ''-----------------------------------------------------------------------------------------

        Dim RPTObject As New ReportDocument

        ''Report
        If cboLaporan.ComboBox.SelectedIndex = 0 Then
            RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_CompareStockSAP.RPT")
        Else
            Select Case cboTipe.ComboBox.SelectedIndex + 1
                Case 1
                    RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_CompareBahanSAP.RPT")
                Case 2
                    RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_CompareHasilSAP.RPT")
                Case 3
                    RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\Rpt_ComparetTransferSAP.RPT")
            End Select

        End If

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next

        'Parameter
        If cboLaporan.ComboBox.SelectedIndex = 1 Then
            If cboTipe.ComboBox.SelectedIndex = 2 Then
                RPTObject.ParameterFields("TglAwal").CurrentValues.AddValue(txtTglAwal.Value.Date)
                RPTObject.ParameterFields("TglAkhir").CurrentValues.AddValue(txtTglAkhir.Value.Date)
            Else
                RPTObject.ParameterFields("TglAwal").CurrentValues.AddValue(txtTglAwal.Value.Date)
                RPTObject.ParameterFields("TglAkhir").CurrentValues.AddValue(txtTglAkhir.Value.Date)
                RPTObject.ParameterFields("KodeUnit").CurrentValues.AddValue(cboUnit.ComboBox.SelectedValue)
            End If
        Else
            RPTObject.ParameterFields("KodeLokasi").CurrentValues.AddValue(cbolokasi.ComboBox.SelectedValue)
        End If

        'Informasi
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"
        RPTObject.DataDefinition.FormulaFields("Periode").Text = "'PER :  " + Now.ToString("dd-MM-yyyy HH:mm:ss") + "'"
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + UCase(ActiveSession.KodeUser) + "'"

        RPT.ReportSource = RPTObject
        HideTabControl(RPT)

        RPT.Refresh()

        Dim DaftarRptPlanWO As New DaftarRptPlanWO(ActiveSession)

        ''Hapus Temporary
        DaftarRptPlanWO.Delete(ID)

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

    Private Sub cboTipe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipe.SelectedIndexChanged
        If cboTipe.ComboBox.SelectedIndex = 2 Then
            cboUnit.Visible = False
        Else
            cboUnit.Visible = True
        End If
    End Sub

    Private Sub cboLaporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLaporan.SelectedIndexChanged
        If cboLaporan.ComboBox.SelectedIndex = 1 Then
            cboTipe.Visible = True
            spunit.Visible = True
            lblUnit.Visible = True
            cboUnit.Visible = True
            txtTglAwal.Visible = True
            txtTglAkhir.Visible = True
            lblperiod.Visible = True
            ToolStripLabel2.Visible = True
            cbolokasi.Visible = False
            lblloc.Visible = False
        Else
            cboTipe.Visible = False
            spunit.Visible = False
            lblUnit.Visible = False
            cboUnit.Visible = False
            txtTglAwal.Visible = False
            txtTglAkhir.Visible = False
            lblperiod.Visible = False
            ToolStripLabel2.Visible = False
            cbolokasi.Visible = True
            lblloc.Visible = True
        End If
    End Sub
End Class
