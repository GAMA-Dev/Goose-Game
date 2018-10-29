using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    private int bulletspeed = 100;


    //need to get scale of duck who is shooting and multiply it by bulletspeed to get direction
    


    void OnCollisionEnter2D(Collision2D other) {
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null) {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }


}
