using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR_SB_GK_Acad.Model.Select;

namespace KR_SB_GK_Acad.Model.ExportColorIndex.DB
{
   public static class DbExportColor
   {
      public static Entities ConnectEntities()
      {
         return new Entities(new EntityConnection(Properties.Settings.Default.SaprCon));
      }

      public static void Export (List<OutsidePanel> panels)
      {

      }      
   }
}
