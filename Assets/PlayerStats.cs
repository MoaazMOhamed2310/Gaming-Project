using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playerstats : MonoBehaviour
{
    public int health = 3;
    public int lives = 3;
public int score = 0;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    public TextMeshProUGUI scoreUI;
    private SpriteRenderer sr;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isImmune)
        {
            SpriteFlicker();
            immunityTime += Time.deltaTime;

            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true; // Make sure player becomes visible again
            }
        }
    scoreUI.text = " " + score;
    }

    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            health -= damage;

            if (health < 0)
                health = 0;

            // Respawn if health reaches zero
            if (lives > 0 && health == 0)
            {
                FindObjectOfType<LevelManger>().RespawnPlayer();
                health = 3;
                lives--;
            }
            else if (lives == 0 && health == 0)
            {
                Debug.Log("Game Over");
                Destroy(this.gameObject);
            }

            Debug.Log("Player Health: " + health);
            Debug.Log("Player Lives: " + lives);

            isImmune = true;
            immunityTime = 0f;
        }
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime += Time.deltaTime;
        }
        else
        {
            sr.enabled = !sr.enabled;
            flickerTime = 0f;
        }
    }
}
