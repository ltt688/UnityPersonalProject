using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 250.0f;
    //adjust value to tune flying
    public float gravityModifier = 1.0f;
    //not working
    public Animator flyingAnimation;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Physics.gravity *= gravityModifier;
        flyingAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown("up");
        int touch = Input.touchCount;
        if (up == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            //flyingAnimation.Play("Flying");
        }
        if (touch > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
                //flyingAnimation.Play("Flying");
            }
        }
    }

}
