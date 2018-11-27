using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour {
	Text txt;
	[SerializeField]
	private GameObject player;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.GetChild(4).GetChild(0))
		{
			txt.text = player.transform.GetChild(4).transform.GetChild(0).transform.GetChild(0).GetComponent<AmmoCount>().count.ToString(); 
		}
		else
		{
			txt.text = "";
		}
		
	}
}
