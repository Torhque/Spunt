using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	public float speed = 10f;
	public float jumpForce = 8f;
	public float gravity = 30f;
	public Transform cameraTf;
	public Transform playerTf;
	public CharacterController controller;
	private Vector3 moveDir = Vector3.zero;

	void Start () 
	{
		playerTf = GetComponent<Transform> ();
		cameraTf = GetComponent<Transform> ();
		controller = GetComponent<CharacterController> ();
	}

	void Update() {

		if (controller.isGrounded) {
			
			moveDir = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDir = cameraTf.TransformDirection (moveDir);
			moveDir *= speed;

			if (Input.GetButtonDown ("Jump")) {

				moveDir.y = jumpForce;
			}
		}

		moveDir.y -= gravity * Time.deltaTime;
		controller.Move (moveDir * Time.deltaTime);
	}
}
