using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Script : MonoBehaviour, IEquipable {
	public bool thrown;
	[SerializeField]
	private GameObject realGun;


	// Use this for initialization
	void Awake () 
	{
		if(thrown)
		{
			//throwing code
		}
		else
		{
			//else
		}
	}
	
	public void Equip (Transform slot) 
	{
        Instantiate(realGun, slot.position, Quaternion.identity, slot);
        Destroy(this.gameObject); 
	}
	
}
