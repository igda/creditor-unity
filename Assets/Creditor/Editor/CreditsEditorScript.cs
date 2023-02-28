using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CreditsEditorScript : EditorWindow
{
    [MenuItem("CONTEXT/Transform/Load Credits File")]
    private static void LoadCredits(MenuCommand menuCommand)
    {
        Transform parentObject = menuCommand.context as Transform;
        CreditsController creditsController = parentObject.GetComponent<CreditsController>();
        var csv = new CsvHelper.CsvReader(new System.IO.StringReader(creditsController.CSVCredits.ToString()));

        creditsController.InformUnityEditorToSaveComponentState();

        //Clear previous credits
        creditsController.ClearCredits();

        while (csv.Read())
        {
            //Create new credit record
            CreditsController.CreditStruct credit = new CreditsController.CreditStruct();
            string format = csv.GetField<string>("Format");
            credit.format = format;
            credit.columns = new string[creditsController.NumberOfContentColumns];
            for(int ii=1; ii<=creditsController.NumberOfContentColumns; ++ii)
            {
                string columnText = "";
                columnText = csv.GetField<string>("Column" + ii);
                credit.columns[ii - 1] = columnText;
            }
            creditsController.AddCredit(credit);

            //Create new format if format does not already exist
            creditsController.AddFormat(format);
        }
        
    }
}
