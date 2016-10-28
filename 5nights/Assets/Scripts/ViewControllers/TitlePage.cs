using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitlePage : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    transform.Find("Title/Button").GetComponent<Button>().onClick.AddListener(
            () => StartGame());
	}

    void StartGame()
    {
        GameObject mainGame = Instantiate(Resources.Load<GameObject>("Prefabs/Views/MainGame"));
        mainGame.GetComponent<MainGame>().Initialize(1);
        ViewController.GetInstance().PushView(mainGame);
    }
}
