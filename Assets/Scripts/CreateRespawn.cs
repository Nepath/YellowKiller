using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateRespawn : MonoBehaviour
{
    float nextDrop;
    float interval = 15.0f;

    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject crate;

    void Start()
    {
        nextDrop = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CmdDrop();
    }

    [Command]
    void CmdDrop()
    {
        if (Time.time >= nextDrop)
        {
            var c = Instantiate(crate, GetRandomRespawn(), Quaternion.identity);
            NetworkServer.Spawn(c);

            nextDrop = Time.time + interval;
        }
    }

    public Vector3 GetRandomRespawn()
    {
        float left = leftBorder.transform.position.x;
        float right = rightBorder.transform.position.x;

        float x = Random.Range(left, right);
        float y = this.transform.position.y;

        Vector3 pos = new Vector3(x, y, 1f);

        return pos;
    }
}
