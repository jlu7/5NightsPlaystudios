using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Power;
    public Text Hour;
    public Text Night;
    public UsageBar UsageBarObj;
    public GameObject MiniMap;
    public Button CameraSwitch;
    public bool SecurityCamerasActive = false;


    private SecurityCamController SecurityCameras;


    public void Initialize(int nightNumber, SecurityCamController securityCameras)
    {
        Power = transform.Find("Power").GetComponent<Text>();
        Hour = transform.Find("Hour").GetComponent<Text>();
        Night = transform.Find("Night").GetComponent<Text>();
        UsageBarObj = transform.Find("Usage").GetComponent<UsageBar>();
        UpdatePowerText(100);
        UpdateHourText(12);
        MiniMap = transform.Find("MiniMap").gameObject;
        Night.text = "Night " + nightNumber;
        UsageBarObj.UpdateUsageBar(0);

        SecurityCameras = securityCameras;
        MiniMap.SetActive(SecurityCamerasActive);
        securityCameras.gameObject.SetActive(SecurityCamerasActive);
        CameraSwitch = transform.Find("CameraSwitch").GetComponent<Button>();
        CameraSwitch.onClick.AddListener(() => ToggleCameraView());
    }

    public void UpdatePowerText(int powerTo)
    {
        Power.text = "Power Left: " + powerTo + "%";
    }

    public void UpdateHourText(int timeTo)
    {
        if (timeTo == 0)
        {
            Hour.text = 12 + " AM";
        }
        else
        {
            Hour.text = timeTo + " AM";
        }
    }

    public void ToggleCameraView()
    {
        SecurityCamerasActive = !SecurityCamerasActive;
        SecurityCameras.gameObject.SetActive(SecurityCamerasActive);
        
        Debug.Log(SecurityCameras.gameObject.activeSelf);

        MiniMap.SetActive(SecurityCamerasActive);
    }
}
