using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour 
{
	SecurityCamController SecurityCameras;
    HUD HUDController;
    private List<Character> Characters = new List<Character>(); 

    public float PowerAmount = 100;

	// Use this for initialization
	public void Initialize(int level) 
    {
		GameObject securityCamsPrefab = Resources.Load("Prefabs/Views/SecurityCameras") as GameObject;
		SecurityCameras = GameObject.Instantiate<GameObject>(securityCamsPrefab).GetComponent<SecurityCamController>();
		SecurityCameras.transform.parent = this.transform;
		SecurityCameras.Initialize();
        Characters.Add(this.transform.Find("Mitzy").GetComponent<Mitzy>());

	    if (level == 1)
	    {
	        HUDController = transform.Find("HUD").GetComponent<HUD>();
            HUDController.Initialize(1, SecurityCameras);
            foreach (Character chara in Characters)
	        {
	            chara.Initialize(HUDController, SecurityCameras);
	        }
	    }

	    StartCoroutine(Time());
    }
	
	IEnumerator ChangeCam()
	{
		yield return new WaitForSeconds(2f);

		if (SecurityCameras.ActiveCam+1 >= SecurityCameras.SecurityCameraArr.Length)
		{
			SecurityCameras.SetSecurityCam(0);
		}
		else
		{
			SecurityCameras.SetSecurityCam(SecurityCameras.ActiveCam + 1);
		}
		
		
		StartCoroutine(ChangeCam());
	}

    protected IEnumerator Time()
    {
        float Hour = 0;

        foreach (Character chara in Characters)
        {
            StartCoroutine(chara.Logic());
        }

        while (true)
        {
            int EnergyUsage = 0;

            if (Hour <= 6f)
            {
                Hour += .0001f;
            }

            if (HUDController.SecurityCamerasActive)
            {
                EnergyUsage += 2;
                PowerAmount = PowerAmount - 0.01f;
            }

            HUDController.UpdatePowerText((int)PowerAmount);
            HUDController.UpdateHourText((int)Hour);
            HUDController.UsageBarObj.UpdateUsageBar(EnergyUsage);

            yield return new WaitForEndOfFrame();
        }
    }
}
