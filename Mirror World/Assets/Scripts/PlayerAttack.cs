using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //Change this to list when doing proper combat.
    private Collider2D attackableTarget = null;
    private int attackPower = 5;
    private float attackSpeed = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Enemy"))
        {
            attackableTarget = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Change this to go through the list and remove other.
        if (other = attackableTarget)
        {
            attackableTarget = null;
        }
    }

    //Change void to bool, where method returns true, if attackSpeed constraint was met (regardless of whether the attack hit anything).
    public void PressedSpace(float timeFromLastAttack)
    {
        //Change to "for each in list".
        if (attackableTarget != null && timeFromLastAttack >= attackSpeed)
        {
            attackableTarget.gameObject.GetComponent<EnemyScript>().Attacked(attackPower);
            
        }
    }

}
