using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public int dice1;
    public int dice2;
    //Events
    public static event System.Action OnRollDice;

    //Event Listener
    void OnEnable()
    {
        Player.OnMiddleClick += RollDice;
    }

    private void RollDice()
    {
        this.dice1 = UnityEngine.Random.Range(1, 7);
        this.dice2 = UnityEngine.Random.Range(1, 7);

        // Realizar acciones con los números generados (en este caso, solo imprimirlos)
        Debug.Log("Dado 1: " + dice1);
        Debug.Log("Dado 2: " + dice2);

        OnRollDice();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
