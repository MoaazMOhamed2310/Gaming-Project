using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class Door : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;          // الأنيميشن للباب
    public AudioSource audioSource;    // صوت فتح الباب
    public GameObject cutsceneObject;  // GameObject يحتوي على VideoPlayer
    public VideoPlayer videoPlayer;    // VideoPlayer للفيديو
    public float openDuration = 3f;    // مدة فتح الباب

    private bool playerNear = false;

    void Start()
    {
        if(cutsceneObject != null)
            cutsceneObject.SetActive(false); // الفيديو مخفي في البداية
        if(videoPlayer != null)
            videoPlayer.playOnAwake = false;
        if(audioSource != null)
            audioSource.playOnAwake = false;
    }

    void Update()
    {
        if(playerNear && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OpenDoorSequence());
        }
    }

    IEnumerator OpenDoorSequence()
    {
        // تشغيل صوت الباب
        if(audioSource != null && audioSource.clip != null)
            audioSource.Play();

        // فتح الباب
        if(animator != null)
            animator.SetTrigger("Open");

        // الانتظار مدة فتح الباب
        yield return new WaitForSeconds(openDuration);

        // تشغيل الفيديو
        if(cutsceneObject != null && videoPlayer != null && videoPlayer.clip != null)
        {
            cutsceneObject.SetActive(true); // إظهار الفيديو
            videoPlayer.time = 0;            // بدء من البداية
            videoPlayer.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerNear = false;
    }
}
