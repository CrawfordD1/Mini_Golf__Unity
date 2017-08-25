using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text winText;
	public Vector3 aimRotation;
	private Rigidbody rb;
	public GameObject aim;
	public GameObject aimLine;
	public float mouseInput;
	public float mouseEndPoint;
	public bool mouseHeld;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		aimLine.SetActive (false);
		mouseHeld = false;
		speed = 10;
	}

	void FixedUpdate ()
	{
		if (rb.velocity.magnitude < 0.3) {
			aimLine.SetActive (true);
			rb.velocity = new Vector3 (0, 0, 0);

			if (Input.GetMouseButtonDown(0)) {
				if (mouseHeld) {
				} else {
					rb.transform.rotation = aim.transform.rotation;
					mouseInput = Input.mousePosition.y;
					mouseHeld = true;
				}
			}

			if (mouseHeld) {
				mouseEndPoint = Input.mousePosition.y;
				float powerAmount = (mouseEndPoint - mouseInput);
				if (powerAmount <= 150 && powerAmount >=0) {
					aimLine.transform.localScale = new Vector3 (75, 30, powerAmount);
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				speed = ((Input.mousePosition.y - mouseInput) * 10 ); 
				if (speed > 1500) {
					speed = 1500;
				}
				if(speed < 0){
					speed = 0;
				}

				rb.AddRelativeForce (Vector3.forward * speed);
				aimLine.SetActive (false);
				mouseHeld = false;
				speed = 10;
				aimLine.transform.localScale = new Vector3 (75, 30, 70);
			}
		}

		if (Input.GetKeyDown ("space")) {
			rb.AddForce (Vector3.up * 400);
		}
 }

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Golf Hole"))
		{
			winText.gameObject.SetActive(true);
//			yield WaitForSeconds(3.0);
			int scene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}
	}





}


