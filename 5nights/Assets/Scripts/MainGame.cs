using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGame : MonoBehaviour {

	SecurityCamController SecurityCameras;

	// Use this for initialization
	void Start () {
		GameObject securityCamsPrefab = Resources.Load("Prefabs/Views/SecurityCameras") as GameObject;
		SecurityCameras = GameObject.Instantiate<GameObject>(securityCamsPrefab).GetComponent<SecurityCamController>();
		SecurityCameras.transform.parent = this.transform;
		SecurityCameras.SetSecurityCam(0);
		StartCoroutine(ChangeCam());
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

	// Update is called once per frame
	void Update () {
	
	}
}
