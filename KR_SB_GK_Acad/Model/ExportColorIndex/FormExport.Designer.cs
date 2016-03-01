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
         this.SuspendLayout();
         // 
         // listBox1
         // 
         this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(12, 12);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(533, 407);
         this.listBox1.TabIndex = 0;
         this.listBox1.Click += new System.EventHandler(this.ZoomBlock);
         // 
         // buttonExport
         // 
         this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
         // FormExport
         // 
         this.AcceptButton = this.buttonExport;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(557, 469);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonExport);
         this.Controls.Add(this.listBox1);
         this.Name = "FormExport";
         this.Text = "Экспорт колористических индексов";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Button buttonExport;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Button buttonCancel;
   }
}