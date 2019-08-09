<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRPT1300_BMF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPT1300_BMF))
        Me.Toolbar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btRefresh = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RPT01 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RPT02 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.RPT03 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Toolbar.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar
        '
        Me.Toolbar.BackColor = System.Drawing.SystemColors.Control
        Me.Toolbar.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.ToolStripLabel4, Me.ToolStripSeparator1, Me.btRefresh})
        Me.Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar.Name = "Toolbar"
        Me.Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Toolbar.Size = New System.Drawing.Size(1086, 31)
        Me.Toolbar.TabIndex = 4
        Me.Toolbar.TabStop = True
        Me.Toolbar.Text = "ToolStrip1"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(56, 28)
        Me.ToolStripLabel3.Text = "&Periode : "
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(24, 28)
        Me.ToolStripLabel4.Text = "s/d"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1086, 354)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RPT01)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1078, 328)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Rekap Produksi BMF"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RPT01
        '
        Me.RPT01.ActiveViewIndex = -1
        Me.RPT01.AutoScroll = True
        Me.RPT01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPT01.Cursor = System.Windows.Forms.Cursors.Default
        Me.RPT01.DisplayBackgroundEdge = False
        Me.RPT01.DisplayStatusBar = False
        Me.RPT01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RPT01.EnableDrillDown = False
        Me.RPT01.EnableRefresh = False
        Me.RPT01.EnableToolTips = False
        Me.RPT01.Location = New System.Drawing.Point(3, 3)
        Me.RPT01.Name = "RPT01"
        Me.RPT01.ShowCloseButton = False
        Me.RPT01.ShowLogo = False
        Me.RPT01.ShowParameterPanelButton = False
        Me.RPT01.ShowRefreshButton = False
        Me.RPT01.Size = New System.Drawing.Size(1072, 322)
        Me.RPT01.TabIndex = 4
        Me.RPT01.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.RPT01.ToolPanelWidth = 250
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RPT02)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1078, 328)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Afval Produksi BMF"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RPT02
        '
        Me.RPT02.ActiveViewIndex = -1
        Me.RPT02.AutoScroll = True
        Me.RPT02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPT02.Cursor = System.Windows.Forms.Cursors.Default
        Me.RPT02.DisplayBackgroundEdge = False
        Me.RPT02.DisplayStatusBar = False
        Me.RPT02.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RPT02.EnableDrillDown = False
        Me.RPT02.EnableRefresh = False
        Me.RPT02.EnableToolTips = False
        Me.RPT02.Location = New System.Drawing.Point(3, 3)
        Me.RPT02.Name = "RPT02"
        Me.RPT02.ShowCloseButton = False
        Me.RPT02.ShowLogo = False
        Me.RPT02.ShowParameterPanelButton = False
        Me.RPT02.ShowRefreshButton = False
        Me.RPT02.Size = New System.Drawing.Size(1072, 322)
        Me.RPT02.TabIndex = 5
        Me.RPT02.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.RPT02.ToolPanelWidth = 250
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.RPT03)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1078, 328)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Grafik Afval Produksi BMF"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'RPT03
        '
        Me.RPT03.ActiveViewIndex = -1
        Me.RPT03.AutoScroll = True
        Me.RPT03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPT03.Cursor = System.Windows.Forms.Cursors.Default
        Me.RPT03.DisplayBackgroundEdge = False
        Me.RPT03.DisplayStatusBar = False
        Me.RPT03.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RPT03.EnableDrillDown = False
        Me.RPT03.EnableRefresh = False
        Me.RPT03.EnableToolTips = False
        Me.RPT03.Location = New System.Drawing.Point(3, 3)
        Me.RPT03.Name = "RPT03"
        Me.RPT03.ShowCloseButton = False
        Me.RPT03.ShowLogo = False
        Me.RPT03.ShowParameterPanelButton = False
        Me.RPT03.ShowRefreshButton = False
        Me.RPT03.Size = New System.Drawing.Size(1072, 322)
        Me.RPT03.TabIndex = 5
        Me.RPT03.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.RPT03.ToolPanelWidth = 250
        '
        'frmRPT1300_BMF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1086, 385)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Toolbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRPT1300_BMF"
        Me.Text = "Laporan Rangkuman Produksi | BMF"
        Me.Toolbar.ResumeLayout(False)
        Me.Toolbar.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents RPT As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents RPT03 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Private WithEvents RPT01 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Private WithEvents RPT02 As CrystalDecisions.Windows.Forms.CrystalReportViewer

End Class
