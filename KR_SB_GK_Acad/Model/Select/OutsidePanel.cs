using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace KR_SB_GK_Acad.Model.Select
{
   public class OutsidePanel
   {
      public const string NotOutsidePanel = "Это не наружка";

      public string BlName { get; private set; }
      public ObjectId IdBlRef { get; private set; }
      public string Mark { get; private set; }
      public string ColorIndex { get; private set; }
      public Point3d Position { get; private set; }
      public Workspace Workspace { get; set; }                    

      public OutsidePanel(BlockReference blRef, string blName)
      {
         IdBlRef = blRef.Id;
         BlName = blName;
         Position = blRef.Position;

         defineAttrs(blRef);
         check();
      }    

      private void defineAttrs(BlockReference blRef)
      {
         if (blRef.AttributeCollection == null)
         {
            throw new Exception(NotOutsidePanel);
         }

         foreach (ObjectId idAtr in blRef.AttributeCollection)
         {
            using (var atrRef = idAtr.Open(OpenMode.ForRead, false, true) as AttributeReference)
            {
               if (atrRef.Tag.Equals(Options.Instance.OutsidePanelAttrMark, StringComparison.OrdinalIgnoreCase))
               {
                  Mark = atrRef.TextString;
               }
               else if (atrRef.Tag.Equals(Options.Instance.OutsidePanelAttrColorIndex, StringComparison.OrdinalIgnoreCase))
               {
                  ColorIndex = atrRef.TextString;
               }
            }
         }
      }

      private void check()
      {
         // Проверка.
         if (Mark == null || ColorIndex == null)
         {
            // Это не блок наружки
            throw new Exception(NotOutsidePanel);
         }
      }
   }
}