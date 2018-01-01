using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D bombermanBody;
    public float speed;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        bombermanBody = this.GetComponent<Rigidbody2D>();
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        bombermanBody.velocity = speed * new Vector2(horizontal, vertical);

        if (vertical == 0 && horizontal == 0)
        {            
            animator.enabled = false;
        }
        else
        {
            if (vertical > 0)
            {
                animator.SetInteger("Direction", 2);
            }
            else if (vertical < 0)
            {
                animator.SetInteger("Direction", 0);
            }
            else if (horizontal > 0)
            {
                animator.SetInteger("Direction", 3);
            }
            else if (horizontal < 0)
            {
                animator.SetInteger("Direction", 1);
            }
            animator.enabled = true;
        }
    }
}
