Creditor-Unity
===

This is an Unity package and associated resources to more quickly aid in adding credits to your project. It loads data from a CSV file to generate a credits canvas that can be styled in the editor and with UI prefabs.

A sibling project for Unreal Engine can be found, [here](https://github.com/igda/creditor-ue).

Setup - Using Package
===

* Import the Creditor package in your Unity project
* Create a new scene with preferred camera settings (it is recommended you set the camera background to black if you do not have a planned background image or color)
* Follow the below Usage steps

Setup - Using Repository
===

* Clone this repository
* Open the Unity project
* Open the SampleScene.unity
* Follow the below Usage steps

Usage
===

* Import your credits CSV file or update the Assets/Creditor/Example Prefab Formats/credits.csv to your desired credits
* Import any images that should be displayed in the credits to Assets/Resources/Credits
* Drag the Assets/Creditor/CreditsCanvas.prefab into the scene hierarchy 
* Click on the CreditsCanvas in the scene hierarchy to open the CreditsCanvas GameObject in the inspector
* In the Credits Controller (Script) component on the CreditsCanvas, add your credits CSV file to the "CSV Credits" 
![image](https://user-images.githubusercontent.com/4603367/223573064-938a1164-4d32-4328-a25f-d89087cf6974.png)
* In the Credits Controller (Script) component on the CreditsCanvas, list the number of content columns in the "Number of Content Columns" value
* Right-click on the Rect Transform bar of the CreditsCanvas in the inspector and select "Load Credits File". This must be selected every time the CSV is updated to force an update of the Credits Controller format and credit values.
![image](https://user-images.githubusercontent.com/4603367/223571953-ccf048fe-4ce6-46a0-acb8-1b6ad455cc89.png)
* Scroll down in the inspector to the Credits Controller (Script) component and set the credit type (TEXT or IMAGE) and UI prefabs (Format Prefabs) for each format. 
  * Only add as many Format Prefabs as there are columns for that particular format type row (e.g. a "Studio Name" format will probably only have one UI prefab even if other format rows have more columns)
  * Text UI prefabs should have their Text component at their top level (not on a child)
  * Image UI prefabs should have their Image component at their top level (not on a child)
* Finalize accessibility settings and integrations: 
  * Make any final adjustments to the Credit Scroll Speed on the Credits Controller (Script) component
  * Ensure your text UI prefabs are connected to your project's text accessibility controls (e.g. font size settings)
  * NOTE: To improve accessibility, the CreditsController.cs checks on Update for any down key press and will pause/unpause the credits scroll accordingly. You may need to adjust this to integrate it with your project's text accessibility controls. 

CSV Formatting
===

Please refer to the IGDA Credit SIGs [crediting standards](https://docs.google.com/document/d/1UugKrEZaQISmKiE6jqnNqSmoyQE-h3ju_W_Do_hJEqU) or the simplified [one-sheet version](https://docs.google.com/document/d/1-7h1QfjKlY1GWZURWzWubwil035xYT02IlgtINlgPnE) for guidelines on how to properly credit developers.

* The first row of the CSV should have the column "Format" followed by a column for each potential column named "Column#", where # is the number of the column of data starting at 1 (e.g. "Column1", "Column2", etc)
![image](https://user-images.githubusercontent.com/4603367/223575457-7935443a-2f8b-4214-9501-60edaf6c72e8.png)
* List a string to represent the format for each row in the first column (the Format column). You may create as many formats and as many rows as you would like. 
* Present the data for each row in the accompanying columns. Group together information that you would like to be formatted together (e.g. you will likely wish to put the first name and last name of each developer in the same column instead of separate columns) 
* Each row can represent either text or image data, not both. Image rows will need to be listed with a different format that text rows (e.g. "studioName" format and "studioLogo" format).
* Images should be listed in their context columns by their file name with file format not included (e.g. "IGDA_Long_HEX-01_whitetext" for the image file IGDA_Long_HEX-01_whitetext.png)
![image](https://user-images.githubusercontent.com/4603367/225189949-e6494bb2-1aa4-40e4-bbb0-3801686ee8e4.png)

Additional Licenses
===

This project uses thirdparty modules whose licenses are listed [here](thirdparty-licenses.md). Please review their licensing requirements as to how to include appropriate notices for their use in your project.

About
===

This project is maintained by the IGDA [Engineering](https://igda.org/sigs/engineering) and [Credits](https://igda.org/sigs/credits) SIGs. To contribute, open a Pull Request or submit an Issue!

Join the discussion on the IGDA Engineering SIG's [Discord](https://discord.gg/mm6ZHuggaB).
