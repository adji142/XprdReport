﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports XPRDReport.HSP.Data
Imports XPRDSystem.HSP.Data
Public Class frmRPT210_190_GudangRoll

    Private WithEvents txtTglAwal As New DateTimePicker
    Private WithEvents txtTglAkhir As New DateTimePicker

    Private Sub frmReport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        RPT.ShowGroupTreeButton = False

        Toolbar.Items.Insert(1, New ToolStripControlHost(txtTglAwal))
        txtTglAwal.Format = DateTimePickerFormat.Custom
        txtTglAwal.CustomFormat = "dd/MM/yyyy"
        txtTglAwal.Width = 95
        txtTglAwal.Value = DateSerial(Year(Now), Month(Now), 1)

        Toolbar.Items.Insert(3, New ToolStripControlHost(txtTglAkhir))
        txtTglAkhir.Format = DateTimePickerFormat.Custom
        txtTglAkhir.CustomFormat = "dd/MM/yyyy"
        txtTglAkhir.Width = 95
        txtTglAkhir.Value = Now.Date

        cboLaporan.SelectedIndex = 0

    End Sub

    'Tampilkan Laporan
    Private Sub btRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btRefresh.Click
        Dim Server As New ConnectionInfo
        Dim DataTable As Table

        Me.Cursor = Cursors.WaitCursor
        '-----------------------------------------------------------------------------------------   
        Dim KodeLokasi = ""
        Dim DaftarLokasiProduksi As New _DaftarLokasi(ActiveSession)

        Dim DS As DataSet
        DS = DaftarLokasiProduksi.Read(XPRDReport.HSP.Data.Lokasi.enumLokasiProduksi.FloorFinishing)

        If DS.Tables(0).Rows.Count > 0 Then
            KodeLokasi = DS.Tables(0).Rows(0).Item("Kode")
        End If

        Dim KodeUnit = ""
        Dim DaftarUnitProduksi As New DaftarUnitProduksi(ActiveSession)

        Dim DSX As DataSet
        DSX = DaftarUnitProduksi.Read("%", UnitProduksi.enumKelompokProduksi.Extruder)

        If DSX.Tables(0).Rows.Count > 0 Then
            KodeUnit = DSX.Tables(0).Rows(0).Item("Kode")
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
        '-----------------------------------------------------------------------------------------

        Dim RPTObject As New ReportDocument

        'Report
        Select Case cboLaporan.SelectedIndex + 1
            Case 1
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\RPT210191_GudangRollMakloon.RPT")
            Case 2
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\RPT210192_GudangRollMakloon.RPT")
            Case 3
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\RPT210193_GudangRollMakloon.RPT")
            Case 4
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\RPT210194_GudangRollMakloon.RPT")
            Case 5
                RPTObject.Load(System.AppDomain.CurrentDomain.BaseDirectory() + "\Reports\System\RPT210195_GudangRollMakloon.RPT")
        End Select

        For Each DataTable In RPTObject.Database.Tables
            DataTable.LogOnInfo.ConnectionInfo = Server
            DataTable.ApplyLogOnInfo(DataTable.LogOnInfo)
        Next

        'Parameter
        RPTObject.ParameterFields("TglAwal").CurrentValues.AddValue(txtTglAwal.Value.Date)
        RPTObject.ParameterFields("TglAkhir").CurrentValues.AddValue(txtTglAkhir.Value.Date)
        RPTObject.ParameterFields("KodeUnit").CurrentValues.AddValue(KodeUnit)
        RPTObject.ParameterFields("KodeLokasi").CurrentValues.AddValue(KodeLokasi)

        'Informasi
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + ActiveSession.KodeUser + "'"
        RPTObject.DataDefinition.FormulaFields("NamaPerusahaan").Text = "'" + UCase(ActiveSession.NamaPerusahaan) + "'"
        If txtTglAwal.Value.ToString("dd/MM/yy") = txtTglAkhir.Value.ToString("dd/MM/yy") Then
            RPTObject.DataDefinition.FormulaFields("Periode").Text = "'TANGGAL :  " + txtTglAkhir.Value.ToString("dd-MM-yyyy") + "'"
        Else
            RPTObject.DataDefinition.FormulaFields("Periode").Text = "'" + txtTglAwal.Value.ToString("dd-MM-yy") + " S/D " + txtTglAkhir.Value.ToString("dd-MM-yy") + "'"
        End If
        RPTObject.DataDefinition.FormulaFields("UserID").Text = "'" + UCase(ActiveSession.KodeUser) + "'"

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
