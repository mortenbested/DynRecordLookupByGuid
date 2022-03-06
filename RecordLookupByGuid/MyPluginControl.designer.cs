using System.Windows.Controls;
using System.Windows.Forms;

namespace RecordLookupByGuid
{
    partial class MyPluginControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadData = new System.Windows.Forms.ToolStripButton();
            this.labelEnterGuid = new System.Windows.Forms.Label();
            this.textBoxSearchTerm = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxCustomEntitiesOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxManagedEntities = new System.Windows.Forms.CheckBox();
            this.textBoxExcludeFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIncludeFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNoResults = new System.Windows.Forms.Label();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.linkLabelFoundRecord = new System.Windows.Forms.LinkLabel();
            this.toolStripMenu.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadData});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1428, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripButtonLoadData
            // 
            this.toolStripButtonLoadData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripButtonLoadData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadData.Image")));
            this.toolStripButtonLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadData.Name = "toolStripButtonLoadData";
            this.toolStripButtonLoadData.Size = new System.Drawing.Size(102, 28);
            this.toolStripButtonLoadData.Text = "Load Entities";
            this.toolStripButtonLoadData.Click += new System.EventHandler(this.ToolStripButtonLoadData_Click);
            // 
            // labelEnterGuid
            // 
            this.labelEnterGuid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelEnterGuid.AutoSize = true;
            this.labelEnterGuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterGuid.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelEnterGuid.Location = new System.Drawing.Point(12, 21);
            this.labelEnterGuid.Name = "labelEnterGuid";
            this.labelEnterGuid.Size = new System.Drawing.Size(103, 20);
            this.labelEnterGuid.TabIndex = 0;
            this.labelEnterGuid.Text = "Record Guid:";
            // 
            // textBoxSearchTerm
            // 
            this.textBoxSearchTerm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSearchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchTerm.Location = new System.Drawing.Point(16, 45);
            this.textBoxSearchTerm.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSearchTerm.Name = "textBoxSearchTerm";
            this.textBoxSearchTerm.Size = new System.Drawing.Size(393, 26);
            this.textBoxSearchTerm.TabIndex = 1;
            this.textBoxSearchTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearchTerm_KeyUp);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(412, 45);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(171, 26);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search 0 Entities";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBoxSettings.Controls.Add(this.checkBoxCustomEntitiesOnly);
            this.groupBoxSettings.Controls.Add(this.checkBoxManagedEntities);
            this.groupBoxSettings.Controls.Add(this.textBoxExcludeFilter);
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.textBoxIncludeFilter);
            this.groupBoxSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSettings.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBoxSettings.Location = new System.Drawing.Point(16, 116);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(567, 212);
            this.groupBoxSettings.TabIndex = 5;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // checkBoxCustomEntitiesOnly
            // 
            this.checkBoxCustomEntitiesOnly.AutoSize = true;
            this.checkBoxCustomEntitiesOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCustomEntitiesOnly.Location = new System.Drawing.Point(15, 144);
            this.checkBoxCustomEntitiesOnly.Name = "checkBoxCustomEntitiesOnly";
            this.checkBoxCustomEntitiesOnly.Size = new System.Drawing.Size(122, 17);
            this.checkBoxCustomEntitiesOnly.TabIndex = 6;
            this.checkBoxCustomEntitiesOnly.Text = "Custom Entities Only";
            this.checkBoxCustomEntitiesOnly.UseVisualStyleBackColor = true;
            this.checkBoxCustomEntitiesOnly.CheckedChanged += new System.EventHandler(this.CheckBoxCustomEntitiesOnly_CheckedChanged);
            // 
            // checkBoxManagedEntities
            // 
            this.checkBoxManagedEntities.AutoSize = true;
            this.checkBoxManagedEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxManagedEntities.Location = new System.Drawing.Point(15, 167);
            this.checkBoxManagedEntities.Name = "checkBoxManagedEntities";
            this.checkBoxManagedEntities.Size = new System.Drawing.Size(149, 17);
            this.checkBoxManagedEntities.TabIndex = 5;
            this.checkBoxManagedEntities.Text = "Exclude Managed Entities";
            this.checkBoxManagedEntities.UseVisualStyleBackColor = true;
            this.checkBoxManagedEntities.CheckedChanged += new System.EventHandler(this.CheckBoxManagedEntities_CheckedChanged);
            // 
            // textBoxExcludeFilter
            // 
            this.textBoxExcludeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExcludeFilter.Location = new System.Drawing.Point(15, 107);
            this.textBoxExcludeFilter.Name = "textBoxExcludeFilter";
            this.textBoxExcludeFilter.Size = new System.Drawing.Size(504, 20);
            this.textBoxExcludeFilter.TabIndex = 4;
            this.textBoxExcludeFilter.Text = "msdyn*, msfp*";
            this.textBoxExcludeFilter.TextChanged += new System.EventHandler(this.TextBoxExcludeFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entity Exclude Filter:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entity Filter:";
            // 
            // textBoxIncludeFilter
            // 
            this.textBoxIncludeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIncludeFilter.Location = new System.Drawing.Point(15, 55);
            this.textBoxIncludeFilter.Name = "textBoxIncludeFilter";
            this.textBoxIncludeFilter.Size = new System.Drawing.Size(504, 20);
            this.textBoxIncludeFilter.TabIndex = 1;
            this.textBoxIncludeFilter.Text = "*";
            this.textBoxIncludeFilter.TextChanged += new System.EventHandler(this.TextBoxIncludeFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Format: 00000000-0000-0000-0000-000000000000";
            // 
            // labelNoResults
            // 
            this.labelNoResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNoResults.AutoSize = true;
            this.labelNoResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoResults.ForeColor = System.Drawing.Color.Crimson;
            this.labelNoResults.Location = new System.Drawing.Point(506, 76);
            this.labelNoResults.Name = "labelNoResults";
            this.labelNoResults.Size = new System.Drawing.Size(77, 13);
            this.labelNoResults.TabIndex = 7;
            this.labelNoResults.Text = "No result, sorry";
            this.labelNoResults.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelNoResults.Visible = false;
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMainContainer.Controls.Add(this.labelEnterGuid);
            this.panelMainContainer.Controls.Add(this.labelNoResults);
            this.panelMainContainer.Controls.Add(this.textBoxSearchTerm);
            this.panelMainContainer.Controls.Add(this.label3);
            this.panelMainContainer.Controls.Add(this.buttonSearch);
            this.panelMainContainer.Controls.Add(this.groupBoxSettings);
            this.panelMainContainer.Controls.Add(this.linkLabelFoundRecord);
            this.panelMainContainer.Location = new System.Drawing.Point(380, 224);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(656, 381);
            this.panelMainContainer.TabIndex = 8;
            // 
            // linkLabelFoundRecord
            // 
            this.linkLabelFoundRecord.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLabelFoundRecord.Location = new System.Drawing.Point(284, 75);
            this.linkLabelFoundRecord.Name = "linkLabelFoundRecord";
            this.linkLabelFoundRecord.Size = new System.Drawing.Size(299, 46);
            this.linkLabelFoundRecord.TabIndex = 8;
            this.linkLabelFoundRecord.TabStop = true;
            this.linkLabelFoundRecord.Text = "Found record: name of record";
            this.linkLabelFoundRecord.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkLabelFoundRecord.Visible = false;
            this.linkLabelFoundRecord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelFoundRecord_LinkClicked);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1428, 879);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.panelMainContainer.ResumeLayout(false);
            this.panelMainContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadData;
        private System.Windows.Forms.Label labelEnterGuid;
        private System.Windows.Forms.TextBox textBoxSearchTerm;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIncludeFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxExcludeFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxCustomEntitiesOnly;
        private System.Windows.Forms.CheckBox checkBoxManagedEntities;
        private System.Windows.Forms.Label labelNoResults;
        private System.Windows.Forms.Panel panelMainContainer;
        private LinkLabel linkLabelFoundRecord;
    }
}
