using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public bool Active = false;
    public int currentPosition = 0;

    protected Actor.ActorType ThisActor;
    protected HUD HudController;
    protected SecurityCamController SecurityCamController;


    public abstract void Initialize(HUD hudController, SecurityCamController securityCam);

    public abstract IEnumerator Logic();
}
