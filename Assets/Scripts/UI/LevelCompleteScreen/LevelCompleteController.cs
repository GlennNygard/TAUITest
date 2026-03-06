using System;
using UnityEngine;


[RequireComponent(typeof(Canvas))]
public class LevelCompleteController : MonoBehaviour {

    [SerializeField]
    private LevelCompleteView _levelCompleteView;

    private Canvas _canvas;

    void Start() {

        _canvas = GetComponent<Canvas>();

        if(_levelCompleteView == null) {
            _levelCompleteView = GetComponentInChildren<LevelCompleteView>();
        }

        _levelCompleteView.OnHomeButtonSelected += ()=> {
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
