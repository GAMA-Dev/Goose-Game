using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int healthAmount = 100;

    public void Damage(int amount) {
        healthAmount -= amount;
        if (healthAmount <= 0) {
            Debug.Log(gameObject.name + "health is at" + healthAmount);
        }
    }


}
