using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Power;
    public Text Hour;
    public Text Night;
    public UsageBar UsageBarObj;

    public void Initialize(int nightNumber)
    {
        Power = transform.Find("Power").GetComponent<Text>();
        Hour = transform.Find("Hour").GetComponent<Text>();
        Night = transform.Find("Night").GetComponent<Text>();
        UsageBarObj = transform.Find("Usage").GetComponent<UsageBar>();
        UpdatePowerText(100);
        UpdateHourText(12);
        Night.text = "Night " + nightNumber;
        UsageBarObj.UpdateUsageBar(0);
    }

    public void UpdatePowerText(int powerTo)
    {
        Power.text = "Power Left: " + powerTo + "%";
    }

    public void UpdateHourText(int timeTo)
    {
        Hour.text = timeTo + " AM";
    }
}
