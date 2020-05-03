using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour
{
    [SerializeField] private Text letterText;

    private string textBuffer = "";

    private void OnEnable()
    {
        Collectable.OnCollected += OnCollectedHandler;
    }

    void Start()
    {
        letterText.text = "Game Start!";
    }

    private void OnCollectedHandler(string letter)
    {
        textBuffer += letter;
        letterText.text = textBuffer;
    }


}
