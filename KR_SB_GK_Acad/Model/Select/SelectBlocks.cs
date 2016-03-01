using System;
using System.Linq;
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcadLib.Errors;

namespace KR_SB_GK_Acad.Model.Select
{
   // Выбор панелей в чертеже
   public class SelectBlocks
   {
      private Database _db;

      public SelectBlocks(Database db)
      {
         _db = db;
      }

      public SelectBlocks()
      {
         _db = HostApplicationServices.WorkingDatabase;
      }           

      /// <summary>
      /// Вхождения блоков наружных стеновых панелей
      /// </summary>
      public List<OutsidePanel> OutsidePanels { get; private set; }      

      /// <summary>
      /// Блоки Рабочих областей в Модели
      /// </summary>
      public List<Workspace> Workspaces { get; private set; }      

      /// <summary>
      /// Выбор вхождений блоков панелей наружек
      /// + выбор блоков раб областей      
      /// </summary>
      public void SelectOutsidesAndWorkspaces()
      {
         Workspaces = new List<Workspace>();
         OutsidePanels = new List<OutsidePanel>();         

         using (var ms = SymbolUtilityServices.GetBlockModelSpaceId(_db).Open(OpenMode.ForRead) as BlockTableRecord)
         {
            foreach (ObjectId idEnt in ms)
            {
               using (var blRef = idEnt.Open(OpenMode.ForRead, false, true) as BlockReference)
               {
                  if (blRef == null) continue;
                  var blName = blRef.GetEffectiveName();

                  // Рабочая область
                  if (blName.Equals(Options.Instance.WorkspaceBlockName, StringComparison.OrdinalIgnoreCase))
                  {
                     try
                     {
                        Workspace ws = new Workspace(blRef);
                        if (ws.IsOk)
                        {
                           Workspaces.Add(ws);
                        }
                        else
                        {
                           Inspector.AddError($"Ошибка определения блока рабочей области - {ws.Error}.",
                              blRef, System.Drawing.SystemIcons.Error);
                        }   
                     }
                     catch (Exception ex)
                     {
                        Inspector.AddError($"Ошибка определения блока рабочей области - {ex.Message}.",
                              blRef, System.Drawing.SystemIcons.Error);
                     }    
                  }
                  // Наружка
                  else
                  {
                     try
                     {
                        OutsidePanel outPanel = new OutsidePanel(blRef, blName);
                        if (outPanel.IsBlockOutsidePanel)
                        {
                           if (outPanel.IsOk)
                           {
                              OutsidePanels.Add(outPanel);
                           }
                           else
                           {
                              Inspector.AddError($"Ошибка определения блока наружной стеновой панели - {outPanel.Error}.",
                              blRef, System.Drawing.SystemIcons.Error);
                           }                           
                        }                        
                     }
                     catch (Exception ex) when (ex.Message == OutsidePanel.NotOutsidePanel)
                     {
                        // пропускаем этот блок - это не наружка
                     }
                     catch (Exception ex) 
                     {
                        Inspector.AddError($"Ошибка определения блока наружной стеновой панели - {ex.Message}.",
                              blRef, System.Drawing.SystemIcons.Error);
                     }
                  }
               }
            }
         }         
      }     
   }
}