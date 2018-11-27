using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Animator animator;
	public CharacterController2D controller;
    public Transform equipslot;

    public float runSpeed = 40f;
    public float throwStregth = 100f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
    public int playerName = 1;
    public string axisHorizontal = "Horizontal_P1";
    public string axisVertical = "Vertical_P1";
    public string jumpButton = "Jump_P1";
    public string useButton = "Use_P1";
    public string pickUpButton = "PickUp_P1";



    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw(axisHorizontal) * runSpeed;

		if (Input.GetButtonDown(jumpButton))
		{
			jump = true;
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
            else if(Mathf.Abs(horizontalMove) > 0) {
                Throw();
            }
            else {
                Drop();
            }
        }
        if (Input.GetButtonDown(useButton) && transform.GetChild(4).GetChild(0).GetComponentInChildren<AmmoCount>().count >= 0) {
            if (equipslot.childCount == 1) {
                IUseable equipment = equipslot.GetComponentInChildren<IUseable>();
                if (equipment != null) {
                    equipment.Use();
                }
            }
        }
        if(transform.GetChild(4).GetChild(0))
        {
            if(transform.GetChild(4).GetChild(0).GetComponentInChildren<AmmoCount>().count < 0 && Input.GetButtonDown(useButton))
            {
                transform.GetChild(4).GetChild(0).GetComponentInChildren<AmmoCount>().reload();
            }
        }
    }



    private void Pickup() {
        Debug.Log("Pickup Called");
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

    private void Throw() {
        //drop code
        Debug.Log("Throw Called");
        Transform pickup = transform.Find("Equipment Slot").GetChild(0).GetChild(1); //Get the Pistol Pick Up Object
        transform.Find("Equipment Slot").DetachChildren(); //Remove the Pistol Prefab from Equipment Slot
        pickup.gameObject.SetActive(true); // Set the pickup to active
        float throwForce = controller.getVelocity().x * throwStregth;
        pickup.gameObject.GetComponent<IThrowable>().Throw(new Vector2(throwForce,0)); //Throw the object;
    }

    private void Drop() {
        //drop code
        Debug.Log("Drop Called");
        Transform pickup = transform.Find("Equipment Slot").GetChild(0).GetChild(1); //Get the Pistol Pick Up Object
        transform.Find("Equipment Slot").DetachChildren(); //Remove the Pistol Prefab from Equipment Slot
        pickup.gameObject.SetActive(true); // Set the pickup to active
        pickup.gameObject.GetComponent<IThrowable>().Throw(new Vector2()); //Drop the object;
        
    }

    public void OnLanding() {
        animator.SetBool("IsGrounded", true);
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
