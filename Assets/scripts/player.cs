using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Camera main_cam;
    public Rigidbody2D rb;
    public int health;
    public float speed;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "troll")
        {
            health -= 1;
        }
        if (collision.transform.tag == "chungus")
        {
            health -= 1;
        }
        if (collision.transform.tag == "pog")
        {
            health -= 1;
        }
        if (collision.transform.tag == "donkey")
        {
            health -= 2;
        }
        if (collision.transform.tag == "nyan_cat")
        {
            health -= 1;
        }
    }

    public void take_creeper_damage()
    {
        health -= 2;
    }

    // Update is called once per frame
    void Update()
    {
        main_cam.transform.position = transform.position + new Vector3(0,0,-10);
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * speed * Time.deltaTime,ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * speed * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Force);
        }
        var lookAtPos = Input.mousePosition;
        lookAtPos.z = transform.position.z - Camera.main.transform.position.z;
        lookAtPos = Camera.main.ScreenToWorldPoint(lookAtPos);
        transform.up = lookAtPos - transform.position;
    }
}
