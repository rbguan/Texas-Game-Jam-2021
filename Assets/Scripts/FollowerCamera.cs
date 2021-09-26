// Smooth towards the target

using UnityEngine;
using System.Collections;

public class FollowerCamera : Singleton<FollowerCamera>
{
    public Transform target;
    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 goalPos = target.position;
            goalPos += new Vector3(xOffset, yOffset, zOffset);
            transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
        }
    }

    public static void SnapToPlayer()
    {
        Current.transform.position = PlayerInfo.playerObject.transform.position + new Vector3(0, 12.48f, -2.03f);
    }
}