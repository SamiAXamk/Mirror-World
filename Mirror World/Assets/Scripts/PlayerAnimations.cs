using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
            anim.SetBool("WalkDown", true);
        else
            anim.SetBool("WalkDown", false);

        if (Input.GetKey(KeyCode.UpArrow))
            anim.SetBool("WalkUp", true);
        else
            anim.SetBool("WalkUp", false);

        if (Input.GetKey(KeyCode.RightArrow))
            anim.SetBool("WalkRight", true);
        else
            anim.SetBool("WalkRight", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("WalkLeft", true);
            //gameObject.transform.localScale = new Vector3(1,1,-1);
            renderer.flipX = true;
        }
        else
        {
            anim.SetBool("WalkLeft", false);
            //gameObject.transform.localScale = new Vector3(1, 1, 1);
            renderer.flipX = false;
        }
    }
}
