using System.Collections.Generic;
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
    public GameObject LeftDoorButton;
    public GameObject RightDoorButton;
    public GameObject LeftDoor;
    public GameObject RightDoor;

    public Button CameraSwitch;
    public List<GameObject> Models = new List<GameObject>(); 
    public bool SecurityCamerasActive = false;
    private bool LockOutFlag = false;

    public bool LeftProtection = false;
    public bool RightProtection = false;


    private SecurityCamController SecurityCameras;


    public void Initialize(int nightNumber, SecurityCamController securityCameras, List<GameObject> models, GameObject leftDoor, GameObject rightDoor)
    {
        Power = transform.Find("Power").GetComponent<Text>();
        Hour = transform.Find("Hour").GetComponent<Text>();
        Night = transform.Find("Night").GetComponent<Text>();
        UsageBarObj = transform.Find("Usage").GetComponent<UsageBar>();
        UpdatePowerText(100);
        UpdateHourText(12);
        MiniMap = transform.Find("MiniMap").gameObject;
        LeftDoorButton = transform.Find("LeftDoor").gameObject;
        RightDoorButton = transform.Find("RightDoor").gameObject;
        Models = models;
        LeftDoor = leftDoor;
        RightDoor = rightDoor;

        LeftDoorButton.GetComponent<Button>().onClick.AddListener(() => LeftProtectionButtonAction());
        RightDoorButton.GetComponent<Button>().onClick.AddListener(() => RightProtectionButtonAction());
        
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
        if (!LockOutFlag)
        {
            SecurityCamerasActive = !SecurityCamerasActive;
            SecurityCameras.gameObject.SetActive(SecurityCamerasActive);
        
            MiniMap.SetActive(SecurityCamerasActive);
            LeftDoorButton.SetActive(!SecurityCamerasActive);
            RightDoorButton.SetActive(!SecurityCamerasActive);
            foreach (GameObject model in Models)
            {
                model.SetActive(!SecurityCamerasActive);
            }
        }
        else
        {
            SecurityCameras.gameObject.SetActive(false);
            MiniMap.SetActive(false);
            foreach (GameObject model in Models)
            {
                model.SetActive(true);
            }
            LeftDoorButton.SetActive(false);
            RightDoorButton.SetActive(false);
        }
    }

    public void LeftProtectionButtonAction()
    {
        if (!LockOutFlag)
        {
            LeftProtection = !LeftProtection;
            if (LeftProtection)
            {
                LeftDoor.GetComponent<Animator>().Play("DoorClose");
            }
            else
            {
                LeftDoor.GetComponent<Animator>().Play("DoorOpen");
            }
            Debug.Log(LeftProtection);
        }
        else
        {
            LeftProtection = false;
        }
    }

    public void RightProtectionButtonAction()
    {
        if (!LockOutFlag)
        {
            RightProtection = !RightProtection;
            if (RightProtection)
            {
                RightDoor.GetComponent<Animator>().Play("DoorClose");
            }
            else
            {
                RightDoor.GetComponent<Animator>().Play("DoorOpen");
            }
            Debug.Log(RightProtection);
        }
        else
        {
            RightProtection = false;
        }
    }

    public void LockOut()
    {
        LockOutFlag = true;
        ToggleCameraView();
        RightProtectionButtonAction();
        LeftProtectionButtonAction();
    }
}
