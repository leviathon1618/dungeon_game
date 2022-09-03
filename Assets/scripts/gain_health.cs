using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gain_health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "player")
        {
            int health = collision.transform.GetComponent<player>().health;
            if (health < 18)
            {
                collision.transform.GetComponent<player>().add_heart();
            }
            
        }
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
