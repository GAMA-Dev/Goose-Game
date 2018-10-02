using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : MonoBehaviour {
    [SerializeField]
    private GameObject equipment;

    public GameObject Equip() {
        return equipment;
    }
}
