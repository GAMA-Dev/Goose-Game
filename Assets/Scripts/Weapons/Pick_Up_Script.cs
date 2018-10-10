using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Script : MonoBehaviour, IEquipable {
	public bool thrown;
	[SerializeField]
	private GameObject realGun;
	[SerializeField]
	public GameObject equipSlot;

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
	
	public void Equip () 
	{
		GameObject clone = Instantiate(realGun, new Vector3(0, 0, 0), Quaternion.identity);
		clone.GetComponent<Gun>().playerToFollow = equipSlot.transform;
		Destroy(this.gameObject);
	}
	
}
