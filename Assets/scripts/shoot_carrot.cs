using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_carrot : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name != transform.name)
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }
}
