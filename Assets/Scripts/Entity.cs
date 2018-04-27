using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public enum Direction
    {
        left,
        right
    }

    public float flyingMod;
    public float speedMod;
    private bool dead;            
    public Direction direction;
    public string button;

    //private Animator anim;                 
    private Rigidbody2D body;

    void Start()
    {
        //anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        if(direction == Direction.left)
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
    }

    void Update()
    {
        if (dead) return;
        if (Input.GetKeyDown(button))
        {
            Debug.Log("Pressed");
            //anim.SetTrigger("Somethingtomakeitmove");
            body.velocity = Vector2.zero;               
            body.angularVelocity = 0;
            body.rotation = 0F;       

            if(direction == Direction.right)
                body.AddForce(new Vector2(speedMod, flyingMod));
            else
                body.AddForce(new Vector2(-speedMod, flyingMod));

            body.AddTorque(5F);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SideWall")
        {
            if (direction == Direction.right) direction = Direction.left;
            else direction = Direction.right;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }

        if(collision.otherCollider.GetType() != typeof(BoxCollider2D) && collision.collider.GetType() == typeof(BoxCollider2D))
        {
            Debug.Log("Dead");
            body.velocity = Vector2.zero;
            dead = true;
            //anim.SetTrigger("DieAnimation");
            //gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Blocked");
        }
    }
}
