using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class UsageBar : MonoBehaviour
{
    private List<GameObject> EnergyBarList = new List<GameObject>(); 

    public void UpdateUsageBar(int amount)
    {
        foreach (GameObject GO in EnergyBarList)
        {
            Destroy(GO);
        }

        EnergyBarList.Clear();

        for (int i = 0; i < amount; i++)
        {
            GameObject tmp = Instantiate(Resources.Load<GameObject>("Prefabs/UI/EnergyBar"));
            tmp.transform.SetParent(this.transform);
            tmp.GetComponent<RectTransform>().localPosition = new Vector3((i * 25), 0);
            EnergyBarList.Add(tmp);
        }
    }
}