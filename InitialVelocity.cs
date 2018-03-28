using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InitialVelocity : MonoBehaviour {

	public Vector3 initialW; // Vector for manipulating angularVelocity
	public Transform playerTf;
	public float bulletSpeedVector;

	private Rigidbody rb;

	void Awake () 
	{		
		rb = GetComponent<Rigidbody> ();
		playerTf = GetComponent<Transform> ();
		rb.angularVelocity = initialW;
	}
}
