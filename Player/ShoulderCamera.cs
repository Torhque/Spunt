using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// Makes the camera follow the player

public class ShoulderCamera : MonoBehaviour {

	#region Variables
	public Transform playerTf;	// Target to follow (player)
	public Transform cameraTf;	// Transform of the camera

	public Vector3 offset;			// Offset from the player
	public float zoomSpeed = 4f;	// How quickly we zoom
	public float minZoom = 5f;		// Min zoom amount
	public float maxZoom = 15f;		// Max zoom amount

	public float pitch = 2f;		// Pitch up the camera to look at head
	public float horizOffset = 1f;

	public float yawSpeed = 100f;	// How quickly we rotate
	public float pitchSpeed = 100f;
	public bool LockCursor = true;

	// In these variables we store input from Update
	private float currentZoom = 10f;
	private float currentYaw = 0f;
	private float currentPitch = 0f;
	private bool m_cursorIsLocked = true;
	#endregion
    	
	void Update ()
	{
		// [Not used] Adjust our zoom based on the scrollwheel
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

		// Adjust our camera's rotation around the player
		currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
		currentPitch -= Input.GetAxis ("Mouse Y") * pitchSpeed * Time.deltaTime;
		currentPitch = Mathf.Clamp (currentPitch, 0, 80);
	}

	void LateUpdate ()
	{
		// Set our cameras position based on offset and zoom
		if (playerTf != null) {
			transform.position = playerTf.position - offset * currentZoom;

			// Look at the player's head
			Vector3 offsetPoint = playerTf.position + (Vector3.left * horizOffset);

			transform.LookAt(offsetPoint + (Vector3.up * pitch));

			// Rotate around the player
			transform.RotateAround(playerTf.position, Vector3.up, currentYaw);

            // Pitch around the player
			transform.RotateAround (playerTf.position, transform.right, currentPitch);

			CharacterRotation (playerTf); // Update player rotation

			UpdateCursorLock(); // Lock cursor to the screen
		}
	}

	public void CharacterRotation(Transform character)
    {
		character.localRotation = cameraTf.rotation;
	}

	#region Unity Standard
	public void SetCursorLock(bool value) {
		
		LockCursor = value;
		if (!LockCursor) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	public void UpdateCursorLock() {
		
		if (LockCursor) {
			InternalLockUpdate();
		}
	}

	private void InternalLockUpdate() {
		
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			m_cursorIsLocked = false;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			m_cursorIsLocked = true;
		}

		if (m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (!m_cursorIsLocked)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
	#endregion
}