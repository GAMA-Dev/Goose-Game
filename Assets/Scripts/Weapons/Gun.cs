using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IUseable {
    [SerializeField]
    private AmmoCount ammoCount;
    [SerializeField]
    private GameObject ammoPrefab;
    [SerializeField]
    private Transform ammoSpawn;
    private float playerDir;

    void Awake()
    {
        ammoCount = GetComponent<AmmoCount>();
        ammoCount.setCount(8);
    }
    public void Use() {
        if(ammoCount.count == 0)
        {
            ammoCount.count--;
        }
        if(transform.parent.transform.parent.GetComponentInParent<CharacterController2D>().m_FacingRight)
        {//Checks the Duck object to see if it's facing left or right
            playerDir = 1;
        }
        else
        {
            playerDir = -1;
        }
        if (ammoCount.count >= 1) {
            ammoCount.count--;
            GameObject bullet = Instantiate(ammoPrefab, ammoSpawn.position, new Quaternion()); //Creates New Bullet
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(800*playerDir, 0)); //Adds the bullets force and sets the correct player direction for the bullet
            Debug.Log("Use called");
        }
        
        else {
            Debug.Log(name + " is empty");
        }
    }



    
}
