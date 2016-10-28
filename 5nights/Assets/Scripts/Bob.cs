using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Collections;
using Random = System.Random;

public class Bob : Character
{
    private List<Map> BobMap = new List<Map>();
    public Map BobCurrentPos;

    public override void Initialize(HUD hudController, SecurityCamController securityCam)
    {
        HudController = hudController;
        SecurityCamController = securityCam;
        ThisActor = Actor.ActorType.BOB;

        Map pos0 = new Map(0);
        Map pos2 = new Map(2);
        Map pos3 = new Map(3);
        Map pos5 = new Map(5);
        Map pos6 = new Map(6);

        pos0.ConnectingNodes.Add(pos3);
        pos0.ConnectingNodes.Add(pos2);

        pos2.ConnectingNodes.Add(pos0);
        pos2.ConnectingNodes.Add(pos3);

        pos3.ConnectingNodes.Add(pos0);
        pos3.ConnectingNodes.Add(pos2);
        pos3.ConnectingNodes.Add(pos5);

        pos5.ConnectingNodes.Add(pos3);
        pos5.ConnectingNodes.Add(pos6);

        pos6.ConnectingNodes.Add(pos5);

        BobMap.Add(pos0);
        BobMap.Add(pos2);
        BobMap.Add(pos3);
        BobMap.Add(pos5);
        BobMap.Add(pos6);

        BobCurrentPos = pos0;
    }

    public override IEnumerator Logic()
    {
        Active = true;
        float timeAlive = 0;
        float slowStart = 25;
        while (true)
        {
            if (Active)
            {
                if (HudController.SecurityCamerasActive && SecurityCamController.ActiveCam == BobCurrentPos.Position)
                {
                    // Do nothing
                }
                else if (timeAlive > 10f && slowStart < 0)
                {
                    timeAlive = 0;
                    BobMove();
                }

                if (slowStart > 0)
                {
                    slowStart -= .01f;
                }
            }
            timeAlive += 0.01f;
            yield return null;
        }
    }

    void BobMove()
    {
        int diceRoll = UnityEngine.Random.Range(0, 115);
        if (diceRoll > 100)
        {
            //Stand Still!
        }
        else
        {
            int targetNum = diceRoll % BobCurrentPos.ConnectingNodes.Count;
            if (HudController.SecurityCamerasActive && SecurityCamController.ActiveCam == BobCurrentPos.ConnectingNodes[targetNum].Position)
            {
                targetNum = (diceRoll + 1) % BobCurrentPos.ConnectingNodes.Count;
            }
            BobCurrentPos = BobCurrentPos.ConnectingNodes[targetNum];
            Debug.Log(BobCurrentPos.Position);
            SecurityCamController.MoveCharacter(ThisActor, BobCurrentPos.Position);
        }
    }
}
