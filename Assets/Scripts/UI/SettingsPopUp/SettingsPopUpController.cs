using System;
using UnityEngine;


[RequireComponent(typeof(Canvas))]
public class SettingsPopUpController : MonoBehaviour {

    [SerializeField]
    private SettingsPopUpView _settingsPopUpView;

    private Canvas _canvas;


    void Start() {
        _canvas = GetComponent<Canvas>();

        if(_settingsPopUpView == null) {
            _settingsPopUpView = GetComponentInChildren<SettingsPopUpView>();
        }

        _settingsPopUpView.OnExitClicked += () => {
            Hide();
        };
    }

    public void Show() {
        _canvas.enabled = true;
    }

    public void Hide() {
        _canvas.enabled = false;
    }
}
