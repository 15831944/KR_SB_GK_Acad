using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadLib.Errors;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using KR_SB_GK_Acad.Model.ExportColorIndex;

[assembly: CommandClass(typeof(KR_SB_GK_Acad.Commands))]

namespace KR_SB_GK_Acad
{
   public class Commands
   {
      [CommandMethod("PIK", "SB_ExportColorIndexToD", CommandFlags.Modal | CommandFlags.NoPaperSpace | CommandFlags.NoBlockEditor)]
      public void SB_ExportColorIndexToDB()
      {
         Logger.Log.StartCommand(nameof(SB_ExportColorIndexToDB));
         Document doc = Application.DocumentManager.MdiActiveDocument;
         if (doc == null) return;

         try
         {
            if (!Access.Success())
            {
               doc.Editor.WriteMessage("\nОтказано в доступе.");
               return;
            }

            Inspector.Clear();

            ExportColor exportColor = new ExportColor();
            exportColor.Export();

            if (Inspector.HasErrors)
            {
               Inspector.Show();
            }
         }
         catch (System.Exception ex)
         {
            doc.Editor.WriteMessage($"\nОшибка экспорта колористических индексов: {ex.Message}");
            if (!ex.Message.Contains("Отменено пользователем"))
            {               
               Logger.Log.Error(ex, $"{nameof(SB_ExportColorIndexToDB)}. {doc.Name}");
            }
         }
      }
   }
}
