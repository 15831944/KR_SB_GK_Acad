using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadLib.Errors;
using KR_SB_GK_Acad.Model.Select;
using RTreeLib;

namespace KR_SB_GK_Acad.Model.ExportColorIndex
{
   /// <summary>
   /// Экспорт колористических индексов монтажных панелей в базу
   /// </summary>
   public class ExportColor
   {  
      public void Export()
      {
         // определение наружек для экспорта
         var outsPanelToExport = defineOutsidePanelsToExport();

         if (Inspector.HasErrors)
         {
            // Есть ошибки при определении блоков - продолжать или нет - показ пользователю формы с ошибками, с возможостью продолжить или прервать.
            Inspector.ShowDialog();
            Inspector.Clear();
         }             


      }

      private List<OutsidePanel> defineOutsidePanelsToExport()
      {
         List<OutsidePanel> outPanelsToExport = new List<OutsidePanel>();
         // Выбор блоков
         SelectBlocks selectBl = new SelectBlocks();
         selectBl.SelectOutsidesAndWorkspaces();

         // Связывание блоков наружек и рабочих областей. 
         RTree<Workspace> treeWs = getRTreeWS(selectBl.Workspaces);

         foreach (var outPanel in selectBl.OutsidePanels)
         {
            Point p = new Point(outPanel.Position.X, outPanel.Position.Y, 0);
            var nearestWs = treeWs.Nearest(p, 1).FirstOrDefault();
            if (nearestWs != null)
            {
               outPanel.Workspace = nearestWs;
               outPanelsToExport.Add(outPanel);
            }
            else
            {
               // Для панели не определена рабочая область
               Inspector.AddError($"Для наружной стеновой панели '{outPanel.Mark}' не определена рабочая область.",
                  outPanel.IdBlRef, System.Drawing.SystemIcons.Exclamation);
            }
         }
         return outPanelsToExport;
      }

      private RTree<Workspace> getRTreeWS(List<Workspace> workspaces)
      {
         RTree<Workspace> treeWS = new RTree<Workspace>();
         foreach (var ws in workspaces)
         {
            Rectangle r = new Rectangle(ws.Extents.MinPoint.X, ws.Extents.MinPoint.Y, ws.Extents.MaxPoint.X, ws.Extents.MaxPoint.Y, 0,0);
            try
            {
               treeWS.Add(r, ws);
            }
            catch { }
         }
         return treeWS;
      }
   }
}
