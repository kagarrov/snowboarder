using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;
    
    
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barry")
        {
            other.GetComponentInParent<PlayerController>().DisableMovement();
            crashEffect.Play();
            Invoke("LoadLevel1", crashDelay);
            var audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(crashSound);
            Debug.Log("Crash");
        }
    }

    private void LoadLevel1()
    {
        SceneManager.LoadScene(0);
    }
}

