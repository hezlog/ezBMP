namespace WindowsFormsApplication1
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.button_change = new System.Windows.Forms.Button();
            this.comboBox_change = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button_change
            // 
            resources.ApplyResources(this.button_change, "button_change");
            this.button_change.Name = "button_change";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // comboBox_change
            // 
            resources.ApplyResources(this.comboBox_change, "comboBox_change");
            this.comboBox_change.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_change.FormattingEnabled = true;
            this.comboBox_change.Items.AddRange(new object[] {
            resources.GetString("comboBox_change.Items"),
            resources.GetString("comboBox_change.Items1"),
            resources.GetString("comboBox_change.Items2"),
            resources.GetString("comboBox_change.Items3"),
            resources.GetString("comboBox_change.Items4"),
            resources.GetString("comboBox_change.Items5"),
            resources.GetString("comboBox_change.Items6")});
            this.comboBox_change.Name = "comboBox_change";
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // button_save
            // 
            resources.ApplyResources(this.button_save, "button_save");
            this.button_save.Name = "button_save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_save);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button_change);
            this.groupBox1.Controls.Add(this.comboBox_change);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button button_change;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.ComboBox comboBox_change;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.SaveFileDialog saveFileDialog1;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Button button_save;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label label4;
	}
}
