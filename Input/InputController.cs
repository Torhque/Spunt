using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public Shooter shooter;
	public bool isLoaded = true; // Can be overridden in Inspector
	public float fireRate;
	public float shootForce;
	public float magnusConstant;

	private bool shootRight;
	private float rightShotTime = 0f;
	private float leftShotTime = 0f;
	private Billboard billboard;
	private Camera playerCam;

	void Start () 
	{
		// Load the Shooter object at Start so that it can be used
		shooter = gameObject.GetComponent<Shooter> ();
		playerCam = GetComponentInChildren<Camera> ();
		billboard = GetComponentInChildren<Billboard> ();
		billboard.playerCamera = playerCam;
	}
	
	void Update ()
	{		
		// If the RIGHT cannon's cooldown is finished
		if (Time.time >= rightShotTime) 
		{
			if (Input.GetKeyUp (KeyCode.Mouse1)) 
			{
				shootRight = true;
				// Once the RIGHT mouse button is released, fire at the associated amount of force so there is variety in charge
				if (isLoaded == true) 
				{
					shooter.CmdShoot (shootRight, shootForce, magnusConstant);
//					isLoaded = false; // Bottomless clip will commented out
					rightShotTime = Time.time + shooter.shootRate;
				} 
				else if (isLoaded == false) 
				{
					// Play the dry fire sound if the gun isn't loaded
					// AudioSource.PlayClipAtPoint (AudioManager.manager.dryShot, gameObject.GetComponent<Transform>().position, 1.0f);
					Debug.Log ("Empty chamber!");
				}
			}
			else if (Input.GetKeyUp (KeyCode.Mouse1)) 
			{ 
				if (isLoaded == false) 
				{
					// Play the reload sound when the player reloads
					// AudioSource.PlayClipAtPoint (AudioManager.manager.reload, gameObject.GetComponent<Transform>().position, 1.0f);
				}				
				isLoaded = true;
			} 
		}
        // // If the LEFT cannon's cooldown is finished
        if (Time.time >= leftShotTime) 
		{
			if (Input.GetKeyUp (KeyCode.Mouse0)) 
			{
				shootRight = false;
				if (isLoaded == true) 
				{
					shooter.CmdShoot (shootRight, shootForce, magnusConstant);
                    //isLoaded = false; // Bottomless clip will commented out
                    leftShotTime = Time.time + shooter.shootRate;
				} 
				else if (isLoaded == false) 
				{
					// Play the dry fire sound is the gun isn't loaded
					// AudioSource.PlayClipAtPoint (AudioManager.manager.dryShot, gameObject.GetComponent<Transform>().position, 1.0f);
					Debug.Log ("Empty chamber!");
				}
			} 
			else if (Input.GetKeyUp (KeyCode.Mouse0)) 
			{ 
				if (isLoaded == false) 
				{
					// Play the reload sound when the player reloads
					// AudioSource.PlayClipAtPoint (AudioManager.manager.reload, gameObject.GetComponent<Transform>().position, 1.0f);
				}				
				isLoaded = true;
			}
		}
	}
}
