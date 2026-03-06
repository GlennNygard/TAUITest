using UnityEngine;
using UnityEngine.UI;
using System;


public class HomeScreenTopBarView : MonoBehaviour {

    [SerializeField]
    private Button _settingsButton;

    public event Action OnSettingsSelected;


    void Start() {

        if(_settingsButton != null) {
            _settingsButton.onClick.AddListener(() => OnSettingsSelected?.Invoke());
        }
    }
}
