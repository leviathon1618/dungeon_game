using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private GameObject player_obj;
    public float speed;
    public GameObject carrot_prefab;
    public List<GameObject> memes = new List<GameObject>();
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player_obj = GameObject.Find("player");

        if (tag == "chungus")
        {
            StartCoroutine(shoot_carrot());
        }
        if (tag == "pog")
        {
            StartCoroutine(shoot_meme());
        }
        if (tag == "nyan_cat")
        {
            StartCoroutine(nyan_cat_attack());
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            health -= 1;
        }
        if (transform.tag == "donkey" && collision.transform.name == "player")
        {
            player player_obj = collision.transform.GetComponent<player>();
            collision.transform.GetComponent<Rigidbody2D>().AddForce(transform.right, ForceMode2D.Impulse);
            StartCoroutine(turn_back_on(player_obj));
        }
    }

    public IEnumerator turn_back_on(player variable)
    {
        print("hit");
        speed = 0;
        variable.enabled = false;
        yield return new WaitForSeconds(2);
        variable.enabled = true;
        yield return new WaitForSeconds(1);
        speed = 0.2f;
    }

    public IEnumerator shoot_meme()
    {
        while (true)
        {
            print("shooting meme");
            yield return new WaitForSeconds(1f);
            int rand = Random.Range(0, 3);
            GameObject test = Instantiate(memes[rand], transform.position, Quaternion.identity);
            test.transform.right = player_obj.transform.position - transform.position;
            test.transform.rotation = test.transform.rotation * Quaternion.Euler(0, 0, 180);
            //print("shooting");
        }
    }

    public IEnumerator shoot_carrot() 
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject test = Instantiate(carrot_prefab, transform.position, Quaternion.identity);
            test.transform.right = player_obj.transform.position - transform.position;
            test.transform.rotation = test.transform.rotation * Quaternion.Euler(0, 0, 180);
            //print("shooting");
        }
    }

    public IEnumerator nyan_cat_attack()
    {
        while (true)
        {
            transform.LookAt(player_obj.transform);
            transform.right = player_obj.transform.position - transform.position;
            yield return new WaitForSeconds(0.3f);
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.004f);
                transform.position += transform.right / 70;
            }
            yield return new WaitForSeconds(2.5f);
        }
    }


    // Move to the target end position.
    void Update()
    {
        if (tag == "troll" || tag == "creeper" || tag == "donkey")
        {
            transform.LookAt(player_obj.transform);
            transform.right = player_obj.transform.position - transform.position;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (tag == "creeper")
        {
            float distance = Vector2.Distance(player_obj.transform.position, transform.position);
            if (distance < 0.3)
            {
                print("explode");
                player_obj.GetComponent<player>().take_creeper_damage();
                Destroy(gameObject);
            }
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
