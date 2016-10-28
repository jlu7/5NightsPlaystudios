using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour 
{
	SecurityCamController SecurityCameras;
    HUD HUDController;
    private List<Character> Characters = new List<Character>(); 
    private List<string> RandomSounds = new List<string>(); 

    public float PowerAmount = 100;

	// Use this for initialization
	public void Initialize(int level) 
    {
		GameObject securityCamsPrefab = Resources.Load("Prefabs/Views/SecurityCameras") as GameObject;
		SecurityCameras = GameObject.Instantiate<GameObject>(securityCamsPrefab).GetComponent<SecurityCamController>();
		SecurityCameras.transform.parent = this.transform;
		SecurityCameras.Initialize();
        Characters.Add(this.transform.Find("Mitzy").GetComponent<Mitzy>());
        Characters.Add(this.transform.Find("Bob").GetComponent<Bob>());

        RandomSounds.Add("Growl");
        RandomSounds.Add("Jackpot");
        RandomSounds.Add("ShatteredGlass");
        RandomSounds.Add("StoneColdGlass");

	    if (level == 1)
	    {
	        HUDController = transform.Find("HUD").GetComponent<HUD>();
            HUDController.Initialize(1, SecurityCameras);
            foreach (Character chara in Characters)
	        {
	            chara.Initialize(HUDController, SecurityCameras);
	        }
	    }

        SoundController.GetInstance().Play("A_C", true);

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
        float HeartBeatTimer = 10f;
        float randomSoundInterval = 50f;

        foreach (Character chara in Characters)
        {
            StartCoroutine(chara.Logic());
        }

        while (true)
        {
            int EnergyUsage = 0;

            if (Hour <= 6f)
            {
                Hour += .0003f;
            }
            else
            {
                break;
            }

            if (HeartBeatTimer < 0)
            {
                HeartBeatTimer = 10f;
                SoundController.GetInstance().Play("10%Power");
            }

            if (HUDController.SecurityCamerasActive)
            {
                EnergyUsage += 2;
                if (PowerAmount > 0)
                {
                    PowerAmount = PowerAmount - 0.01f;
                }
            }

            if (HUDController.LeftProtection || HUDController.RightProtection)
            {
                EnergyUsage += 2;
                if (PowerAmount > 0)
                {
                    PowerAmount = PowerAmount - 0.01f;
                }
            }

            HUDController.UpdatePowerText((int)PowerAmount);

            if (PowerAmount <= 0)
            {
                HUDController.UpdatePowerText(0);                
                HUDController.LockOut();
            }

            if (randomSoundInterval < 0)
            {
                PlayRandomSound();
                randomSoundInterval = Random.Range(50, 100);
            }

            HUDController.UpdateHourText((int)Hour);
            HUDController.UsageBarObj.UpdateUsageBar(EnergyUsage);

            HeartBeatTimer -= 0.1f;
            randomSoundInterval -= 0.01f;

            yield return new WaitForEndOfFrame();
        }

        foreach (Character chara in Characters)
        {
            chara.Active = false;
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("5nights");
    }

    void PlayRandomSound()
    {
        SoundController.GetInstance().Play(RandomSounds[Random.Range(0, RandomSounds.Count - 1)]);
    }
}
