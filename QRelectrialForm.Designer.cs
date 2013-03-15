namespace QRelectrial
{
   partial class QRelectrialForm
   {
      /// <summary>
      /// Erforderliche Designervariable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Verwendete Ressourcen bereinigen.
      /// </summary>
      /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Vom Windows Form-Designer generierter Code

      /// <summary>
      /// Erforderliche Methode für die Designerunterstützung.
      /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
      /// </summary>
      private void InitializeComponent()
      {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRelectrialForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cameraGroupBox = new System.Windows.Forms.GroupBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtBarcodeFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveStripButton = new System.Windows.Forms.ToolStripButton();
            this.aboutStripButton = new System.Windows.Forms.ToolStripButton();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamilyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.givenNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.cameraGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStripButton,
            this.aboutStripButton});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // cameraGroupBox
            // 
            resources.ApplyResources(this.cameraGroupBox, "cameraGroupBox");
            this.cameraGroupBox.Controls.Add(this.txtContent);
            this.cameraGroupBox.Controls.Add(this.txtBarcodeFormat);
            this.cameraGroupBox.Controls.Add(this.label3);
            this.cameraGroupBox.Controls.Add(this.label2);
            this.cameraGroupBox.Controls.Add(this.pictureBox1);
            this.cameraGroupBox.Controls.Add(this.cmbDevice);
            this.cameraGroupBox.Controls.Add(this.label1);
            this.cameraGroupBox.Name = "cameraGroupBox";
            this.cameraGroupBox.TabStop = false;
            // 
            // txtContent
            // 
            resources.ApplyResources(this.txtContent, "txtContent");
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            // 
            // txtBarcodeFormat
            // 
            resources.ApplyResources(this.txtBarcodeFormat, "txtBarcodeFormat");
            this.txtBarcodeFormat.Name = "txtBarcodeFormat";
            this.txtBarcodeFormat.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmbDevice
            // 
            resources.ApplyResources(this.cmbDevice, "cmbDevice");
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dataGridView
            // 
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.FamilyNameColumn,
            this.givenNameColumn});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // saveStripButton
            // 
            resources.ApplyResources(this.saveStripButton, "saveStripButton");
            this.saveStripButton.Image = global::QRelectrial.Properties.Resources.disk_black;
            this.saveStripButton.Name = "saveStripButton";
            this.saveStripButton.Click += new System.EventHandler(this.saveStripButton_Click);
            // 
            // aboutStripButton
            // 
            resources.ApplyResources(this.aboutStripButton, "aboutStripButton");
            this.aboutStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutStripButton.Image = global::QRelectrial.Properties.Resources.question_frame;
            this.aboutStripButton.Name = "aboutStripButton";
            this.aboutStripButton.Click += new System.EventHandler(this.aboutStripButton_Click);
            // 
            // IDColumn
            // 
            resources.ApplyResources(this.IDColumn, "IDColumn");
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FamilyNameColumn
            // 
            resources.ApplyResources(this.FamilyNameColumn, "FamilyNameColumn");
            this.FamilyNameColumn.Name = "FamilyNameColumn";
            this.FamilyNameColumn.ReadOnly = true;
            this.FamilyNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // givenNameColumn
            // 
            resources.ApplyResources(this.givenNameColumn, "givenNameColumn");
            this.givenNameColumn.Name = "givenNameColumn";
            this.givenNameColumn.ReadOnly = true;
            this.givenNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QRelectrialForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.cameraGroupBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "QRelectrialForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cameraGroupBox.ResumeLayout(false);
            this.cameraGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton saveStripButton;
      private System.Windows.Forms.ToolStripButton aboutStripButton;
      private System.Windows.Forms.GroupBox cameraGroupBox;
      private System.Windows.Forms.TextBox txtContent;
      private System.Windows.Forms.TextBox txtBarcodeFormat;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.ComboBox cmbDevice;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn FamilyNameColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn givenNameColumn;
   }
}

