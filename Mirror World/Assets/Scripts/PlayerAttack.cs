using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    List<Collider2D> Targets = new List<Collider2D>();
    private int attackPower = 5;
    private float itemCD = 1.0f;        // can't use this item during cd
    private float animationCD = 1.0f;   // can't use any item during this cd
    private float timeFromLastUse = 0;

    //Adds valid targets to the list.
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Enemy"))
        {
            Targets.Add(other);
        }
    }

    //Removed a target from the list.
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (Targets.Contains(other))
        {
            Targets.Remove(other);
        }
    }

    //Uses item if itemCD has expired and returns animationCD, which is the time this item takes to "trigger", preventing other item uses.
    public float PressedSpace()
    {
        
        if (timeFromLastUse >= itemCD)
        {
            foreach (Collider2D target in Targets)
            {
                target.gameObject.GetComponent<EnemyScript>().Attacked(attackPower);
            }

            timeFromLastUse = 0;
            return animationCD;
        }

        //If itemCD has not expired return 0, which means item wasn't used.
        //You can add some mild sound for this as well.
        else
        return 0;
    }

    //Countdown for item cooldown.
    void Update()
    {
        if (timeFromLastUse < 2000)
        {
            timeFromLastUse += Time.deltaTime;
        }
    }

}
