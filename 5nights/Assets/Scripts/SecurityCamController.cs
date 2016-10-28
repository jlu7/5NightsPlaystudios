﻿using UnityEngine;
using System.Collections;

public class SecurityCamController : MonoBehaviour
{

	public int ActiveCam;
	public GameObject[] SecurityCameraArr; 

	// Use this for initialization
	void Awake ()
	{
		foreach(GameObject cam in SecurityCameraArr)
		{
			cam.SetActive(false);
		}

	
	}

	public void SetSecurityCam(int cameraNumber)
	{
		if(null != SecurityCameraArr[ActiveCam])
			SecurityCameraArr[ActiveCam].SetActive(false);
		ActiveCam = cameraNumber;
		SecurityCameraArr[ActiveCam].SetActive(true);
	}
}
