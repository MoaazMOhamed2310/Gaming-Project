using UnityEngine;

public class Coin : MonoBehaviour
{
    //public AudioClip[] coinSounds;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.score+= 1;
            Destroy(gameObject);
            //AudioManager.instance.PlayRandomSFX(coinSounds);
        }
    }
}
