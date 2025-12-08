using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static bool hasPill = false;
    public static int health = 4;
    public static int lives = 2;
    public static int score = 0;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
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
        if (isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }
    }

    void SpriteFlicker()
    {
        if (flickerTime < flickerDuration)
        {
            flickerTime = flickerTime + Time.deltaTime;
        }
        else if (flickerTime >= flickerDuration)
        {
            sr.enabled = !(sr.enabled);
            flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isImmune == false)
        {
            health = health - damage;
            if (health < 0)
                health = 0;

            if (lives > 0 && health == 0)
            {
                lives = lives - 1;
                health = 4;
                transform.position = new Vector3(0, 0, 0);
            }
            else if (lives == 0 && health == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }

            Debug.Log("Player Health: " + health.ToString());
            Debug.Log("Player Lives: " + lives.ToString());
        }
        isImmune = true;
        immunityTime = 0f;
    }
}