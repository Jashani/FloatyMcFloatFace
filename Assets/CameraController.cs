﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Rigidbody2D floaty;

	private Vector3 velocity = Vector3.zero;
	private float highestY = 0;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		Vector3 targetPosition = floaty.transform.TransformPoint (new Vector3 (0f, 1.5f, -10f));

		if (highestY < targetPosition.y)
			highestY = targetPosition.y;
		else
			targetPosition = new Vector3 (targetPosition.x, highestY, targetPosition.z);
		
		transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, 0.1f);
	}
}
