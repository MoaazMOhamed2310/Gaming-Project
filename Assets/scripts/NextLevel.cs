using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player" && PlayerStats.hasPill==true){
            SceneManager.LoadScene(2);
            Debug.Log("Lives: "+PlayerStats.lives);
            Debug.Log("Lives: "+PlayerStats.health);
            Debug.Log("Score: "+PlayerStats.score);
           // AudioManager.Instance.PlayMusic(AudioManager.Instance.caveMusic);
        }else{
            FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
