using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public Transform leftAnchor;
    public Transform rightAnchor;
    public Transform upAnchor;
    public Transform downAnchor;
    public GameObject leftAttachment;
    public GameObject rightAttachment;
    public GameObject upAttachment;
    public GameObject downAttachment;

    private void Start()
    {
        
    }

    public bool HasAvailableAnchors() => 
        (leftAnchor && !leftAttachment) || (rightAnchor && !rightAttachment) || (upAnchor && !upAttachment) || (downAnchor && !downAttachment);

    public bool HasAnchor(AnchorDirection direction)
    {
        if (direction == AnchorDirection.Up)
            return upAnchor;
        if (direction == AnchorDirection.Down)
            return downAnchor;
        if (direction == AnchorDirection.Left)
            return leftAnchor;
        if (direction == AnchorDirection.Right)
            return rightAnchor;
        return false;
    }

    private bool HasAttachment(AnchorDirection direction)
    {
        if (direction == AnchorDirection.Up)
            return upAttachment;
        if (direction == AnchorDirection.Down)
            return downAttachment;
        if (direction == AnchorDirection.Left)
            return leftAttachment;
        if (direction == AnchorDirection.Right)
            return rightAttachment;
        return false;
    }

    public bool HasAvailableAnchor(AnchorDirection direction)
    {
        if (HasAnchor(direction) && !HasAttachment(direction))
            return true;
        return false;
    }
}
