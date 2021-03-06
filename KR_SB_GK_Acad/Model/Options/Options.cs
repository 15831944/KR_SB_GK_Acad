﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using AcadLib.Files;
using Autodesk.AutoCAD.ApplicationServices;

namespace KR_SB_GK_Acad.Model
{
   [Serializable]
   public class Options
   {
      private static readonly string fileOptions = Path.Combine(
                     AutoCAD_PIK_Manager.Settings.PikSettings.ServerShareSettingsFolder,
                     "СБ-ГК\\SB_GK_ExportColors.xml");
      private static Options _instance;
      public static Options Instance
      {
         get
         {
            if (_instance == null)
            {
               _instance = Load();
            }
            return _instance;
         }
      }

      private Options() { }     
      
      /// <summary>
      /// Имя блока рабочей области.
      /// </summary>
      [Category("Рабочая область")]
      [Description("Имя блока рабочей области.")]
      [DefaultValue("rab_obl")]
      public string WorkspaceBlockName { get; set; } = "rab_obl";

      /// <summary>
      /// Атрибут секции
      /// </summary>
      [Category("Рабочая область")]
      [Description("Атрибут секции.")]
      [DefaultValue("СЕКЦИЯ")]
      public string WorkspaceAttrSection { get; set; } = "СЕКЦИЯ";

      /// <summary>
      /// Атрибут этажа
      /// </summary>
      [Category("Рабочая область")]
      [Description("Атрибут этажа.")]
      [DefaultValue("ЭТАЖ")]
      public string WorkspaceAttrFloor { get; set; } = "ЭТАЖ";

      /// <summary>
      /// Атрибут марки
      /// </summary>
      [Category("Наружки")]
      [Description("Атрибут марки.")]
      [DefaultValue("МАРКА")]
      public string OutsidePanelAttrMark { get; set; } = "МАРКА";

      /// <summary>
      /// Атрибут покраски
      /// </summary>
      [Category("Наружки")]
      [Description("Атрибут покраски.")]
      [DefaultValue("ПОКРАСКА")]
      public string OutsidePanelAttrColorIndex { get; set; } = "ПОКРАСКА";

      public static Options Load()
      {
         Options options = null;
         // загрузка из файла настроек
         if (File.Exists(fileOptions))
         {
            SerializerXml xmlSer = new SerializerXml(fileOptions);
            try
            {
               options = xmlSer.DeserializeXmlFile<Options>();
               if (options != null)
               {  
                  return options;
               }
            }
            catch (Exception ex)
            {
               Logger.Log.Error(ex, $"Не удалось десериализовать настройки из файла {fileOptions}");
            }
         }
         options = new Options();
         options.Save();
         return options;
      }     

      public void Save()
      {
         try
         {
            if (!File.Exists(fileOptions))
            {
               Directory.CreateDirectory(Path.GetDirectoryName(fileOptions));
            }
            SerializerXml xmlSer = new SerializerXml(fileOptions);
            xmlSer.SerializeList(this);            
         }
         catch (Exception ex)
         {
            Logger.Log.Error(ex, $"Не удалось сериализовать настройки в {fileOptions}");
         }
      }            

      public static void Show()
      {
         FormOptions formOpt = new FormOptions((Options)Instance.MemberwiseClone());
         if (Application.ShowModalDialog(formOpt) == System.Windows.Forms.DialogResult.OK)
         {
            _instance = formOpt.Options;
            _instance.Save();
         }
      }
   }
}