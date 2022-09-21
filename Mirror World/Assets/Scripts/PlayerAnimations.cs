using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Sprite front;
    [SerializeField] Sprite back;
    [SerializeField] Sprite right;

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
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        //    anim.enabled = true;
        //else
        //    anim.enabled = false;

        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(move.y < 0)
        {
            renderer.flipX = false;
            anim.SetBool("WalkDown", true);
        }
        else
        {
            anim.SetBool("WalkDown", false);
        }

        if(move.y > 0)
        {
            renderer.flipX = false;
            anim.SetBool("WalkUp", true);
        }
        else
        {
            anim.SetBool("WalkUp", false);
        }

        if(move.x > 0)
        {
            renderer.flipX = false;
            anim.SetBool("WalkRight", true);
        }
        else
        {
            anim.SetBool("WalkRight", false);
        }

        if(move.x < 0)
        {
            anim.SetBool("WalkLeft", true);
            //renderer.sprite = right;
            renderer.flipX = true;
        }
        else
        {
            anim.SetBool("WalkLeft", false);
        }



        
    }

    private void LateUpdate()
    {
        //if (gameObject.transform.rotation.z == 0)
        //    renderer.sprite = back;
        //if (gameObject.transform.rotation.z > 179 && gameObject.transform.rotation.z < 181)
        //    renderer.sprite = front;
        //else if (gameObject.transform.rotation.z == 90)
        //    renderer.sprite = right;
        //else if (gameObject.transform.rotation.z == -90)
        //{
        //    renderer.sprite = right;
        //    renderer.flipX = true;
        //}
        //else
        //    renderer.flipX = false;
    }
}
