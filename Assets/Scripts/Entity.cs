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
    public int player;

    private Animator anim;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip deadSound;
    private AudioSource source;                 
    private Rigidbody2D body;

    private bool detectedCollision;

    void Start()
    {
		//Time.timeScale = 0;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        //delete?//if(direction == Direction.left)
        //delete?//    gameObject.transform.Rotate(new Vector3(0, 180, 0));
		
    }
	

    void Update()
    {
        
        if (dead) return;
        if (Input.GetKeyDown(button))
        {
            if(detectedCollision) {
            detectedCollision = false;
            }
            Debug.Log("Pressed");
            source.PlayOneShot(jumpSound, 1F);
            anim.SetInteger("State",1);
            anim.Play("Jump", -1, 0f);
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
        
        if((collision.gameObject.tag == "SideWall") && !detectedCollision)
        {
            source.PlayOneShot(hitSound, 1F);
            if (direction == Direction.right) direction = Direction.left;
            else direction = Direction.right;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            detectedCollision = true;
        }

        if(collision.gameObject.tag == "Danger")
        {
            //Debug.Log("Dead");
            body.velocity = Vector2.zero;
            if (!dead) {source.PlayOneShot(deadSound, 1F);}
            dead = true;
            anim.SetInteger("State",2);
            
            GameManager.trigger = player;
            GameManager.Victory();
        }
        else
        {
            //Debug.Log("Blocked");
            //if(collision.collider.tag=="Entity")
            //{
                //script.Victory(false, player);
            //}
        }
    }
}
