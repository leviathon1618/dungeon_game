using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Camera main_cam;
    public Rigidbody2D rb;
    public int health;
    public float speed;
    public AudioSource death_noise;
    public GameObject try_again_btn;
    public GameObject bullet;
    public GameObject heart_obj;
    public List<GameObject> hearts = new List<GameObject>();
    public bool can_take_damage = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        for (float i = 1; i <= 5; i++)
        {
            float test = i / 10;
            
            GameObject first_obj = Instantiate(heart_obj, new Vector3(-0.9f+test, 0.4f, 0), Quaternion.identity,Camera.main.transform);
            hearts.Add(first_obj);
            first_obj.name = $"heart {hearts.Count -1}";
            health++;
        }
    }

    public void remove_heart(int damage)
    {
        if (can_take_damage == true)
        {
            if (health <= 0)
            {
                try_again_btn.SetActive(true);
                Time.timeScale = 0;
                print("dead");
            }
            else
            {
                print("hit");
                death_noise.Play();
                for (int i = 0; i < damage; i++)
                {
                    Destroy(hearts[hearts.Count - 1]);
                    hearts.Remove(hearts[hearts.Count - 1]);
                }
                health--;
                StartCoroutine(delay_damage());
            }
        }
    }

    public IEnumerator delay_damage()
    {
        can_take_damage = false;
        yield return new WaitForSeconds(2);
        can_take_damage = true;
    }

    public void reset_game()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }


    public void add_heart()
    {
        int childs = Camera.main.transform.childCount;
        GameObject first_obj = Instantiate(heart_obj, Camera.main.transform.GetChild(childs - 1).transform.position + new Vector3(0.1f,0,0), Quaternion.identity, Camera.main.transform);
        hearts.Add(first_obj);
        first_obj.name = $"heart {hearts.Count - 1}";
        health++;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "troll")
        {
            //health -= 1;
            remove_heart(1);
        }
        if (collision.transform.tag == "chungus")
        {
            //health -= 1;
            remove_heart(1);
        }
        if (collision.transform.tag == "pog")
        {
            //health -= 1;
            remove_heart(1);
        }
        if (collision.transform.tag == "donkey")
        {
            health -= 2;
            remove_heart(2); 
            
        }
        if (collision.transform.tag == "nyan_cat")
        {
            health -= 1;
            remove_heart(1);
        }
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
