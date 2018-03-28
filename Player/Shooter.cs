using UnityEngine;
using UnityEngine.Networking;

public class Shooter : NetworkBehaviour {

	// Create parent object for storing bulletPrefab clones to keep hierarchy organized
	public Transform bulletParent;
	public GameObject bulletPrefab;
	public float shootRate = 3f;
	public float fShootPoint = 1f;

	private GameObject obj_theBullet; // store the bullet in a variable for accessing its components later
	private Rigidbody bulletRigidBody;
	private MagnusEffect magnusEffect;
	private InitialVelocity initialVelocity;
	private Bullet bullet;
	private Transform endOfGunTf;

	void Start () 
	{		
		endOfGunTf = 	gameObject.GetComponent<Transform>();
		magnusEffect = 	GetComponent<MagnusEffect> ();
	}

	[Command]
	public void CmdShoot(bool shootRight, float shootForce, float magnusConstant) 
	{
        // 	Instantiate a bullet with the prefab in the desired direction without rotation, so that
        // 	    the bullet's trajectory appropriate
        obj_theBullet = (GameObject)Instantiate (bulletPrefab, endOfGunTf.localPosition + (endOfGunTf.forward * fShootPoint), Quaternion.identity);

		// Play the cannon shot sound when the player fires because it is supposed to
//		AudioSource.PlayClipAtPoint (AudioManager.manager.cannonShot, gameObject.GetComponent<Transform>().position, 1.0f);

		// Get the rigidbody of [theBullet] SPECIFICALLY to modify it
		bulletRigidBody = obj_theBullet.GetComponent<Rigidbody> ();
		// Set [THIS] script's magnus var to [theBullet]'s MagnusEffect script for modifying!
		magnusEffect = obj_theBullet.GetComponent<MagnusEffect> ();

		// Add velocity to the left/right
		if (shootRight) 
		{			
			bulletRigidBody.velocity = (endOfGunTf.right * shootForce);
			magnusEffect.magnusLeft = true;
			magnusEffect.magnusConstant = magnusConstant;
		}
		else
		{			
			bulletRigidBody.velocity = (-endOfGunTf.right * shootForce);
			magnusEffect.magnusLeft = false;
			magnusEffect.magnusConstant = magnusConstant;
		}
		NetworkServer.Spawn (obj_theBullet); // Spawn the bullet on the Clients
	}
}