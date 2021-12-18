﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public int playerIndex;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float v = Input.GetAxisRaw("Vertical" + playerIndex);
		
		Move(0, v);
		Turning();
		Animating(0, v);
	}

	void Move(float h, float v)
	{
		/*movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);*/

		playerRigidbody.MovePosition (transform.position + (transform.forward * v * speed * Time.deltaTime));

	}

	void Turning()
	{
		/*Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}*/
		float h = Input.GetAxisRaw("Horizontal" + playerIndex);
		transform.Rotate(Vector3.up, h);
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("IsWalking", walking);
	}
}
