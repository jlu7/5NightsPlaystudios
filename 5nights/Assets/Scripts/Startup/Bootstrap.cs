using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bootstrap : MonoBehaviour
{
    public GameObject ViewAnchorRef;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Startup());
    }

    IEnumerator Startup()
    {
        //Initiate The Singletons
        //Transaction<List<TcgCard>> t = new Transaction<List<TcgCard>>();
        yield return null;
        ViewController.GetInstance().Initialize(ViewAnchorRef.transform);
        SoundController.GetInstance().Initialize();
    }
}
