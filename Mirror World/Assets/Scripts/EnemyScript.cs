using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int health = 15;

    public void Attacked(int attackPower)
    {
        Debug.Log("Ouch! You hit me for " + attackPower +"!");
        health -= attackPower;
    }

    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
