using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour {

	public float magnusConstant = 1f;
	public bool magnusLeft;

	private Rigidbody rb;

	void Start() 
	{
		rb = this.GetComponent<Rigidbody> ();
	}

	void FixedUpdate() 
	{
		if (magnusLeft) 
		{
			rb.AddForce (magnusConstant * Vector3.Cross (rb.angularVelocity, rb.velocity));
		} 
		else 
		{
			rb.AddForce (magnusConstant * Vector3.Cross (-rb.angularVelocity, rb.velocity));
		}
	}
}
