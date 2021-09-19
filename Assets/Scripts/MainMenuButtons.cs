using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hover, click;

    public void OnClickPlay()
    {
        // GameManager.Instance.Reset();
    }

    public void OnClickHowToPlay()
    {
        // SceneManager.LoadScene( "HowToPlay" );
    }

    public void OnClickQuit()
    {
        // Application.Quit();
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
