namespace Colso.DashboardTransferTool
{
    partial class DashboardTransferTool
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardTransferTool));
            this.gbSourceDashboards = new System.Windows.Forms.GroupBox();
            this.lvSourceDashboards = new System.Windows.Forms.ListView();
            this.allViewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allViewType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewImageList = new System.Windows.Forms.ImageList(this.components);
            this.lbSourceValue = new System.Windows.Forms.Label();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbTargetValue = new System.Windows.Forms.Label();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadDashboards = new System.Windows.Forms.ToolStripButton();
            this.tsbTransferDashboards = new System.Windows.Forms.ToolStripButton();
            this.gbSourceDashboards.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSourceDashboards
            // 
            this.gbSourceDashboards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSourceDashboards.Controls.Add(this.lvSourceDashboards);
            this.gbSourceDashboards.Enabled = false;
            this.gbSourceDashboards.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gbSourceDashboards.Location = new System.Drawing.Point(3, 104);
            this.gbSourceDashboards.Name = "gbSourceDashboards";
            this.gbSourceDashboards.Size = new System.Drawing.Size(794, 493);
            this.gbSourceDashboards.TabIndex = 91;
            this.gbSourceDashboards.TabStop = false;
            this.gbSourceDashboards.Text = "Available dashboards";
            // 
            // lvSourceDashboards
            // 
            this.lvSourceDashboards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSourceDashboards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.allViewName,
            this.allViewType});
            this.lvSourceDashboards.FullRowSelect = true;
            this.lvSourceDashboards.HideSelection = false;
            this.lvSourceDashboards.Location = new System.Drawing.Point(6, 21);
            this.lvSourceDashboards.Name = "lvSourceDashboards";
            this.lvSourceDashboards.Size = new System.Drawing.Size(782, 466);
            this.lvSourceDashboards.SmallImageList = this.viewImageList;
            this.lvSourceDashboards.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSourceDashboards.TabIndex = 64;
            this.lvSourceDashboards.UseCompatibleStateImageBehavior = false;
            this.lvSourceDashboards.View = System.Windows.Forms.View.Details;
            this.lvSourceDashboards.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSourceDashboards_ColumnClick);
            // 
            // allViewName
            // 
            this.allViewName.Text = "Name";
            this.allViewName.Width = 350;
            // 
            // allViewType
            // 
            this.allViewType.Text = "Type";
            this.allViewType.Width = 130;
            // 
            // viewImageList
            // 
            this.viewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("viewImageList.ImageStream")));
            this.viewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.viewImageList.Images.SetKeyName(0, "dashboard.gif");
            this.viewImageList.Images.SetKeyName(1, "dashboard_user.png");
            // 
            // lbSourceValue
            // 
            this.lbSourceValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSourceValue.AutoSize = true;
            this.lbSourceValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbSourceValue.ForeColor = System.Drawing.Color.Red;
            this.lbSourceValue.Location = new System.Drawing.Point(114, 24);
            this.lbSourceValue.Name = "lbSourceValue";
            this.lbSourceValue.Size = new System.Drawing.Size(64, 13);
            this.lbSourceValue.TabIndex = 97;
            this.lbSourceValue.Text = "Unselected";
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator2,
            this.tsbLoadDashboards,
            this.tsbTransferDashboards,
            this.toolStripSeparator1});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(800, 25);
            this.tsMain.TabIndex = 90;
            this.tsMain.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lbTargetValue
            // 
            this.lbTargetValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTargetValue.AutoSize = true;
            this.lbTargetValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lbTargetValue.ForeColor = System.Drawing.Color.Red;
            this.lbTargetValue.Location = new System.Drawing.Point(114, 45);
            this.lbTargetValue.Name = "lbTargetValue";
            this.lbTargetValue.Size = new System.Drawing.Size(64, 13);
            this.lbTargetValue.TabIndex = 98;
            this.lbTargetValue.Text = "Unselected";
            // 
            // gbEnvironments
            // 
            this.gbEnvironments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEnvironments.Controls.Add(this.lbSourceValue);
            this.gbEnvironments.Controls.Add(this.lblSource);
            this.gbEnvironments.Controls.Add(this.btnSelectTarget);
            this.gbEnvironments.Controls.Add(this.lbTargetValue);
            this.gbEnvironments.Location = new System.Drawing.Point(3, 28);
            this.gbEnvironments.Name = "gbEnvironments";
            this.gbEnvironments.Size = new System.Drawing.Size(794, 70);
            this.gbEnvironments.TabIndex = 101;
            this.gbEnvironments.TabStop = false;
            this.gbEnvironments.Text = "Environments";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 24);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 100;
            this.lblSource.Text = "Source";
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Location = new System.Drawing.Point(6, 40);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(85, 23);
            this.btnSelectTarget.TabIndex = 99;
            this.btnSelectTarget.Text = "Select target";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(23, 22);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.tsbCloseThisTab_Click);
            // 
            // tsbLoadDashboards
            // 
            this.tsbLoadDashboards.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbLoadDashboards.Image = global::Colso.DashboardTransferTool.Properties.Resources.dashboard;
            this.tsbLoadDashboards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadDashboards.Name = "tsbLoadDashboards";
            this.tsbLoadDashboards.Size = new System.Drawing.Size(117, 22);
            this.tsbLoadDashboards.Text = "Load Dashboards";
            this.tsbLoadDashboards.Click += new System.EventHandler(this.tsbLoadDashboards_Click);
            // 
            // tsbTransferDashboards
            // 
            this.tsbTransferDashboards.Image = global::Colso.DashboardTransferTool.Properties.Resources.dashboard_retrieve;
            this.tsbTransferDashboards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTransferDashboards.Name = "tsbTransferDashboards";
            this.tsbTransferDashboards.Size = new System.Drawing.Size(133, 22);
            this.tsbTransferDashboards.Text = "Transfer dashboards";
            this.tsbTransferDashboards.Click += new System.EventHandler(this.tsbTransferDashboards_Click);
            // 
            // DashboardTransferTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbEnvironments);
            this.Controls.Add(this.gbSourceDashboards);
            this.Controls.Add(this.tsMain);
            this.Name = "DashboardTransferTool";
            this.Size = new System.Drawing.Size(800, 600);
            this.gbSourceDashboards.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbSourceDashboards;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbLoadDashboards;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbTransferDashboards;
        private System.Windows.Forms.ImageList viewImageList;
        private System.Windows.Forms.Label lbSourceValue;
        private System.Windows.Forms.Label lbTargetValue;
        private System.Windows.Forms.ListView lvSourceDashboards;
        private System.Windows.Forms.ColumnHeader allViewName;
        private System.Windows.Forms.ColumnHeader allViewType;
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.Label lblSource;
    }
}
