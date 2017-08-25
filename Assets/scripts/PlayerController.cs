using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text winText;
	private Rigidbody rb;
	public GameObject aim;
	public GameObject aimLine;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		aimLine.SetActive (false);
	}

	void FixedUpdate ()
	{
		if (rb.velocity.magnitude < 0.3) {
			aimLine.SetActive (true);
			rb.velocity = new Vector3 (0, 0, 0);

			if (Input.GetKeyDown ("up")) {
				rb.transform.rotation = aim.transform.rotation;
				rb.AddRelativeForce (Vector3.forward * speed);
				aimLine.SetActive (false);
			}
		}

		if (Input.GetKeyDown ("space")) {
			rb.AddForce (Vector3.up * speed/2);
		}
 }
		



	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.CompareTag("Golf Hole"))
		{
			winText.gameObject.SetActive(true);
//			yield WaitForSeconds(3.0);
			int scene = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}
	}




}


