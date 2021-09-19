using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuButtonTweening : MonoBehaviour
{
    [SerializeField][Range(0,2)] private float ButtonHoverScale;
    [SerializeField][Range(0,2)] private float ButtonHoverScaleTime;
    [SerializeField][Range(0,2)] private float ButtonDropdownTime;
    [SerializeField][Range(0,2)] private float ButtonDropdownWaitTime;
    [SerializeField][Range(0,2)] private float TimeGapBetweenEachDrop;
    [SerializeField] private AnimationCurve ButtonDropdownCurve;
    [SerializeField][Range(0,1)] private float ButtonDropdownSquashFactor;
    [SerializeField] private AnimationCurve ButtonDropdownScaleCurve;
    [SerializeField][Range(0,1)] private float TitleY;
    [SerializeField][Range(0,1)] private float PlayButtonY;
    [SerializeField][Range(0,1)] private float HowToPlayButtonY;
    [SerializeField][Range(0,1)] private float QuitButtonY;
    [SerializeField] private AnimationCurve ButtonHoverScaleCurve;
    [SerializeField] private RectTransform Title;
    [SerializeField] private RectTransform PlayButton;
    [SerializeField] private RectTransform HowToPlayButton;
    [SerializeField] private RectTransform QuitButton;
    void Start()
    {
        StartCoroutine(LoadInMenuSequence());
    }

    void Update()
    {
        
    }

    public void OnHoverEnterTween(Button button)
    {
        button.GetComponent<RectTransform>().DOScale(ButtonHoverScale,ButtonHoverScaleTime).SetEase(ButtonHoverScaleCurve);
    }

    public void OnHoverExitTween(Button button)
    {
        button.GetComponent<RectTransform>().DOScale(1,ButtonHoverScaleTime).SetEase(ButtonHoverScaleCurve);
    }

    private IEnumerator LoadInMenuSequence()
    {
        Sequence QuitButtonSequence = DOTween.Sequence();
        QuitButtonSequence.AppendInterval(TimeGapBetweenEachDrop);
        QuitButtonSequence.Append(QuitButton.DOMoveY(Screen.height * QuitButtonY, ButtonDropdownTime).SetEase(ButtonDropdownCurve));
        QuitButtonSequence.Join(QuitButton.DOScaleY(ButtonDropdownSquashFactor, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));

        Sequence HowToPlayButtonSequence = DOTween.Sequence();
        HowToPlayButtonSequence.AppendInterval(TimeGapBetweenEachDrop * 2);
        HowToPlayButtonSequence.Append(HowToPlayButton.DOMoveY(Screen.height * HowToPlayButtonY, ButtonDropdownTime).SetEase(ButtonDropdownCurve));
        HowToPlayButtonSequence.Join(HowToPlayButton.DOScaleY(ButtonDropdownSquashFactor, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));

        Sequence PlayButtonSequence = DOTween.Sequence();
        PlayButtonSequence.AppendInterval(TimeGapBetweenEachDrop * 3);
        PlayButtonSequence.Append(PlayButton.DOMoveY(Screen.height * PlayButtonY, ButtonDropdownTime).SetEase(ButtonDropdownCurve));
        PlayButtonSequence.Join(PlayButton.DOScaleY(ButtonDropdownSquashFactor, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));
        
        Sequence TitleSequence = DOTween.Sequence();
        TitleSequence.AppendInterval(TimeGapBetweenEachDrop * 4);
        TitleSequence.Append(Title.DOMoveY(Screen.height * TitleY, ButtonDropdownTime).SetEase(ButtonDropdownCurve));
        TitleSequence.Join(Title.DOScaleY(ButtonDropdownSquashFactor, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));    
        
        Sequence LoadSequence = DOTween.Sequence();
        LoadSequence.AppendInterval(ButtonDropdownWaitTime);
        LoadSequence.Append(QuitButtonSequence);
        LoadSequence.Join(HowToPlayButtonSequence);
        LoadSequence.Join(PlayButtonSequence);
        LoadSequence.Join(TitleSequence);
        LoadSequence.Play();
        yield return null;
    }
}
