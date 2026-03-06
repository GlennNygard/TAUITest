using System;
using UnityEngine;
using UnityEngine.UI;


public class LevelCompleteView : MonoBehaviour {

    [SerializeField]
    private Button _homeButton;

    public event Action OnHomeButtonSelected;

    void Start() {
        
        if(_homeButton != null) {
            _homeButton.onClick.AddListener(()=> OnHomeButtonSelected?.Invoke());

        }
    }
}
