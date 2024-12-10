using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogLine : DialogBaseClass
    {
        private TextMeshProUGUI textHolder;
        [Header ("Text Options")] 
        [SerializeField] private string input;
       // [SerializeField]private Color textColor;
        [SerializeField]private float delay;
        [SerializeField] private AudioClip audio;

        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay, audio));
        }
    }
}
