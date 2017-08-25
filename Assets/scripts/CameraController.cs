using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject aim;
	public GameObject aimLine;

	private Vector3 offset;
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	void Start ()
	{
		offset = transform.position - aim.transform.position;
		aim.transform.position = player.transform.position;
		aimLine.transform.position = aim.transform.position;
		Screen.lockCursor = true;
	}

	void LateUpdate ()
	{
		aim.transform.position = player.transform.position;
			float h = horizontalSpeed * Input.GetAxis("Mouse X");
			float v = verticalSpeed * Input.GetAxis("Mouse Y");
			aim.transform.Rotate(0, h, 0);
	}
}