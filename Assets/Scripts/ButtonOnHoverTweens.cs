using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonOnHoverTweens : MonoBehaviour
{
    [SerializeField][Range(0,2)] private float ButtonHoverScale;
    [SerializeField][Range(0,2)] private float ButtonHoverScaleTime;
    [SerializeField] private RectTransform Button;
    [SerializeField] private AnimationCurve ButtonHoverScaleCurve;

    public void OnHoverEnterTween()
    {
        Button.DOScale(ButtonHoverScale,ButtonHoverScaleTime).SetEase(ButtonHoverScaleCurve);
    }

    public void OnHoverExitTween()
    {
        Button.DOScale(1,ButtonHoverScaleTime).SetEase(ButtonHoverScaleCurve);
    }

}
