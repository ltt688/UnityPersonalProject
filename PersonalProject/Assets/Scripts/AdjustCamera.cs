using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    public bool maintainWidth = true;

    private float defaultWidth;
    //private float defaultHeight;

    //private Vector3 CameraPos;

    // Start is called before the first frame update
    void Start()
    {
        //CameraPos = Camera.main.transform.position;

        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        //defaultHeight = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (maintainWidth)
        {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;

            //Camera.main.transform.position = new Vector3(CameraPos.x, 1 * (defaultHeight - Camera.main.orthographicSize), CameraPos.z);
        }
        else
        {

        }
    }
}
