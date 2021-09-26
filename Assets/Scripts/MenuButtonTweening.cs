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
    [SerializeField][Range(0,2)] private float ButtonPopInScale;
    [SerializeField][Range(0,2)] private float TitlePopInScale;
    [SerializeField] private AnimationCurve ButtonDropdownScaleCurve;
    [SerializeField] private AnimationCurve TitleDropdownScaleCurve;
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
        // QuitButtonSequence.Append(QuitButton.DOMoveY(Screen.height * QuitButtonY, ButtonDropdownTime).SetEase(ButtonDropdownCurve));
        QuitButtonSequence.Join(QuitButton.DOScale(ButtonPopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));
        QuitButton.GetComponent<Image>().DOFade(1, ButtonDropdownTime);

        Sequence HowToPlayButtonSequence = DOTween.Sequence();
        HowToPlayButtonSequence.AppendInterval(TimeGapBetweenEachDrop * 2);
        HowToPlayButtonSequence.Append(HowToPlayButton.DOScale(ButtonPopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));
        QuitButton.GetComponent<Image>().DOFade(1, ButtonDropdownTime);
        // HowToPlayButtonSequence.Join(HowToPlayButton.DOScaleY(ButtonPopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));

        Sequence PlayButtonSequence = DOTween.Sequence();
        PlayButtonSequence.AppendInterval(TimeGapBetweenEachDrop * 3);
        PlayButtonSequence.Append(PlayButton.DOScale(ButtonPopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));
        // PlayButtonSequence.Join(PlayButton.DOScaleY(ButtonPopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));
        QuitButton.GetComponent<Image>().DOFade(1, ButtonDropdownTime);
        
        Sequence TitleSequence = DOTween.Sequence();
        TitleSequence.AppendInterval(TimeGapBetweenEachDrop * 4);
        TitleSequence.Append(Title.DOScale(TitlePopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve));
        // TitleSequence.Join(Title.DOScaleY(ButtonPopInScale, ButtonDropdownTime).SetEase(ButtonDropdownScaleCurve)); 
        QuitButton.GetComponent<Image>().DOFade(1, ButtonDropdownTime);
        
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
