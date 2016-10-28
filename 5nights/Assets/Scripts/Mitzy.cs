using UnityEngine;
using System.Collections;

public class Mitzy : Character 
{
    public override void Initialize(HUD hudController, SecurityCamController securityCam)
    {
        HudController = hudController;
        SecurityCamController = securityCam;
        ThisActor = Actor.ActorType.MITZI;
    }

    public override IEnumerator Logic()
    {
        Active = true;
        float timeAlive = 0;
        Debug.Log("DO STUFF");
        while (true)
        {
            if (Active)
            {
                if (HudController.SecurityCamerasActive && SecurityCamController.ActiveCam == currentPosition)
                {
                    // Do nothing
                }
                else
                {
                    SecurityCamController.MoveCharacter(Actor.ActorType.MITZI, 4);
                }
            }
            timeAlive += 0.01f;
            Debug.Log(timeAlive);
            yield return null;
        }
    }

    void MitzyMove()
    {
        
    }
}
