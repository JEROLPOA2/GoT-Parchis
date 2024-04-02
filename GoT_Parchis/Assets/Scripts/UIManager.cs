using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton pattern

    [SerializeField] private GameObject confirmationDialog;
    [SerializeField] private TMP_Text confirmationText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private Button mainMenuButton;

    private Action<bool> confirmationCallback;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Desactivar el diálogo de confirmación y el panel de mensaje al inicio
        confirmationDialog.SetActive(false);
        messagePanel.SetActive(false);
    }

    public void ShowConfirmationDialog(string message, Action<bool> callback)
    {
        confirmationText.text = message;
        confirmationCallback = callback;

        // Activar el diálogo de confirmación
        confirmationDialog.SetActive(true);

        // Asignar acciones a los botones
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(() => OnConfirmationButtonClicked(true));

        noButton.onClick.RemoveAllListeners();
        noButton.onClick.AddListener(() => OnConfirmationButtonClicked(false));
    }

    private void OnConfirmationButtonClicked(bool confirmed)
    {
        confirmationDialog.SetActive(false);

        if (confirmed)
        {
            messageText.text = "GAME OVER";
            // Si se confirma, mostramos el panel de mensaje y desactivamos el botón de volver al menú principal
            messagePanel.SetActive(true);
            mainMenuButton.onClick.AddListener(BackToMainMenu);
        }
        else
        {
            // Si se cancela, llamamos al callback con el valor false
            confirmationCallback?.Invoke(false);
        }
    }

    private void BackToMainMenu()
    {
        MenuManager.Instance.HandleMenu();
    }
}
