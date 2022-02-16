using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 move;
    //Change timeSinceLastAttack to count up and reset to zero from receiving a succeful attack bool from PlayerAttack.
    private float timeSinceLastAttack = 5.0f;
    //Interact is the universal interaction thing. Don't change that unless you know what you are doing.
    public GameObject Interact;
    //UsingItem is the attack thing for now. And it should be the one that is changeable through inventory.
    public GameObject UsingItem;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (move.x > 0.2)
            transform.eulerAngles = new Vector3(0, 0, 270);
        else if (move.x < -0.2)
            transform.eulerAngles = new Vector3(0, 0, 90);
        else
        {
            if (move.y > 0.2)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else if (move.y < -0.2)
                transform.eulerAngles = new Vector3(0, 0, 180);
        }

        if (Input.GetKeyDown("e"))
        {
            
            Interact.GetComponent<PlayerInteract>().PressedE();

        }

        if (Input.GetKeyDown("space"))
        {
            UsingItem.GetComponent<PlayerAttack>().PressedSpace(timeSinceLastAttack);
        }


    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + (move.normalized * moveSpeed * Time.deltaTime));

    }

}