using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public void PlayFootstep()
    {
        AudioManager.Current.PlayFootstepSFX();
    }
}
