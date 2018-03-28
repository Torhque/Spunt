using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

//	[HideInInspector] public TankData owner;
	public float shellLifespan;
	public int bulletDamage;

	private Tag collidedTag;
	private NetHealth targetHealth;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, shellLifespan);
	}

	// The shells are able to hit and destroy enemy tanks.
	void OnCollisionEnter (Collision hitInfo) 
	{
		// Grab the target's Tag
		collidedTag = hitInfo.gameObject.GetComponent<Tag> ();

		//	If the object the bullet is colliding with has a Tag
		if (collidedTag != null)
        {
			// And if the object is a player
			if (collidedTag.isPlayer == true)
            {
				// Grab the target's health component for modifying health values
				targetHealth = hitInfo.gameObject.GetComponent<NetHealth> (); 				

				// Grab the owner's transform for playing the soundclip on the player
//				Transform ownerTransform = owner.GetComponent<Transform> ();

				if (targetHealth != null) {
					// Remove the appropriate amount of health from the target tank
					targetHealth.TakeDamage (bulletDamage);

					// Play the shell impact sound
//					AudioSource.PlayClipAtPoint (AudioManager.instance.shellHit, ownerTransform.position, AudioManager.instance.sfxVolume);

					// If the target is killed
//						if (targetHealth.IsDead) {
//							// Give the tank that killed it points
//							owner.score += targetTankData.bounty;
//
//							// Play a sound when the tank dies
//							AudioSource.PlayClipAtPoint (AudioManager.instance.tankDeath, ownerTransform.position, AudioManager.instance.sfxVolume);
//
//							// Check the owner's tag
//							objectTag = owner.gameObject.GetComponent<Tag> ();
//
//							// If the owner is Player One
//							if (collidedTag.isPlayerOne == true) {
//								// Update Player One score
//							GameManager.instance.playerOneScore += targetTankData.bounty;
//							}
//							// If the owner is Player One
//							if (collidedTag.isPlayerTwo == true) {
//								// Update Player Two score
//								GameManager.instance.playerTwoScore += targetTankData.bounty;
//							}
//						}
					} else {
						Debug.Log ("Player Object does not have a Health script attached.");
					}
				Destroy (gameObject);
				}
		}
//		GameManager.instance.CheckHighScore ();
	}
}
