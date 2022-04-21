using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    public float speed=8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.y<=4) {
            transform.Translate(Vector3.up*speed* Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y>=-4) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "fantasma") {
            
        }
    }
}
