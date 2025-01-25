using Unity.VisualScripting;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem DustEffect;
    [SerializeField] AudioSource audioSource;
    
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    /// 

    private void Start()
    {
        DustEffect.Stop();
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (DustEffect && !DustEffect.isPlaying)
            {
                DustEffect.Play();
            }
            if (other.gameObject.GetComponentInParent<PlayerController>().canMove)
            {
                audioSource.Play();
            } else {
                audioSource.Stop();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (DustEffect && DustEffect.isPlaying)
            {
                DustEffect.Stop();
            }
            audioSource.Stop();
        }
    }
   
}
