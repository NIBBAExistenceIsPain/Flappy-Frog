using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float flyingMod;          
    //private bool isDead = false;            
    public bool direction;
    public string button;

    //private Animator anim;                 
    private Rigidbody2D body;

    void Start()
    {
        //anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        //body.centerOfMass = new Vector2(0.1F, 0F);
        //body.inertia = 1F;
        if(!direction)
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
    }

    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            Debug.Log("Pressed");
            //anim.SetTrigger("Flap");
            body.velocity = Vector2.zero;               
            body.angularVelocity = 0;
            body.rotation = 0F;
       

            if(direction)
                body.AddForce(new Vector2(200, flyingMod));
            else
                body.AddForce(new Vector2(-200, flyingMod));

            body.AddTorque(5F);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SideWall")
        {
            //body.velocity.Scale(new Vector2(-100, 100));
            direction = !direction;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }

        /*if(other.otherCollider.GetType() == typeof(BoxCollider2D) && other.collider.GetType() != typeof(BoxCollider2D) && other.otherCollider.gameObject.tag == "Entity")
        {

        }*/

        if(collision.otherCollider.GetType() != typeof(BoxCollider2D))
        {
            //isDead = true;
            Debug.Log("Dead");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Blocked");
        }

        /*body.velocity = Vector2.zero;
        isDead = true;
        //anim.SetTrigger("Die");
        //GameControl.instance.BirdDied();
        gameObject.SetActive(false);*/
    }
}
