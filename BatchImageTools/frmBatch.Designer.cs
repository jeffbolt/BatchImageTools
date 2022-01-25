
namespace BatchImageTools
{
	partial class frmBatch
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblSelect = new System.Windows.Forms.Label();
			this.lvwImages = new System.Windows.Forms.ListView();
			this.lblConvertTo = new System.Windows.Forms.Label();
			this.cmbFormat = new System.Windows.Forms.ComboBox();
			this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnConvert = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(13, 13);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(184, 21);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Batch Image Converter";
			// 
			// lblSelect
			// 
			this.lblSelect.AutoSize = true;
			this.lblSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSelect.Location = new System.Drawing.Point(14, 44);
			this.lblSelect.Name = "lblSelect";
			this.lblSelect.Size = new System.Drawing.Size(165, 15);
			this.lblSelect.TabIndex = 1;
			this.lblSelect.Text = "Drag or browse for image files";
			// 
			// lvwImages
			// 
			this.lvwImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Path,
            this.Height,
            this.Width,
            this.Size});
			this.lvwImages.FullRowSelect = true;
			this.lvwImages.HideSelection = false;
			this.lvwImages.Location = new System.Drawing.Point(17, 63);
			this.lvwImages.Name = "lvwImages";
			this.lvwImages.Size = new System.Drawing.Size(771, 341);
			this.lvwImages.TabIndex = 2;
			this.lvwImages.UseCompatibleStateImageBehavior = false;
			this.lvwImages.View = System.Windows.Forms.View.Details;
			// 
			// lblConvertTo
			// 
			this.lblConvertTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lblConvertTo.AutoSize = true;
			this.lblConvertTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConvertTo.Location = new System.Drawing.Point(14, 417);
			this.lblConvertTo.Name = "lblConvertTo";
			this.lblConvertTo.Size = new System.Drawing.Size(66, 15);
			this.lblConvertTo.TabIndex = 3;
			this.lblConvertTo.Text = "Convert to:";
			// 
			// cmbFormat
			// 
			this.cmbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbFormat.AutoCompleteCustomSource.AddRange(new string[] {
            "PNG",
            "JPG",
            "BMP"});
			this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFormat.FormattingEnabled = true;
			this.cmbFormat.Items.AddRange(new object[] {
            "PNG - Portable Network Graphics (*.png)"});
			this.cmbFormat.Location = new System.Drawing.Point(86, 415);
			this.cmbFormat.Name = "cmbFormat";
			this.cmbFormat.Size = new System.Drawing.Size(289, 21);
			this.cmbFormat.TabIndex = 4;
			// 
			// Path
			// 
			this.Path.Text = "File Path";
			this.Path.Width = 400;
			// 
			// Size
			// 
			this.Size.Text = "Size";
			this.Size.Width = 100;
			// 
			// Height
			// 
			this.Height.Text = "Height";
			this.Height.Width = 100;
			// 
			// Width
			// 
			this.Width.Text = "Width";
			this.Width.Width = 100;
			// 
			// btnConvert
			// 
			this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnConvert.Location = new System.Drawing.Point(381, 413);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 25);
			this.btnConvert.TabIndex = 5;
			this.btnConvert.Text = "Convert";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// frmBatch
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.cmbFormat);
			this.Controls.Add(this.lblConvertTo);
			this.Controls.Add(this.lvwImages);
			this.Controls.Add(this.lblSelect);
			this.Controls.Add(this.lblTitle);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frmBatch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Batch Image Converter";
			this.Load += new System.EventHandler(this.frmBatch_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSelect;
		private System.Windows.Forms.ListView lvwImages;
		private System.Windows.Forms.Label lblConvertTo;
		private System.Windows.Forms.ComboBox cmbFormat;
		private System.Windows.Forms.ColumnHeader Path;
		private System.Windows.Forms.ColumnHeader Height;
		private System.Windows.Forms.ColumnHeader Width;
		private System.Windows.Forms.ColumnHeader Size;
		private System.Windows.Forms.Button btnConvert;
	}
}

