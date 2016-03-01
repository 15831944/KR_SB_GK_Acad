namespace KR_SB_GK_Acad.Model.ExportColorIndex
{
   partial class FormExport
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
         this.components = new System.ComponentModel.Container();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.buttonExport = new System.Windows.Forms.Button();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.buttonCancel = new System.Windows.Forms.Button();
         this.textBoxInfo = new System.Windows.Forms.TextBox();
         this.labelOK = new System.Windows.Forms.Label();
         this.labelError = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // listBox1
         // 
         this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(12, 12);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(533, 329);
         this.listBox1.TabIndex = 0;
         this.listBox1.Click += new System.EventHandler(this.ZoomBlock);
         this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
         this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
         // 
         // buttonExport
         // 
         this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonExport.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonExport.Location = new System.Drawing.Point(389, 434);
         this.buttonExport.Name = "buttonExport";
         this.buttonExport.Size = new System.Drawing.Size(75, 23);
         this.buttonExport.TabIndex = 1;
         this.buttonExport.Text = "Экспорт";
         this.buttonExport.UseVisualStyleBackColor = true;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(470, 434);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "Прервать";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // textBoxInfo
         // 
         this.textBoxInfo.Location = new System.Drawing.Point(12, 357);
         this.textBoxInfo.Multiline = true;
         this.textBoxInfo.Name = "textBoxInfo";
         this.textBoxInfo.ReadOnly = true;
         this.textBoxInfo.Size = new System.Drawing.Size(533, 71);
         this.textBoxInfo.TabIndex = 2;
         // 
         // labelOK
         // 
         this.labelOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelOK.AutoSize = true;
         this.labelOK.ForeColor = System.Drawing.Color.Blue;
         this.labelOK.Location = new System.Drawing.Point(12, 447);
         this.labelOK.Name = "labelOK";
         this.labelOK.Size = new System.Drawing.Size(21, 13);
         this.labelOK.TabIndex = 8;
         this.labelOK.Text = "Ок";
         // 
         // labelError
         // 
         this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelError.AutoSize = true;
         this.labelError.ForeColor = System.Drawing.Color.Red;
         this.labelError.Location = new System.Drawing.Point(39, 447);
         this.labelError.Name = "labelError";
         this.labelError.Size = new System.Drawing.Size(96, 13);
         this.labelError.TabIndex = 9;
         this.labelError.Text = "Марки нет в базе";
         // 
         // FormExport
         // 
         this.AcceptButton = this.buttonExport;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(557, 469);
         this.Controls.Add(this.labelOK);
         this.Controls.Add(this.labelError);
         this.Controls.Add(this.textBoxInfo);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonExport);
         this.Controls.Add(this.listBox1);
         this.Name = "FormExport";
         this.Text = "Экспорт колористических индексов";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Button buttonExport;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.TextBox textBoxInfo;
      private System.Windows.Forms.Label labelOK;
      private System.Windows.Forms.Label labelError;
   }
}