using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public string button2;
    public Player player;
 

    private Rigidbody2D body;
    public GameObject fire;
    private Animator anim;
    private AudioSource source;

    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip deadSound;

    private bool firePlaced;

    void Start()
    {
		//Time.timeScale = 0;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(Faster());
        if(player==Player.one)
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GameManager.player1;
        else
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GameManager.player2;
       
        //delete?//if(direction == Direction.left)
        //delete?//    gameObject.transform.Rotate(new Vector3(0, 180, 0));
		
    }

    IEnumerator Faster()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(10);
            speedMod = speedMod * 1.2f;
        }
    }

    void Update()
    {
        
        if (dead) return;
        if (Input.GetKeyDown(button))
        {
            Debug.Log("Pressed");
            source.PlayOneShot(jumpSound, 1F);
            anim.SetInteger("State",1);
            anim.Play("Jump", -1, 0f);
            body.velocity = Vector2.zero;               
            body.angularVelocity = 0;
            body.rotation = 0F;       

            if(direction == Direction.right){
                body.AddForce(new Vector2(speedMod, flyingMod));
                body.AddTorque(5F);
            }
            else{
                body.AddForce(new Vector2(-speedMod, flyingMod));
                body.AddTorque(-5F);
            }
            
        }
        if (Input.GetKeyDown(button2) && !firePlaced) {
            Vector3 vector;
            if(direction == Direction.right){
                vector = new Vector3(transform.position.x - 1.1F, transform.position.y);
            }
            else{
                vector = new Vector3(transform.position.x + 1.1F, transform.position.y);
            }
            var f = Instantiate(fire, vector, Quaternion.identity);
            firePlaced = true;
        }
    }

   

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "SideWall")
        {
            if (!dead) {source.PlayOneShot(hitSound, 1F);}
            if (direction == Direction.right) direction = Direction.left;
            else direction = Direction.right;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            firePlaced = false;
        }

        if(collision.gameObject.tag == "Danger")
        {
            //Debug.Log("Dead");
            body.velocity = Vector2.zero;
            if (!dead) {source.PlayOneShot(deadSound, 1F);}
            dead = true;
            anim.SetInteger("State",2);
            
            //GameManager.trigger = player;
            //GameManager.Victory();
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
