using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 200.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown("up");
        if (up == true || Input.touches[0].phase == TouchPhase.Began)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

}
