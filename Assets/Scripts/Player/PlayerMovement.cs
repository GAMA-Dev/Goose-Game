using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Animator animator;
	public CharacterController2D controller;
    public Transform equipslot;

    public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    public int playerName = 1;
    public string axisHorizontal = "Horizontal_P1";
    public string axisVertical = "Vertical_P1";
    public string jumpButton = "Jump_P1";
    public string useButton = "Use_P1";
    public string pickUpButton = "Pickup_P1";



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

        if (Input.GetButtonDown(pickUpButton)) 
        {
            if (transform.Find("Equipment Slot").childCount == 0) {
                Pickup();
            }
        }
        if (Input.GetButtonDown(useButton)) {
            if (equipslot.childCount == 1) {
                IUseable equipment = equipslot.GetComponentInChildren<IUseable>();
                if (equipment != null) {
                    equipment.Use();
                }
            }
        }
    }

    private void Pickup() {
        //Only check this layer for equipment triggers
        LayerMask equipable_mask = LayerMask.GetMask("Equip Trigger");
        ContactFilter2D equip_filter = new ContactFilter2D {
            useTriggers = true
        };
        equip_filter.SetLayerMask(equipable_mask);
        Collider2D[] results = new Collider2D[1];
        //just using the circle collider for pickup collision detection for now
        //to avoid having to iterate over all attached colliders and check each
        Collider2D collider = gameObject.GetComponent<CircleCollider2D>();
        //check if player collider is touching another collider in filter
        //results should only be null or have equipable objects as they will all be on own layer
        if (collider.OverlapCollider(equip_filter, results) > 0) {
            if (results != null) {
                //call Equip() on the first object in results
                IEquipable equipment = results[0].GetComponentInParent<IEquipable>();
                equipment.Equip(transform.Find("Equipment Slot"));
            }
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

    //we only need to check for equipment colliders when the button is actually pressed,
    //we can avoid unneeded checks by calling collision detection logic from the controller input detection
    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if(col.gameObject.tag == "Pickup" && Input.GetButtonDown(pickUpButton) && canPickUp)
    //    {
    //        Debug.Log("Picked Up!");
    //        col.gameObject.GetComponentInParent<Pick_Up_Script>().equipSlot = transform.GetChild(2).gameObject;
    //        col.gameObject.GetComponentInParent<Pick_Up_Script>().Equip();
    //        canPickUp = false;
    //    }
    //}
}
