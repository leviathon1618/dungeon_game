using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public IEnumerator rise_floor()
    {
        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
