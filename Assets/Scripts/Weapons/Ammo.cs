using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField]
    private int damage = 100;

    private void OnTriggerEnter(Collider other) {
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
