using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Script : MonoBehaviour, IEquipable, IThrowable {

	[SerializeField]
	private GameObject realGun;
	[SerializeField]
	private GameObject parent;
	private Rigidbody2D body;


	// Use this for initialization
	void Awake () 
	{
		body = GetComponent<Rigidbody2D>();
	}
	
	public void Equip (Transform slot) 
	{
		parent.transform.position = slot.position; //Sets the Pistol Prefab object position to the given slot
		parent.transform.SetParent(slot); // Attaches the Pistol Prefab object to the given slot
        this.gameObject.SetActive(false); //Disables the pickup object
	}
	void OnDisable()
	{ //Enables the Real Gun after disabling the pickup object
		realGun.SetActive(true);
	}
	void OnEnable()
	{
		//Code that sets the pickup to the parent's position and disables the real gun
		transform.position = parent.transform.position;
		realGun.SetActive(false);
	}
	public void Throw(Vector2 force)
	{
		body.AddForce(force); //Throws the object
	}
}
