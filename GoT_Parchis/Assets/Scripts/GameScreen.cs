using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{

    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_InputField _inputField1;
    [SerializeField] private TMP_InputField _inputField2;
    [SerializeField] private TMP_InputField _inputField3;
    [SerializeField] private TMP_InputField _inputField4;

    
    private void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        Information.N_Jugadores = int.Parse(_inputField1.text);
        Information.N_Fichas = int.Parse(_inputField2.text);
        Information.N_Dados = int.Parse(_inputField3.text);
        Information.N_Caras = int.Parse(_inputField4.text);
        //Debug.Log(inputValue1);
        _startButton.interactable = false;
        MenuManager.Instance.HandleGameplay();
    }
}
