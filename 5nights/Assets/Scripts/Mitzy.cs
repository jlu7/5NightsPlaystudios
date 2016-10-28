using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Random = System.Random;

public class Mitzy : Character
{
    private List<Map> MitzyMap = new List<Map>();
    public Map MitzyCurrentPos;

    public override void Initialize(HUD hudController, SecurityCamController securityCam)
    {
        HudController = hudController;
        SecurityCamController = securityCam;
        ThisActor = Actor.ActorType.MITZI;
        
        Map pos0 = new Map(0);
        Map pos1 = new Map(1);
        Map pos2 = new Map(2);
        Map pos4 = new Map(4);
        Map pos6 = new Map(6);

        pos0.ConnectingNodes.Add(pos1);
        pos0.ConnectingNodes.Add(pos2);

        pos1.ConnectingNodes.Add(pos0);
        pos1.ConnectingNodes.Add(pos2);
        pos1.ConnectingNodes.Add(pos4);

        pos2.ConnectingNodes.Add(pos0);
        pos2.ConnectingNodes.Add(pos1);

        pos4.ConnectingNodes.Add(pos1);
        pos4.ConnectingNodes.Add(pos6);

        pos6.ConnectingNodes.Add(pos4);

        MitzyMap.Add(pos0);
        MitzyMap.Add(pos1);
        MitzyMap.Add(pos2);
        MitzyMap.Add(pos4);
        MitzyMap.Add(pos6);

        MitzyCurrentPos = pos0;
    }

    public override IEnumerator Logic()
    {
        Active = true;
        float timeAlive = 0;
        while (true)
        {
            if (Active)
            {
                if (HudController.SecurityCamerasActive && SecurityCamController.ActiveCam == MitzyCurrentPos.Position)
                {
                    // Do nothing
                }
                else if (timeAlive > 10f)
                {
                    timeAlive = 0;
                    MitzyMove();
                }
            }
            timeAlive += 0.01f;
            yield return null;
        }
    }

    void MitzyMove()
    {
        int diceRoll = UnityEngine.Random.Range(0, 115);
        if (diceRoll > 100)
        {
            //Stand Still!
        }
        else
        {
            int targetNum = diceRoll % MitzyCurrentPos.ConnectingNodes.Count;
            if (HudController.SecurityCamerasActive && SecurityCamController.ActiveCam == MitzyCurrentPos.ConnectingNodes[targetNum].Position)
            {
                targetNum = (diceRoll + 1) % MitzyCurrentPos.ConnectingNodes.Count;
            }
            MitzyCurrentPos = MitzyCurrentPos.ConnectingNodes[targetNum];
            Debug.Log(MitzyCurrentPos.Position);
            SecurityCamController.MoveCharacter(ThisActor, MitzyCurrentPos.Position);
        }
    }
}
