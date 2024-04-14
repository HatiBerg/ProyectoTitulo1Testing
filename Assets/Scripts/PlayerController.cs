using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    bool cantJump;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }
    void FixedUpdate()
    {
        //gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            cantJump = true;
        }
    }

    void Movement()
    {
        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }

        if (!Input.GetKey("w"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("jumping");
        }

        if (Input.GetKeyDown("w") && cantJump)
        {
            cantJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 220f));
            gameObject.GetComponent<Animator>().SetTrigger("jumping");
        }
    }
}