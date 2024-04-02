using UnityEngine;
using UnityEngine.UI;

public class abandonar : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    public void OnPlayButtonClicked()
    {
        _playButton.interactable = false;
        UIManager.Instance.ShowConfirmationDialog("¿Está seguro de que desea abandonar? La partida no se guardará.", ConfirmarAbandono);
    }

    private void ConfirmarAbandono(bool confirmado)
    {
        if (confirmado)
        {
            MenuManager.Instance.HandleMenu();
        }
        else
        {
            _playButton.interactable = true;
        }
    }
}
