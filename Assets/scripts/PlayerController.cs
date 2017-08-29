using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text winText;
	public Vector3 aimRotation;
	public Vector3 shotStart;
	private Rigidbody rb;
	public GameObject aim;
	public GameObject aimLine;
	public GameObject gameLogic;
	public float mouseInput;
	public float mouseEndPoint;
	public bool mouseHeld;
	public GameLogic gameLogicScript;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		aimLine.SetActive (false);
		mouseHeld = false;
		speed = 10;
		winText.gameObject.SetActive(true);
		gameLogicScript = (GameLogic)FindObjectOfType(typeof(GameLogic));
	}

	void FixedUpdate ()
	{
		makeShot ();
    }

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Golf Hole"))
		{
			gameLogicScript.loadNextLevel ();
		}
		if (other.gameObject.CompareTag("outOfBounds"))
			{
				transform.position = shotStart;

			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY |
				RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
			}
	}

	void makeShot (){
		if (rb.velocity.magnitude < 0.15) {
			rb.velocity = new Vector3 (0, 0, 0);

			if (Input.GetMouseButtonDown(0)) {
				if (mouseHeld) {
					aimLine.SetActive (true);
					mouseEndPoint = Input.mousePosition.y;
					float powerAmount = (mouseEndPoint - mouseInput);
					if (powerAmount <= 150 && powerAmount >=0) {
						aimLine.transform.localScale = new Vector3 (75, 30, powerAmount);
					}
				} else {
					mouseInput = Input.mousePosition.y;
					mouseHeld = true;
				}
			}

			if (mouseHeld) {
				aimLine.SetActive (true);
				mouseEndPoint = Input.mousePosition.y;
				float powerAmount = (mouseEndPoint - mouseInput);
				if (powerAmount <= 150 && powerAmount >=0) {
					aimLine.transform.localScale = new Vector3 (75, 30, powerAmount);
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				rb.constraints = RigidbodyConstraints.None;
				speed = ((Input.mousePosition.y - mouseInput) * 10 ); 
				rb.transform.rotation = aim.transform.rotation;
				if (speed > 1500) {
					speed = 1500;
				}
				if(speed < 0){
					speed = 0;
				}
				shotStart = rb.transform.position;
				rb.AddRelativeForce (Vector3.forward * speed * 2);
				aimLine.SetActive (false);
				mouseHeld = false;
				speed = 10;
				aimLine.transform.localScale = new Vector3 (75, 30, 70);
			}
		}
	}



}


