using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Script : MonoBehaviour, IEquipable, IThrowable {

	[SerializeField]
	private GameObject realGun;
	private Rigidbody2D body;


	// Use this for initialization
	void Awake () 
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	public void Equip (Transform slot) 
	{
		transform.parent.transform.position = slot.position; //Sets the Pistol Prefab object position to the given slot
        transform.parent.transform.localScale = slot.parent.localScale; //makes sure the pistol is facing the right way
		transform.parent.transform.SetParent(slot); // Attaches the Pistol Prefab object to the given slot
        gameObject.SetActive(false); //Disables the pickup object
	}
	void OnDisable()
	{ //Enables the Real Gun after disabling the pickup object
		realGun.SetActive(true);
	}
	void OnEnable()
	{
		//Code that sets the pickup to the parent's position and disables the real gun
		transform.position = transform.parent.transform.position;
		realGun.SetActive(false);
	}
	public void Throw(Vector2 force)
	{
		body.AddForce(force); //Throws the object
	}
}
