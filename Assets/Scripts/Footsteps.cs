using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public void PlayFootstep()
    {
        if (AudioManager.Current)
            AudioManager.Current.PlayFootstepSFX();
    }
}
