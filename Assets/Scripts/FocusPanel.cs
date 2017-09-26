﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FocusPanel : MonoBehaviour, IPointerDownHandler {

    private RectTransform panel;

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    } 

    public void OnPointerDown(PointerEventData data)
    {
        panel.SetAsLastSibling();
    }

}
