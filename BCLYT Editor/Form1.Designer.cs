namespace BCLYT_Editor
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.converterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCLYTXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLBCLYTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturePaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CLYT_Main_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.CLYT_Sub_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CLYT_Main_SplitContainer)).BeginInit();
            this.CLYT_Main_SplitContainer.Panel1.SuspendLayout();
            this.CLYT_Main_SplitContainer.Panel2.SuspendLayout();
            this.CLYT_Main_SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CLYT_Sub_SplitContainer)).BeginInit();
            this.CLYT_Sub_SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.layoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.createToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLayoutToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // newLayoutToolStripMenuItem
            // 
            this.newLayoutToolStripMenuItem.Name = "newLayoutToolStripMenuItem";
            this.newLayoutToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.newLayoutToolStripMenuItem.Text = "New Layout";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.converterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // converterToolStripMenuItem
            // 
            this.converterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCLYTXMLToolStripMenuItem,
            this.xMLBCLYTToolStripMenuItem});
            this.converterToolStripMenuItem.Name = "converterToolStripMenuItem";
            this.converterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.converterToolStripMenuItem.Text = "Converter";
            // 
            // bCLYTXMLToolStripMenuItem
            // 
            this.bCLYTXMLToolStripMenuItem.Name = "bCLYTXMLToolStripMenuItem";
            this.bCLYTXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bCLYTXMLToolStripMenuItem.Text = "BCLYT->XML";
            this.bCLYTXMLToolStripMenuItem.Click += new System.EventHandler(this.bCLYTXMLToolStripMenuItem_Click);
            // 
            // xMLBCLYTToolStripMenuItem
            // 
            this.xMLBCLYTToolStripMenuItem.Name = "xMLBCLYTToolStripMenuItem";
            this.xMLBCLYTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.xMLBCLYTToolStripMenuItem.Text = "XML->BCLYT";
            this.xMLBCLYTToolStripMenuItem.Click += new System.EventHandler(this.xMLBCLYTToolStripMenuItem_Click);
            // 
            // layoutToolStripMenuItem
            // 
            this.layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            this.layoutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.layoutToolStripMenuItem.Text = "Layout";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyPaneToolStripMenuItem,
            this.picturePaneToolStripMenuItem,
            this.rectPaneToolStripMenuItem,
            this.windowPaneToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // emptyPaneToolStripMenuItem
            // 
            this.emptyPaneToolStripMenuItem.Name = "emptyPaneToolStripMenuItem";
            this.emptyPaneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.emptyPaneToolStripMenuItem.Text = "Empty Pane";
            // 
            // picturePaneToolStripMenuItem
            // 
            this.picturePaneToolStripMenuItem.Name = "picturePaneToolStripMenuItem";
            this.picturePaneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.picturePaneToolStripMenuItem.Text = "Picture Pane";
            // 
            // rectPaneToolStripMenuItem
            // 
            this.rectPaneToolStripMenuItem.Name = "rectPaneToolStripMenuItem";
            this.rectPaneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rectPaneToolStripMenuItem.Text = "Rect Pane";
            // 
            // windowPaneToolStripMenuItem
            // 
            this.windowPaneToolStripMenuItem.Name = "windowPaneToolStripMenuItem";
            this.windowPaneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.windowPaneToolStripMenuItem.Text = "Window Pane";
            // 
            // CLYT_Main_SplitContainer
            // 
            this.CLYT_Main_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLYT_Main_SplitContainer.Location = new System.Drawing.Point(0, 24);
            this.CLYT_Main_SplitContainer.Name = "CLYT_Main_SplitContainer";
            // 
            // CLYT_Main_SplitContainer.Panel1
            // 
            this.CLYT_Main_SplitContainer.Panel1.Controls.Add(this.treeView1);
            // 
            // CLYT_Main_SplitContainer.Panel2
            // 
            this.CLYT_Main_SplitContainer.Panel2.Controls.Add(this.CLYT_Sub_SplitContainer);
            this.CLYT_Main_SplitContainer.Size = new System.Drawing.Size(686, 411);
            this.CLYT_Main_SplitContainer.SplitterDistance = 154;
            this.CLYT_Main_SplitContainer.TabIndex = 3;
            // 
            // CLYT_Sub_SplitContainer
            // 
            this.CLYT_Sub_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLYT_Sub_SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CLYT_Sub_SplitContainer.Name = "CLYT_Sub_SplitContainer";
            this.CLYT_Sub_SplitContainer.Size = new System.Drawing.Size(528, 411);
            this.CLYT_Sub_SplitContainer.SplitterDistance = 343;
            this.CLYT_Sub_SplitContainer.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(154, 411);
            this.treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 435);
            this.Controls.Add(this.CLYT_Main_SplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BCLYT Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CLYT_Main_SplitContainer.Panel1.ResumeLayout(false);
            this.CLYT_Main_SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CLYT_Main_SplitContainer)).EndInit();
            this.CLYT_Main_SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CLYT_Sub_SplitContainer)).EndInit();
            this.CLYT_Sub_SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem converterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bCLYTXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLBCLYTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyPaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem picturePaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectPaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowPaneToolStripMenuItem;
        private System.Windows.Forms.SplitContainer CLYT_Main_SplitContainer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer CLYT_Sub_SplitContainer;
    }
}

