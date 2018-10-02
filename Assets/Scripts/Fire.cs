using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Useable {

    [SerializeField]
    private int ammoCount = 1;
    [SerializeField]
    private GameObject ammo;

    public override void Use() {
        if (ammoCount >= 1) {
            ammoCount--;
            
        }
    }
}
