using UnityEngine;
using UnityEngine.UI;
using System;


public class HomeScreenDebugRowView : MonoBehaviour {

    [SerializeField]
    private Button _levelCompleteButton;

    public event Action OnLevelCompleteSelected;


    void Awake() {

        if(_levelCompleteButton != null) {
            _levelCompleteButton.onClick.AddListener(() => OnLevelCompleteSelected?.Invoke());
        }
    }
}
