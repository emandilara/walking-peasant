using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start() {
        actions.Add("go forward", Forward);
        actions.Add("go up", Up);
        actions.Add("go down", Down);
        actions.Add("go back", Back);

        string[] keywords = {"go forward", "go up", "go down", "go back"};

        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech; 
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward() {
        transform.Translate(1,0,0);
    }

    private void Back() {
        transform.Translate(-1,0,0);
    }
    
    private void Up() {
        transform.Translate(0,1,0);
    }
      
    private void Down() {
        transform.Translate(0,-1,0);
    }

    // Update is called once per frame
    void Update() {}
}
