using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IUseable {
    [SerializeField]
    private int ammoCount = 1;
    [SerializeField]
    private GameObject ammoPrefab;
    [SerializeField]
    private Transform ammoSpawn;


    public void Use() {
        if (ammoCount >= 1) {
            ammoCount--;
            GameObject bullet = Instantiate(ammoPrefab, ammoSpawn.position, new Quaternion());
            Debug.Log("Use called");
        }
        else {
            Debug.Log(name + " is empty");
        }
    }



    
}
