using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	public Camera playerCamera;

	// Update is called once per frame
	void Update () {
		transform.LookAt (playerCamera.transform);
	}
}
