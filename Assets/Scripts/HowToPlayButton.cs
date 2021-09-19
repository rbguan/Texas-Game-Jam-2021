using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButton : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hover, click;

    public void OnClick()
    {
        // SceneManager.LoadScene( "TitleScreen" );
    }

    public void OnHoverSFX()
    {
        source.PlayOneShot(hover);
    }

    public void OnClickSFX()
    {
        source.PlayOneShot(click);
    }
}
