using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;
    SurfaceEffector2D surfaceEffector2D;
    public bool canMove = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove){
            RotatePlayer();
            RespondToBoost();
        }   
    }

    public void DisableMovement(){
        StartCoroutine(DisableControllers());
    }

    private IEnumerator DisableControllers(){
        canMove = false;
        surfaceEffector2D.speed = 0;
        var rigidbody = GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(0.5f);
        rigidbody.simulated = false;
        Debug.Log("DisableControllers");
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }
}
