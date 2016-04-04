namespace Isaac.FastDependenciesRemover
{
    partial class FastDependenciesRemover
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastDependenciesRemover));
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbItemDependencies = new System.Windows.Forms.GroupBox();
            this.lvItemDependencies = new System.Windows.Forms.ListView();
            this.itemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDependencies = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteDependencies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.lvAttributes = new System.Windows.Forms.ListView();
            this.allFieldsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.allFieldsType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attributeid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbEntities.SuspendLayout();
            this.gbItemDependencies.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEntities
            // 
            this.gbEntities.Controls.Add(this.lvEntities);
            this.gbEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEntities.Enabled = false;
            this.gbEntities.Location = new System.Drawing.Point(0, 0);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Size = new System.Drawing.Size(308, 491);
            this.gbEntities.TabIndex = 89;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // lvEntities
            // 
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(3, 16);
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(302, 472);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 79;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            this.lvEntities.SelectedIndexChanged += new System.EventHandler(this.lvEntities_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Display name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Logical name";
            this.columnHeader2.Width = 150;
            // 
            // gbItemDependencies
            // 
            this.gbItemDependencies.Controls.Add(this.lvItemDependencies);
            this.gbItemDependencies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbItemDependencies.Enabled = false;
            this.gbItemDependencies.Location = new System.Drawing.Point(0, 0);
            this.gbItemDependencies.Name = "gbItemDependencies";
            this.gbItemDependencies.Size = new System.Drawing.Size(493, 264);
            this.gbItemDependencies.TabIndex = 87;
            this.gbItemDependencies.TabStop = false;
            this.gbItemDependencies.Text = "Item Dependencies";
            // 
            // lvItemDependencies
            // 
            this.lvItemDependencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemName,
            this.itemType});
            this.lvItemDependencies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItemDependencies.Location = new System.Drawing.Point(3, 16);
            this.lvItemDependencies.Name = "lvItemDependencies";
            this.lvItemDependencies.Size = new System.Drawing.Size(487, 245);
            this.lvItemDependencies.SmallImageList = this.imageList1;
            this.lvItemDependencies.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvItemDependencies.TabIndex = 78;
            this.lvItemDependencies.UseCompatibleStateImageBehavior = false;
            this.lvItemDependencies.View = System.Windows.Forms.View.Details;
            // 
            // itemName
            // 
            this.itemName.Text = "Item Name";
            this.itemName.Width = 350;
            // 
            // itemType
            // 
            this.itemType.Text = "Item Type";
            this.itemType.Width = 130;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator2,
            this.tsbEntities,
            this.toolStripSeparator1,
            this.tsbDependencies,
            this.tsbDeleteDependencies,
            this.toolStripSeparator3});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(811, 25);
            this.tsMain.TabIndex = 85;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(23, 22);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.TsbCloseThisTabClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEntities
            // 
            this.tsbEntities.Image = global::Isaac.FastDependenciesRemover.Properties.Resources.ico_16_9801;
            this.tsbEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEntities.Name = "tsbEntities";
            this.tsbEntities.Size = new System.Drawing.Size(94, 22);
            this.tsbEntities.Text = "Load Entities";
            this.tsbEntities.Click += new System.EventHandler(this.TsbLoadEntitiesClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDependencies
            // 
            this.tsbDependencies.Enabled = false;
            this.tsbDependencies.Image = global::Isaac.FastDependenciesRemover.Properties.Resources.showdependencies_16;
            this.tsbDependencies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDependencies.Name = "tsbDependencies";
            this.tsbDependencies.Size = new System.Drawing.Size(158, 22);
            this.tsbDependencies.Text = "Load Field Dependencies";
            this.tsbDependencies.Click += new System.EventHandler(this.tsbDependencies_Click);
            // 
            // tsbDeleteDependencies
            // 
            this.tsbDeleteDependencies.Enabled = false;
            this.tsbDeleteDependencies.Image = global::Isaac.FastDependenciesRemover.Properties.Resources.endrecurrence16;
            this.tsbDeleteDependencies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteDependencies.Name = "tsbDeleteDependencies";
            this.tsbDeleteDependencies.Size = new System.Drawing.Size(137, 22);
            this.tsbDeleteDependencies.Text = "Delete Dependencies";
            this.tsbDeleteDependencies.Click += new System.EventHandler(this.TsbDeleteDependenciesClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbEntities);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(811, 491);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 90;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(8, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbAttributes);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbItemDependencies);
            this.splitContainer2.Size = new System.Drawing.Size(493, 491);
            this.splitContainer2.SplitterDistance = 224;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.lvAttributes);
            this.gbAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAttributes.Enabled = false;
            this.gbAttributes.Location = new System.Drawing.Point(0, 0);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(493, 224);
            this.gbAttributes.TabIndex = 89;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Entity Attributes";
            // 
            // lvAttributes
            // 
            this.lvAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.allFieldsName,
            this.allFieldsType,
            this.attributeid});
            this.lvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttributes.FullRowSelect = true;
            this.lvAttributes.HideSelection = false;
            this.lvAttributes.Location = new System.Drawing.Point(3, 16);
            this.lvAttributes.Name = "lvAttributes";
            this.lvAttributes.Size = new System.Drawing.Size(487, 205);
            this.lvAttributes.SmallImageList = this.imageList1;
            this.lvAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAttributes.TabIndex = 68;
            this.lvAttributes.UseCompatibleStateImageBehavior = false;
            this.lvAttributes.View = System.Windows.Forms.View.Details;
            // 
            // allFieldsName
            // 
            this.allFieldsName.Text = "Field Name";
            this.allFieldsName.Width = 350;
            // 
            // allFieldsType
            // 
            this.allFieldsType.Text = "Field Type";
            this.allFieldsType.Width = 130;
            // 
            // attributeid
            // 
            this.attributeid.Text = "attributeid";
            this.attributeid.Width = 0;
            // 
            // FastDependenciesRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsMain);
            this.Name = "FastDependenciesRemover";
            this.Size = new System.Drawing.Size(811, 516);
            this.gbEntities.ResumeLayout(false);
            this.gbItemDependencies.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbAttributes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEntities;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gbItemDependencies;
        private System.Windows.Forms.ListView lvItemDependencies;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.ColumnHeader itemType;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbEntities;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDependencies;
        private System.Windows.Forms.ToolStripButton tsbDeleteDependencies;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.ListView lvAttributes;
        private System.Windows.Forms.ColumnHeader allFieldsName;
        private System.Windows.Forms.ColumnHeader allFieldsType;
        private System.Windows.Forms.ColumnHeader attributeid;
    }
}
