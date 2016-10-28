using UnityEngine;
using System.Collections;
using System.Linq;

public class SecurityCamView : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
	}

	public void AddActor(Actor.ActorType actorType)
	{
		transform.Find("ActorHolder").GetComponentsInChildren<Actor>(true).First(x => x.ActiveActor == actorType).gameObject.SetActive(true);
	}

	public void RemoveActor(Actor.ActorType actorType)
	{
		transform.Find("ActorHolder").GetComponentsInChildren<Actor>(true).First(x => x.ActiveActor == actorType).gameObject.SetActive(false);
	}
}
	
