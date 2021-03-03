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
        int touch = Input.touchCount;
        if (up == true || touch >0)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

}
