Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data

Public Class FrmRpt_StockOpname

    Private WithEvents txtTglAwal As New DateTimePicker

    Private Sub FrmRpt_BSvsAfval_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        RPT.ShowGroupTreeButton = False

        Toolbar.Items.Insert(1, New ToolStripControlHost(txtTglAwal))
        txtTglAwal.Format = DateTimePickerFormat.Custom
        txtTglAwal.CustomFormat = "dd/MM/yyyy"
        txtTglAwal.Width = 95

        FillCombo()

    End Sub
    Private Sub FillCombo()
        Dim DS As DataSet
        Dim Drow As DataRow

        Dim DaftarKelompok As New DaftarKelompokSerahTerimaHasilProduksi(ActiveSession)

        DS = DaftarKelompok.Read("%")
        ToolStripComboBox1.ComboBox.DataSource = DS.Tables("View")
        ToolStripComboBox1.ComboBox.DisplayMember = "Nama Kelompok"
        ToolStripComboBox1.ComboBox.ValueMember = "Kode"

        Drow = DS.Tables("View").Rows.Add
        Drow("Kode") = ""
        Drow("Nama Kelompok") = "<SEMUA>"

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
        RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\rptStockOpname.rpt")

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next

        'Parameter
        RPTObject.ParameterFields("Tanggal").CurrentValues.AddValue(txtTglAwal.Value.Date)
        RPTObject.ParameterFields("Kelompok").CurrentValues.AddValue(ToolStripComboBox1.ComboBox.SelectedValue)
        'Informasi
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + ActiveSession.KodeUser + "'"
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"
        RPTObject.DataDefinition.FormulaFields("Periode").Text = "'TANGGAL :  " + txtTglAwal.Value.ToString("dd-MM-yyyy") + "'"
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
