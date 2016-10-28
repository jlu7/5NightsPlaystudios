using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour 
{
	public enum ActorType
	{
		MITZI,
		BOB
	}

	public ActorType ActiveActor;

	// Use this for initialization
	void Start () 
    {
	}
}
