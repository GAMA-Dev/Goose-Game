using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IUseable, IThrowable {
    [SerializeField]
    public Transform playerToFollow;
    [SerializeField]
    private int ammoCount = 1;
    [SerializeField]
    private int bulletSpeed = 10;
    [SerializeField]
    private GameObject ammoPrefab;
    [SerializeField]
    private Transform ammoSpawn;

    void Update()
    {
        transform.position = playerToFollow.position;
    }
    public void Use() {
        if (ammoCount >= 1) {
            ammoCount--;
            GameObject bullet = Instantiate(ammoPrefab, ammoSpawn.position, ammoSpawn.rotation );
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed); 
        }
        else {
            Debug.Log(name + "is empty");
        }
    }

    public void Throw() {
        Debug.Log(name + "Throw function called");
    }

}
