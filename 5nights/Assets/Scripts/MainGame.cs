using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour 
{
	SecurityCamController SecurityCameras;


	// Use this for initialization
	public void Initialize(int level) 
    {
		GameObject securityCamsPrefab = Resources.Load("Prefabs/Views/SecurityCameras") as GameObject;
		SecurityCameras = GameObject.Instantiate<GameObject>(securityCamsPrefab).GetComponent<SecurityCamController>();
		SecurityCameras.transform.parent = this.transform;
		SecurityCameras.SetSecurityCam(0);
		//StartCoroutine(ChangeCam());

	    if (level == 1)
	    {
            transform.Find("HUD").GetComponent<HUD>().Initialize(1, SecurityCameras);
	    }
		//SecurityCameras.transform.Find("SecurityCamView").gameObject.SetActive(true);
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
}
