using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawn : MonoBehaviour
{
    public static GameSpawn instance;
    public GameObject prefab;
    private AudioSource Audio;
    public AudioClip spawnAudio;
    public int numeroEnemigos;
    public GameObject cartelGameOver;
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;
    public int vidas=4;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        if(prefab == null) {
            Debug.Log("SceneController: No está establecido el prefab");
        }
        if(vida1 == null) {
            Debug.Log("GameManager.Start cartelGameOver no está establecido");
        }
        if(vida2 == null) {
            Debug.Log("GameManager.Start cartelGameOver no está establecido");
        }
        if(vida3 == null) {
            Debug.Log("GameManager.Start cartelGameOver no está establecido");
        }
        if(vida4 == null) {
            Debug.Log("GameManager.Start cartelGameOver no está establecido");
        }
        if(cartelGameOver == null) {
            Debug.Log("GameManager.Start cartelGameOver no está establecido");
        }
        Audio = GetComponent<AudioSource>();
        Spawning();
        gameOver = false;
    }
    void Awake(){
        instance=this;
    }
    // Update is called once per frame
    void Update()
    {
        if(gameOver==true){
            return;
        }
        if(Random.value<=0.001f){
            Spawning();
        }
    }
    private void Spawning() {
            int x= Random.Range(0,5);
                if(x==0){
                    spawn(prefab, new Vector3(-10, 2.54f, 0f));
                }
                else if(x==1){
                    spawn(prefab, new Vector3(-10, 1.66f, 0f));
                }
                else if(x==2){
                    spawn(prefab, new Vector3(-10, 0f, 0f));
                }
                else if(x==3){
                    spawn(prefab, new Vector3(-10, -1.24f, 0f));
                }
                else if(x==4){
                    spawn(prefab, new Vector3(-10, -3.14f, 0f));
                }
                playAudioClip(spawnAudio);
    }
    public void playAudioClip(AudioClip clip) {
        Audio.PlayOneShot(clip);
    }
    private void spawn(GameObject prefab, Vector3 spawnPoint) {
        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
    public void Contador(){
        numeroEnemigos += 1;
        Debug.Log(numeroEnemigos);
    }
    public void Vidas(){
        vidas-=1;
        if(vidas==3){
            vida4.SetActive(false);
        }
        else if(vidas==2){
            vida3.SetActive(false);
        }
        else if(vidas==1){
            vida2.SetActive(false);
        }
        else if(vidas==0){
            vida1.SetActive(false);
            cartelGameOver.SetActive(true);
            gameOver = true;
        }
    }
    public bool IsGameOver() {
        return gameOver;
    }
}
