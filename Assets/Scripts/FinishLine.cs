using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float finishDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barry")
        {
            finishEffect.Play();
            Invoke("LoadLevel1", finishDelay);
            Debug.Log("Win");

        }


    }

    private void LoadLevel1()
    {   
        SceneManager.LoadScene(0);

    }
}
