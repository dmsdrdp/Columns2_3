﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Задание 2.3 Количество колонн в модели

namespace Columns2_3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<FamilyInstance> columnTypes = new FilteredElementCollector(doc)
                           .OfCategory(BuiltInCategory.OST_StructuralColumns)
                           .WhereElementIsNotElementType()
                           .Cast<FamilyInstance>()
                           .ToList();

            TaskDialog.Show("Column types info", columnTypes.Count.ToString());

            return Result.Succeeded;
        }
    }
}
