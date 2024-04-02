using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _instruButton;
    [SerializeField] private Button _returnButton;

    private void Start()
    {
        // Exceptions for not breaking the game due to NullReference
        try{
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        
        catch(Exception e){}

        try{
            _instruButton.onClick.AddListener(IButtonClicked);
        }
        
        catch(Exception e){}

        try{
            _returnButton.onClick.AddListener(BackButtonClicked);
        }
        
        catch(Exception e){}
        
        
        
    }

    public void OnPlayButtonClicked()
    {
        _playButton.interactable = false;
        MenuManager.Instance.HandleGameplay();
    }

    public void IButtonClicked()
    {
        _instruButton.interactable = false;
        MenuManager.Instance.HandleInstruction();
    }

    public void BackButtonClicked()
    {
        _returnButton.interactable = false;
        MenuManager.Instance.HandleMenu();
    }

}
