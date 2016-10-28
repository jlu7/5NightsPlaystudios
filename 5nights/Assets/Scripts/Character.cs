using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public bool Active = false;

    protected Actor.ActorType ThisActor;
    protected HUD HudController;
    protected SecurityCamController SecurityCamController;

    public abstract void Initialize(HUD hudController, SecurityCamController securityCam);

    public abstract IEnumerator Logic();

    public class Map
    {
        public int Position;
        public List<Map> ConnectingNodes = new List<Map>();

        public Map(int position)
        {
            Position = position;
        }
    }
}
