using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // start is called before the first frame is updated
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned in FollowPlayer script.");
        }
    }

    // update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}