using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.Find("SecurityCamView").gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
