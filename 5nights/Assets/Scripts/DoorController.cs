using UnityEngine;
using System.Collections;

[System.Serializable]
public class DoorController : MonoBehaviour {
	
	public int doorID;
	public float xPOS;
	public float yOpenPOS;
	public float yClosePOS;

	protected bool is_Open;
	protected float doorSpeed;

	protected Transform openPos, closePos;

	protected DoorController instance;

	void Awake()
	{

//		xPOS = -4.5f;
//
//		yOpenPOS = 5.0f;
//
//		yClosePOS = 3.0f;

		is_Open = true;

		doorSpeed = 5.0f;

		openPos.localPosition.Set (xPOS, yOpenPOS, 0);

		closePos.localPosition.Set (xPOS, yClosePOS, 0);

		this.gameObject.GetComponent<Transform> ().localPosition.Set 
		(
			openPos.localPosition.x, 
			openPos.localPosition.y, 
			openPos.localPosition.z
		);
	}

	void Start () 
	{
		instance = this;
	}
	
	void Update () 
	{
	
	}

	IEnumerator openTheDoor() 
	{
		// open is > close

		float curPos = yClosePOS;

		do 
		{
			curPos = doorSpeed;

			this.gameObject.GetComponent<Transform> ().localPosition.Set 
			(
				openPos.localPosition.x, 
				curPos, 
				openPos.localPosition.z
			);

		} while (curPos > );

		is_Open = true;

		yield return null;
	}

	IEnumerator closeTheDoor()
	{
		// close is < open

		float curPos = yOpenPOS;
		
		this.gameObject.GetComponent<Transform> ().localPosition.Set 
		(
			closePos.localPosition.x, 
			closePos.localPosition.y, 
			closePos.localPosition.z
		);

		is_Open = false;

		yield return null;
	}

	public bool isOpen
	{
		get
		{ return this.is_Open; }
	}

	public DoorController getInstance
	{
		get { return instance; }
	}
}
