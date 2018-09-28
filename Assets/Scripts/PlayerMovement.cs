using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Animator animator;
	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    public string axisHorizontal = "Horizontal_P1";
    public string axisVertical = "Vertical_P1";
    public string jumpButton = "Jump_P1";
    public string useButton = "Use_P1";
    public string pickUpButton = "PickUp_P1";


    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw(axisHorizontal) * runSpeed;

        animator.SetFloat("Vertical Speed", controller.getVelocityY());
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown(jumpButton))
		{
			jump = true;
            animator.SetBool("IsJumping", true);
		}

        if (Input.GetAxisRaw(axisVertical) < 0) 
		{
			crouch = true;
		} else if (Input.GetAxisRaw(axisVertical) > -0.1)
		{
			crouch = false;
		}

	}

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching) {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}