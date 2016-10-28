﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {

	public GameObject[] RoomSprites;
	int ActiveRoom = 0;


	// Use this for initialization
	void Start ()
	{
		RoomSprites[ActiveRoom].GetComponent<Image>().color = Color.green;
		SecurityCamController.ActiveCameraChanged += (int activeCam) =>
		{
			RoomSprites[ActiveRoom].GetComponent<Image>().color = Color.white;
			ActiveRoom = activeCam;
			RoomSprites[ActiveRoom].GetComponent<Image>().color = Color.green;
		};
		for(int i = 0; i < RoomSprites.Length; i++)
		{
			int count = i;
			RoomSprites[i].GetComponent<Button>().onClick.AddListener(() => SecurityCamController.SinglePoop.SetSecurityCam(count));
		}
	}



}