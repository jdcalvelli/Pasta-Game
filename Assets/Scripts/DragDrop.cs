﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private Vector2 originalPosition;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Shake mouseToShake;

    private void Awake() 
    {
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        mouseToShake = GetComponent<Shake>();
    }

    private void Start() 
    {
        originalPosition = new Vector3(rectTransform.position.x, rectTransform.position.y, 0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        canvasGroup.alpha = 0.6f;

        mouseToShake.MouseToShake();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        rectTransform.DOMove(new Vector3(originalPosition.x, originalPosition.y, 0), 1f).SetEase(Ease.InOutSine);
    }
}
