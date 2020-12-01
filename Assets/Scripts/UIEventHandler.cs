using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEventHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI translatedTextArea;
    public GameObject clear;
    public GameObject repeat;
    public GameObject textArea;

    private float waitTime = 2.5f; // Time it take to complete UnitAnimation
    private string translatedText;
    private bool hiden;

    AudioSource         audioSource;
    AudioRecorder       audioRecorder;
    TranslationHandler  translationHandler;
    AnimationMapper     animationMapper;
    AnimationController animationController;
    Result              result;  // Final Result

    bool isRecording = false;

    void Start()
    {
        audioSource         = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        audioRecorder       = GameObject.Find("_Manager").GetComponent<AudioRecorder>();
        animationController = GameObject.Find("_Manager").GetComponent<AnimationController>();
        translationHandler  = GameObject.Find("_Manager").GetComponent<TranslationHandler>();
        animationMapper     = GameObject.Find("_Manager").GetComponent<AnimationMapper>();

        Hide();


        // // //Test
        // // string response = "ሀ";
        // // string response = "ሀሁሂሃሄህሆ";
        // string response = "የጉግል ነፃ አገልግሎት በእንግሊዝኛ እና በሌሎች ቋንቋዎች መካከል ቃላትን ሀረጎችን እና የድር ገጾችን በቅጽበት ይተረጉማል";

        // Animate(response);
    }
    public void Animate(string response)
    {
        result = animationMapper.mapper(response, inputField.text);
        animationController.DisplayResult(result, waitTime);      
    }

    public async void RecordAudio()
    {

        if (isRecording)
        {
            byte[] audio_data = audioRecorder.StopRecording();
            Show();
            // Debug.Log( audio_data.GetType());
            string res = await AppHttpClient.GetTranslatedSentenceFromAudio(audio_data);
            Debug.Log(res);
        }
        else
        {
            bool status = audioRecorder.Record(audioSource);
            Debug.Log(status);
            isRecording = true;
        }

    }

    public void Repeat()
    {
        Animate(this.translatedText);
    }

    public void Clear()
    {
        Hide();
    	inputField.text = "";
        this.translatedText = "";
    }

    public void InsertText()
    {
        Show();
        this.translatedText = inputField.text;
        translatedTextArea.text = this.translatedText;
        Animate(this.translatedText);
    }

    public void Show()
    {
    	textArea.SetActive(true);
    	clear.SetActive(true);
    	repeat.SetActive(true);
    	hiden = false;
    }

    public void Hide()
    {
    	textArea.SetActive(false);
    	clear.SetActive(false);
    	repeat.SetActive(false);
    	hiden = true;
    }

    public void EndRecording()
    {
        byte[] data = audioRecorder.StopRecording();
        string type = "audio";
        SendData(type, data);
    }

    public void RecieveText()
    {
    }

    public void SendData(string type, byte[] data)
    {
        string response;
        if (type == "audio")
        {
            response = translationHandler.sendAudio(data);
        }
        else
        {
            response = translationHandler.SendText(data);
        }

        Animate(response);
    }

    public void Connect(string type, byte[] data)
    {

    }

}
