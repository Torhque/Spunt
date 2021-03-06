﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour 
{
	[SerializeField]
	Behaviour[] componentsToDisable;

	Camera sceneCamera;

	void Start () 
	{
		if (!isLocalPlayer) 
		{
			DisableComponents ();
		} 
		else 
		{
			sceneCamera = Camera.main;
			if (sceneCamera != null) {
				sceneCamera.gameObject.SetActive (false);
			}
		}
	}

	void DisableComponents() {

		for (int i = 0; i < componentsToDisable.Length; i++) {

			componentsToDisable [i].enabled = false;
		}
	}

	void OnDisable() {

		if (sceneCamera != null) {
			sceneCamera.gameObject.SetActive (true);
		}
	}
}
