using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script generates a number 1-4 to choose what player will be the goose

public class Goose_Generator : MonoBehaviour
{
    //variable to hold who is the goose
    public int Goose;

    void Start()
    {
        GooseGen();
    }

    void GooseGen()
    {
        Goose = Random.Range(1, 5);
    }
}