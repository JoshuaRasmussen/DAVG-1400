using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        // repeats scenery
        if (transform.position.z < (startPos.z - (repeatWidth.z / 2)))
        {
            transform.position = startPos;
        }
    }
}
