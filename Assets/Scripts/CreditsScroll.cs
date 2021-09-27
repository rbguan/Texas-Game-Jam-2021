using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CreditsScroll : MonoBehaviour
{
    [SerializeField] private RectTransform scroll;
    [SerializeField] private AnimationCurve scrollCurve;
    void Start()
    {
        StartCoroutine(EndScroll());
    }
    private IEnumerator EndScroll()
    {
        yield return scroll.DOMoveY(Screen.height * 2.3f, 27).SetEase(scrollCurve).WaitForCompletion();
        LevelLoadTransitions levelLoadTransition = FindObjectOfType<LevelLoadTransitions>();
        levelLoadTransition.LoadTitleScene();
    }
}
