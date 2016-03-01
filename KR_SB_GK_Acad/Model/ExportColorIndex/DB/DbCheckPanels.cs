using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_SB_GK_Acad.Model.ExportColorIndex.DB
{
   public static class DbCheckPanels
   {
      public static void Check(List<OutsidePanel> panels)
      {
         using (var entities = DbExportColor.ConnectEntities())
         {
            // Найти панель в базе
            foreach (var panel in panels)
            {
               var itemEnt = entities.I_R_Item.Where(i=>i.HandMark != null).FirstOrDefault(i => i.HandMark.Equals(panel.Mark, StringComparison.OrdinalIgnoreCase));
               if (itemEnt == null)
               {
                  panel.DbStatus = EnumBaseStatus.NotFound;                  
               }
            }
         }
      }
   }
}
