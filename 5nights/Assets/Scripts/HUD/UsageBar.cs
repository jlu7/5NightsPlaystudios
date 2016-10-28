using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class UsageBar : MonoBehaviour
{
    private List<GameObject> EnergyBarList; 

    public void UpdateUsageBar(int amount)
    {
        foreach (GameObject GO in EnergyBarList)
        {
            Destroy(GO);
        }

        EnergyBarList.Clear();
        Debug.Log(amount);

        for (int i = 0; i < amount; i++)
        {
            GameObject tmp = Instantiate(Resources.Load<GameObject>("Prefabs/UI/EnergyBar"));
            tmp.transform.parent = this.transform;
            EnergyBarList.Add(tmp);
        }
    }
}