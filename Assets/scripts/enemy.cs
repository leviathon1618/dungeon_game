using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    private GameObject player_obj;
    public float speed;
    public GameObject carrot_prefab;
    void Start()
    {
        player_obj = GameObject.Find("player");

        if (tag == "chungus")
        {
            StartCoroutine(shoot_carrot());
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            health -= 25;
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


    // Move to the target end position.
    void Update()
    {
        if (tag == "troll")
        {
            transform.LookAt(player_obj.transform);
            transform.right = player_obj.transform.position - transform.position;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
    }
}
