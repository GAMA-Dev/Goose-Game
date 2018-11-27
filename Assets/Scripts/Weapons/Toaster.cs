using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour, IUseable {
	[SerializeField]
    private AmmoCount ammoCount;
    [SerializeField]
    private GameObject ammoPrefab;
    [SerializeField]
    private Transform ammoSpawn;
    private float playerDir;
	private Vector2 lobForces;
	float lobMultiplier = 0.5f;
	bool ableToFire = false;
	GameObject bullet;
	bool justReloaded;

	void Awake(){
		transform.position = transform.parent.transform.position;
		ammoCount = GetComponent<AmmoCount>();
		ammoCount.setCount(1);
	}
	public void Use() {
       if(ammoCount.count == 0)
	   {
		   ammoCount.count--;
		   justReloaded = true;
	   }
    }
	void Update()
	{
		if(transform.parent.transform.parent.GetComponentInParent<CharacterController2D>().m_FacingRight)
        {//Checks the Duck object to see if it's facing left or right
            playerDir = 1;
        }
        else
        {
            playerDir = -1;
        }
		if(Input.GetButtonUp(transform.parent.transform.parent.GetComponentInParent<PlayerMovement>().useButton) && justReloaded == true)
		{
			justReloaded = false;
		}
		if(Input.GetButton(transform.parent.transform.parent.GetComponentInParent<PlayerMovement>().useButton)&& ammoCount.count >= 1 && justReloaded == false)
		{//Calculates the lob forces
			Debug.Log("GMBD");
			lobMultiplier += 0.005f;
			ableToFire = true;
		}
		if(Input.GetButtonUp(transform.parent.transform.parent.GetComponentInParent<PlayerMovement>().useButton) && ableToFire)
			{//Toast Firing Code
				ammoCount.count--;
				lobForces = new Vector2(500*lobMultiplier*playerDir, 250*lobMultiplier); //Makes the lob forces and applys the lob multiplyer
				GameObject bullet = Instantiate(ammoPrefab, ammoSpawn.position, new Quaternion()); //Creates New Bullet
 	            bullet.GetComponent<Rigidbody2D>().AddForce(lobForces); //Adds the bullets force and sets the correct player direction for the bullet
				bullet.GetComponent<SpriteRenderer>().color = new Color(1/lobMultiplier, 1/lobMultiplier, 1/lobMultiplier, 1); //Darkens the bread based on lob multiplyer
	            Debug.Log("Use called");
				lobMultiplier = 0.5f;
				ableToFire = false;
			}
		if(lobMultiplier > 2)
		{
			lobMultiplier = 2;
		}
	}
}
