using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InfoUIDisplay : MonoBehaviour            //Attached to the InfoCanvas Prefab game object
{
    [Header("GameObject Variables")]
    public GameObject InfoPanelGO;
    public GameObject MediumInfoGO;
    public GameObject HardInfoGO;

    [Tooltip("Text Mesh Object of the Timer Text")]
    public TextMeshProUGUI TimerText;

    [Tooltip("Text Mesh Object of the Info Title Text")]
    public TextMeshProUGUI InfoTitleText;        

    /*
     * Start on instatiate set text, object based on which mode string is pass in
     */
    public void OnInsantiate(string WhichMode)
    {
        MediumInfoGO.SetActive(false);
        HardInfoGO.SetActive(false);

        if (WhichMode == "EasyInfo")
        {
            TimerText.text = "2 minutes";
            InfoTitleText.text = "Easy Mode";
        }
        else if (WhichMode == "MediumInfo")
        {
            TimerText.text = "1 minute";
            InfoTitleText.text = "Medium Mode";
            MediumInfoGO.SetActive(true);
        }
        else
        {
            TimerText.text = "1 minute";
            InfoTitleText.text = "Hard Mode";
            HardInfoGO.SetActive(true);
        }
    }

    /*
    * Selecting the Close Info Button
    */
    public void OnInfoClose()
    {
        Destroy(InfoPanelGO);        
    }
}
