using System;
using UnityEngine;


public class SettingsPopupController : MonoBehaviour {

    [SerializeField]
    private SettingsPopupView _settingsPopUpView;


    void Start() {

        if(_settingsPopUpView == null) {
            _settingsPopUpView = GetComponentInChildren<SettingsPopupView>();
        }

        // _settingsPopUpView.OnPopupHide += () => {
        // };
    }

    public void Show() {
        _settingsPopUpView.Show();
    }

    public void Hide(bool skipAnimations=false) {
        _settingsPopUpView.Hide(skipAnimations);
    }
}
