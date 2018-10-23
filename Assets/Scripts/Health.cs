using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IKillable {

    [SerializeField]
    private int healthAmount = 100;


    public void Damage(int amount) {
        healthAmount -= amount;
        if (healthAmount <= 0) {
            Die();
        }
    }

    public void Die() {
        Debug.Log(name + " is dead");
    }
}
