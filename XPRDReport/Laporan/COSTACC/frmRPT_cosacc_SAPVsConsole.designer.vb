<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRPT_cosacc_SAPVsConsole
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPT_cosacc_SAPVsConsole))
        Me.Toolbar = New System.Windows.Forms.ToolStrip()
        Me.lblperiod = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboLaporan = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboTipe = New System.Windows.Forms.ToolStripComboBox()
        Me.spunit = New System.Windows.Forms.ToolStripSeparator()
        Me.lblUnit = New System.Windows.Forms.ToolStripLabel()
        Me.cboUnit = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblloc = New System.Windows.Forms.ToolStripLabel()
        Me.cbolokasi = New System.Windows.Forms.ToolStripComboBox()
        Me.btRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.RPT = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Toolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar
        '
        Me.Toolbar.BackColor = System.Drawing.SystemColors.Control
        Me.Toolbar.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblperiod, Me.ToolStripLabel2, Me.ToolStripSeparator4, Me.cboLaporan, Me.ToolStripSeparator2, Me.cboTipe, Me.spunit, Me.lblUnit, Me.cboUnit, Me.ToolStripSeparator1, Me.lblloc, Me.cbolokasi, Me.btRefresh, Me.ProgressBar})
        Me.Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar.Name = "Toolbar"
        Me.Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Toolbar.Size = New System.Drawing.Size(1086, 31)
        Me.Toolbar.TabIndex = 4
        Me.Toolbar.TabStop = True
        Me.Toolbar.Text = "ToolStrip1"
        '
        'lblperiod
        '
        Me.lblperiod.Name = "lblperiod"
        Me.lblperiod.Size = New System.Drawing.Size(53, 28)
        Me.lblperiod.Text = "Periode :"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(24, 28)
        Me.ToolStripLabel2.Text = "s/d"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'cboLaporan
        '
        Me.cboLaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLaporan.Items.AddRange(New Object() {"Per Item", "Per Transaksi"})
        Me.cboLaporan.Name = "cboLaporan"
        Me.cboLaporan.Size = New System.Drawing.Size(121, 31)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'cboTipe
        '
        Me.cboTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipe.Items.AddRange(New Object() {"BAHAN", "HASIL", "TRANSFER"})
        Me.cboTipe.Name = "cboTipe"
        Me.cboTipe.Size = New System.Drawing.Size(121, 31)
        Me.cboTipe.Visible = False
        '
        'spunit
        '
        Me.spunit.Name = "spunit"
        Me.spunit.Size = New System.Drawing.Size(6, 31)
        Me.spunit.Visible = False
        '
        'lblUnit
        '
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(78, 28)
        Me.lblUnit.Text = "Unit Produksi"
        Me.lblUnit.Visible = False
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(175, 31)
        Me.cboUnit.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'lblloc
        '
        Me.lblloc.Name = "lblloc"
        Me.lblloc.Size = New System.Drawing.Size(46, 28)
        Me.lblloc.Text = "Lokasi :"
        '
        'cbolokasi
        '
        Me.cbolokasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbolokasi.Name = "cbolokasi"
        Me.cbolokasi.Size = New System.Drawing.Size(121, 31)
        '
        'btRefresh
        '
        Me.btRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btRefresh.Image = CType(resources.GetObject("btRefresh.Image"), System.Drawing.Image)
        Me.btRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(28, 28)
        Me.btRefresh.Text = "Tampilkan Laporan"
        Me.btRefresh.ToolTipText = " [F5]-Tampilkan Laporan"
        '
        'ProgressBar
        '
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(150, 28)
        '
        'RPT
        '
        Me.RPT.ActiveViewIndex = -1
        Me.RPT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RPT.AutoScroll = True
        Me.RPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPT.Cursor = System.Windows.Forms.Cursors.Default
        Me.RPT.DisplayBackgroundEdge = False
        Me.RPT.DisplayStatusBar = False
        Me.RPT.EnableDrillDown = False
        Me.RPT.EnableRefresh = False
        Me.RPT.EnableToolTips = False
        Me.RPT.Location = New System.Drawing.Point(0, 34)
        Me.RPT.Name = "RPT"
        Me.RPT.ShowCloseButton = False
        Me.RPT.ShowLogo = False
        Me.RPT.ShowParameterPanelButton = False
        Me.RPT.ShowRefreshButton = False
        Me.RPT.Size = New System.Drawing.Size(1086, 353)
        Me.RPT.TabIndex = 3
        Me.RPT.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.RPT.ToolPanelWidth = 250
        '
        'frmRPT_cosacc_SAPVsConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1086, 385)
        Me.Controls.Add(Me.RPT)
        Me.Controls.Add(Me.Toolbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRPT_cosacc_SAPVsConsole"
        Me.Text = "Laporan Perbandingan SAP vs Console"
        Me.Toolbar.ResumeLayout(False)
        Me.Toolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents RPT As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents btRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Private WithEvents RPT As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblperiod As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboTipe As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents spunit As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblUnit As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboUnit As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboLaporan As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblloc As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbolokasi As System.Windows.Forms.ToolStripComboBox

End Class
