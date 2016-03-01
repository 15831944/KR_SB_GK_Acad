using System;
using AcadLib.Errors;
using Autodesk.AutoCAD.DatabaseServices;

namespace KR_SB_GK_Acad.Model.Select
{
   public class Workspace
   {
      public Extents3d Extents { get; private set; }
      public string Section { get; private set; }
      public string Floor { get; private set; }

      public Workspace(BlockReference blRef)
      {
         try
         {
            Extents = blRef.GeometricExtents;
         }
         catch (Exception ex)
         {
            throw new Exception("Ошибка определения границ блока. Необходимо выполнить проверку чертежа командой _audit с исправлением ошибок.", ex);                
         }
         defineAttrs(blRef);
         checks();
      }      

      private void defineAttrs(BlockReference blRef)
      {
         if (blRef.AttributeCollection == null)
         {
            throw new Exception ($"Не определены атрибуты: '{Options.Instance.WorkspaceAttrSection}', '{Options.Instance.WorkspaceAttrFloor}'.");
         }

         foreach (ObjectId idAtr in blRef.AttributeCollection)
         {
            using (var atrRef = idAtr.Open( OpenMode.ForRead, false, true) as AttributeReference)
            {
               if (atrRef.Tag.Equals(Options.Instance.WorkspaceAttrSection, StringComparison.OrdinalIgnoreCase))
               {
                  Section = atrRef.TextString;
               }
               else if (atrRef.Tag.Equals(Options.Instance.WorkspaceAttrFloor, StringComparison.OrdinalIgnoreCase))
               {
                  Floor = atrRef.TextString;
               }
            }
         }
      }

      private void checks()
      {
         // Пока никаких проверок
      }
   }
}