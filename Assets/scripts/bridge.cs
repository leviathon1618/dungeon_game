using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("exit"))
        {
            Destroy(collision);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
