using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadTransitions : MonoBehaviour
{
    [SerializeField] private Animator TransitionAnimator;
    [SerializeField] private float TransitionAnimationTime = 1f;
    [SerializeField] private string HowToPlayScene = "";
    [SerializeField] private string PlayScene = "";
    [SerializeField] private string TitleScene = "";
    [SerializeField] private string WinScene = "";
    [SerializeField] private string LoseScene = "";
    [SerializeField] private string StatsScene = "";
    [SerializeField] private string CreditsScene = "";

    public void LoadHowToPlayScene()
    {
        StartCoroutine(LoadHowToPlay());
    }

    private IEnumerator LoadHowToPlay()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(HowToPlayScene);
    }
    public void LoadTitleScene()
    {
        StartCoroutine(LoadTitle());
    }

    private IEnumerator LoadTitle()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(TitleScene);
        // GameManager.Instance.PlayMenuMusic();
    }

    public void LoadPlayScene()
    {
        StartCoroutine(LoadPlay());
    }

    private IEnumerator LoadPlay()
    {
        // GameManager.Instance.StopCurrentMusic();
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(PlayScene);
        // GameManager.Instance.PlayGameMusic();
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    private IEnumerator QuitGame()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        Application.Quit();
    }

    public void Win()
    {
        StartCoroutine(LoadWin());
    }

    private IEnumerator LoadWin()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(WinScene);
    }

    public void Lose()
    {
        StartCoroutine(LoadLose());
    }

    private IEnumerator LoadLose()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(LoseScene);//LOSE
    }

    public void Stats()
    {
        StartCoroutine(LoadStats());
    }

    private IEnumerator LoadStats()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(StatsScene);
    }

    public void Credits()
    {
        StartCoroutine(LoadCredits());
    }

    private IEnumerator LoadCredits()
    {
        TransitionAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionAnimationTime);
        SceneManager.LoadScene(CreditsScene);
    }
}
