using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int healthAmount = 100;

    private IKillable entity; 

    private void Awake() {
        entity = gameObject.GetComponent<IKillable>();
    }

    public void Damage(int amount) {
        healthAmount -= amount;
        if (healthAmount <= 0) {
            if (entity != null) {
                entity.Die();
            }
            else {
                Destroy(gameObject);
            }
        }
    }


}
