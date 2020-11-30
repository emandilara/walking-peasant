using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Navigation : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start() {
        actions.Add("go ahead", Forward);
        actions.Add("go back", Back);
        actions.Add("turn right", TurnRight);
        actions.Add("turn left", TurnLeft);

        string[] keywords = {"go ahead", "go back", "turn right", "turn left"};

        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech; 
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward() {
        transform.Translate(0,0,-1);
    }

    private void Back() {
        transform.Translate(0,0,1);
    }

    private void TurnRight() {
        transform.Rotate(0,90,0);
    }

    private void TurnLeft() {
        transform.Rotate(0,-90,0);
    }

    // Update is called once per frame
    void Update() {}
}
