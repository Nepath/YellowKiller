using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public int depth = -20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + new Vector3(0, 0, depth);
        }
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }
}
