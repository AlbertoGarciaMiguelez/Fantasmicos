using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmas : MonoBehaviour
{
    public float speedFantasma=6f;
    Animator animator;
    public AudioClip fantasmaSonido;
    private bool primera;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        primera=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSpawn.instance.IsGameOver()) {
            return;
        }
        Vector3 newPosition=transform.position;
        newPosition+=Vector3.right*speedFantasma*Time.deltaTime;
        transform.position=newPosition;
        if(transform.position.x>=10 && primera==true){
            GameSpawn.instance.Vidas();
            primera=false;
        }
        if(transform.position.x>=20){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player") {
            speedFantasma=0;
            animator.SetBool("muerto", true);
            GameSpawn.instance.playAudioClip(fantasmaSonido);
            GameSpawn.instance.Contador();
        }
    }
    public void Destruccion(){

        Destroy(this.gameObject);
    }
}
