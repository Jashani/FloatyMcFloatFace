using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Rigidbody2D floaty;

	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		Vector3 targetPosition = floaty.transform.TransformPoint (new Vector3 (0f, 1.5f, -10f));
		transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, 0.1f);
	}
}
