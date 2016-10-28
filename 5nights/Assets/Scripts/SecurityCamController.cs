using UnityEngine;
using System.Collections;

public class SecurityCamController : MonoBehaviour
{
	public delegate void CameraChange(int activeCamera);
	public static event CameraChange ActiveCameraChanged = (int ac) => { };

	public static SecurityCamController SinglePoop;


	public int ActiveCam;
	public GameObject[] SecurityCameraArr; 

	// Use this for initialization
	void Awake ()
	{
		SinglePoop = this;
		foreach(GameObject cam in SecurityCameraArr)
		{
			cam.SetActive(false);
		}
	}

    public void Initialize()
    {
        SetSecurityCam(0);
        SecurityCameraArr[0].GetComponent<SecurityCamView>().AddActor(Actor.ActorType.MITZI);
        SecurityCameraArr[0].GetComponent<SecurityCamView>().AddActor(Actor.ActorType.BOB);
    }

	public void SetSecurityCam(int cameraNumber)
	{
        SoundController.GetInstance().Play("StaticCameraChange");
        
	    if (null != SecurityCameraArr[ActiveCam])
	    {
            SecurityCameraArr[ActiveCam].SetActive(false);
	    }

		ActiveCam = cameraNumber;
		SecurityCameraArr[ActiveCam].SetActive(true);
		ActiveCameraChanged(cameraNumber);
	}

    public void MoveCharacter(Actor.ActorType actor, int toPosition)
    {
        foreach (GameObject camera in SecurityCameraArr)
        {
            camera.GetComponent<SecurityCamView>().RemoveActor(actor);
        }

        if (toPosition != 6)
        {
            SecurityCameraArr[toPosition].GetComponent<SecurityCamView>().AddActor(actor);
        }
    }
}
