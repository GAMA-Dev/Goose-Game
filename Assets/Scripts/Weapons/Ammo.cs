using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    private int bulletspeed = 100;


    private void OnColliderEnter(Collider other) {
        Health health = other.GetComponent<Health>();
        if (health != null) {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }


}
