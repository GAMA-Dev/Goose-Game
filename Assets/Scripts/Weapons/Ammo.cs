using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    private int bulletspeed = 100;

    private void Awake() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletspeed,0));
    }


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
