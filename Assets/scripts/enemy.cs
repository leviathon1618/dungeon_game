using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            health -= 25;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
