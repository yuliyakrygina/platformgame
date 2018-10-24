using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed; //we see it in Unity 
	private Rigidbody2D MyRigidBody;

	public float JumpSpeed;

	public Transform GroundCheck;
	public float GroundCheckRadius;
	public LayerMask WhatIsGround; //what are we using

	public bool IsGrounded; //true or false statement

	private Animator MyAnim;

	void Start () {
		MyRigidBody = GetComponent<Rigidbody2D>(); //get component from inspector, attach rigidbody, will know its player
		MyAnim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {


		IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);


		if(Input.GetAxisRaw ("Horizontal") > 0f) //horizontal movement, calling input 
		{
			MyRigidBody.velocity = new Vector3(MoveSpeed, MyRigidBody.velocity.y, 0f); // 0f, zero float
			transform.localScale = new Vector3(1f, 1f, 1f); //stay when going forward
		}
		else if(Input.GetAxisRaw("Horizontal") < 0f) //horizontal movement, calling input 
		{
			MyRigidBody.velocity = new Vector3(-MoveSpeed, MyRigidBody.velocity.y, 0f); // 0f, zero float
			transform.localScale = new Vector3(-1f, 1f, 1f); //turn when going back
		}
		else
		{
			MyRigidBody.velocity = new Vector3(0f, MyRigidBody.velocity.y, 0f);
		}

		if(Input.GetButtonDown("Jump") && IsGrounded)
		{
			MyRigidBody.velocity = new Vector3(MyRigidBody.velocity.x, JumpSpeed, 0f);
		}

		MyAnim.SetFloat("Speed", Mathf.Abs(MyRigidBody.velocity.x)); //math absolute, getting absolute number, any minus number as a positive number. 
		MyAnim.SetBool("Grounded", IsGrounded);

	}
}
