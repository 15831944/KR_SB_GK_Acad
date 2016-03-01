using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
   }
}
