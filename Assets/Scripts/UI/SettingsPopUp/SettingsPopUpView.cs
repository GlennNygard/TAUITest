using UnityEngine;
using UnityEngine.UI;
using System;


public class SettingsPopUpView : MonoBehaviour {

    [SerializeField]
    private Button _exitButton;

    public event Action OnExitClicked;

    void Start() {

        if(_exitButton != null) {
            _exitButton.onClick.AddListener(() => OnExitClicked?.Invoke());
        }
        else {
            Debug.LogWarning("Settings exit button has not been assigned.");
        }
    }
}
