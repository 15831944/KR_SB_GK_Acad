using System;
using AcadLib.Errors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using KR_SB_GK_Acad.Model.ExportColorIndex.DB;

namespace KR_SB_GK_Acad.Model.ExportColorIndex
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
      public bool IsOk { get { return string.IsNullOrEmpty(Error); } }
      public bool IsBlockOutsidePanel { get; private set; }
      public string Error { get; private set; }
      public string Info { get; private set; }
      public EnumBaseStatus DbStatus { get; set; }

      public Extents3d Extents {
         get
         {
            if (!_hasExtents)
            {
               _hasExtents = true;
               using (var blRef = IdBlRef.Open(OpenMode.ForRead, false, true) as BlockReference)
               {
                  _extents = blRef.GeometricExtents;
               }
            }
            return _extents;
         }
      }
      private Extents3d _extents;
      private bool _hasExtents;

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
            IsBlockOutsidePanel = false;
         }
         else
         {
            foreach (ObjectId idAtr in blRef.AttributeCollection)
            {
               using (var atrRef = idAtr.Open(OpenMode.ForRead, false, true) as AttributeReference)
               {
                  if (atrRef.Tag.Equals(Options.Instance.OutsidePanelAttrMark, StringComparison.OrdinalIgnoreCase))
                  {
                     Mark = atrRef.TextString.Trim();
                  }
                  else if (atrRef.Tag.Equals(Options.Instance.OutsidePanelAttrColorIndex, StringComparison.OrdinalIgnoreCase))
                  {
                     ColorIndex = atrRef.TextString.Trim();
                  }
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
            IsBlockOutsidePanel = false;
            return;           
         }

         IsBlockOutsidePanel = true;

         if (string.IsNullOrEmpty(ColorIndex))
         {
            IsBlockOutsidePanel = true;            
            Error = $"Пустая покраска в блоке панели {BlName}.";            
         }
         if (string.IsNullOrEmpty(Mark))
         {
            IsBlockOutsidePanel = true;
            Error = $"Пустая марка в блоке панели {BlName}.";
         }
      }

      public override string ToString()
      {
         return Mark + ColorIndex + ", Секция " + Workspace.Section + ", Этаж " + Workspace.Floor;
      }
   }
}