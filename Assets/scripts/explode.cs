using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public int explode_obj_total;
    public List<GameObject> explosion = new List<GameObject>();
    public float scale;
    //public AudioSource play_thing;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(point_spawn());
        Destroy(gameObject,5);
    }

    public IEnumerator point_spawn()
    {
        for (int i = 0; i < explode_obj_total; i++)
        {
            yield return new WaitForSeconds(0.2f);

            StartCoroutine(explode_stuff());
        }
        
    }

    public IEnumerator explode_stuff()
    {
        float delay = 0.01f;
        for (int i = 0; i < 15; i++)
        {
            float randx = Random.Range(-0.2f, 0.2f);
            float randy = Random.Range(-0.2f, 0.2f);
            Vector3 position = new Vector3(randx, randy, 0);
            GameObject obj = Instantiate(explosion[i], transform.position +position, Quaternion.identity);
            obj.transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(delay);
            Destroy(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
