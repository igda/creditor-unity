using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CreditsController : MonoBehaviour
{
    public TextAsset CSVCredits;
    public int NumberOfContentColumns = 3;
    public GameObject creditPanelPrefab;
    public GameObject creditMainPanel;
    public float creditScrollSpeed;
    bool paused = false;

    public enum CreditType
    {
        TEXT,
        IMAGE
    }

    [System.Serializable]
    public struct FormatStruct
    {
        public string format;
        public CreditType creditType;
        public List<GameObject> formatPrefabs; //There must be as many Prefabs listed as the number of columns for that format
    }

    public List<FormatStruct> formats;

    [System.Serializable]
    public struct CreditStruct
    {
        public string format;
        public string[] columns;
    }

    public List<CreditStruct> credits;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("First Credit: " + credits[0].columns[0]);
        GameObject creditsCanvas = gameObject;
        for (int ii = 0; ii < credits.Count; ++ii)
        {
            FormatStruct format = GetFormat(credits[ii].format);
            GameObject panel = Instantiate(creditPanelPrefab, creditMainPanel.transform);
            for(int jj = 0; jj < format.formatPrefabs.Count; ++jj)
            {
                GameObject creditColumn = Instantiate(format.formatPrefabs[jj], panel.transform);
                if(format.creditType == CreditType.TEXT)
                {
                    creditColumn.GetComponent<Text>().text = credits[ii].columns[jj];
                } else if (format.creditType == CreditType.IMAGE)
                {
                    creditColumn.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Credits/" + credits[ii].columns[jj]);
                    creditColumn.GetComponent<UnityEngine.UI.Image>().preserveAspect = true;
                }

            }         
        }
    }

    //Remove this update if triggering PauseUnpauseCreditsScroll through another input manager
    private void Update()
    {
        //Returns true the first frame that the user presses any key, pausing or unpausing the credits
        //You may replace the input with specific keys or another input tracker 
        if(Input.anyKeyDown)
        {
            PauseUnpauseCreditsScroll();
        }
    }

    void PauseUnpauseCreditsScroll()
    {
        paused = !paused;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            creditMainPanel.transform.localPosition = new Vector2(creditMainPanel.transform.localPosition.x, creditMainPanel.transform.localPosition.y + creditScrollSpeed);
        }
    }

    void GenerateCreditEntry(CreditStruct credit)
    {
        FormatStruct format = GetFormat(credit.format);
        if(string.IsNullOrEmpty(format.format))
        {
            Debug.LogError("Credit entry format (" + credit.format + ") is missing from formats");
            return;
        }

    }

    public void ClearCredits()
    {
        Debug.Log("CLearing Credits");
        credits = new List<CreditStruct>();
    }

    public void AddCredit(CreditStruct credit)
    {
        credits.Add(credit);
    }

    public void AddFormat(string formatName)
    {
        for (int ii = 0; ii < formats.Count; ++ii)
        {
            if (formats[ii].format == formatName)
            {
                //Debug.Log("Already recorded format: " + formatName);
                formatName = "";
                break;
            }
        }
        if (!string.IsNullOrEmpty(formatName))
        {
            CreditsController.FormatStruct newFormat = new CreditsController.FormatStruct();
            newFormat.format = formatName;
            formats.Add(newFormat);
        }
    }

    public void InformUnityEditorToSaveComponentState()
    {
        Undo.RecordObject(this, "Updated credits and credit formats");
    }

    public FormatStruct GetFormat(string formatName)
    {
        foreach (FormatStruct format in formats)
        {
            if(format.format == formatName)
            {
                return format;
            }
        }
        FormatStruct nullFormat = new FormatStruct
        {
            format = ""
        };
        return nullFormat;
    }
}
