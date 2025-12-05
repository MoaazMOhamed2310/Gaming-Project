using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip[] coinSounds;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.score += 1;

            AudioManager.instance.PlayRandomSFX(coinSounds);
        

   Destroy(gameObject);

        }
    }
}
