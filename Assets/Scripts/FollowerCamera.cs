// Smooth towards the target

using UnityEngine;
using System.Collections;

public class FollowerCamera : Singleton<FollowerCamera>
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 goalPos = target.position;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }

    public static void SnapToPlayer()
    {
        Current.transform.position = PlayerInfo.playerObject.transform.position + new Vector3(0, 12.48f, -2.03f);
    }
}