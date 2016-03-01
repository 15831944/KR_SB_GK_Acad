using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using KR_SB_GK_Acad.Model.Select;

namespace KR_SB_GK_Acad.Model.ExportColorIndex
{
   public partial class FormExport : Form
   {
      public FormExport(List<OutsidePanel> panels)
      {
         InitializeComponent();
         listBox1.DataSource = panels;         
      }      

      private void ZoomBlock(object sender, EventArgs e)
      {         
         OutsidePanel panel = (OutsidePanel)listBox1.SelectedItem;
         if (panel != null)
         {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.Zoom(panel.Extents);
         }
      }

      public void SetDialogMode (bool modal)
      {
         buttonExport.Visible = modal;
         buttonCancel.Visible = modal;
      }
   }
}
