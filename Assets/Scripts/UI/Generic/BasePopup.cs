using UnityEngine;
using UnityEngine.UI;
using System;
using PrimeTween;


[RequireComponent(typeof(Canvas))]
public class BasePopup : MonoBehaviour {

    private const float ANIMATION_DURATION = 0.25f;

    [SerializeField]
    private Button _exitButton;

    public event Action OnPopupShow;
    public event Action OnPopupHide;

    protected Canvas _canvas;
    protected CanvasGroup _canvasGroup;


    void Awake() {
        _canvas = GetComponent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start() {

        if(_exitButton != null) {
            _exitButton.onClick.AddListener(() => Hide());
        }
        else {
            Debug.LogWarning("Popup exit button has not been assigned.");
        }
    }
    

    public virtual void Show() {
        _canvas.enabled = true;
        if(_canvasGroup != null) {
            Tween.Alpha(_canvasGroup, new TweenSettings<float>(startValue: 0f, endValue: 1f, duration: ANIMATION_DURATION));
        }
        OnPopupShow?.Invoke();
    }

    public virtual void Hide(bool skipAnimations=false) {
        if(!skipAnimations && _canvasGroup != null) {
            Tween.Alpha(
                _canvasGroup,
                new TweenSettings<float>(startValue: 1f, endValue: 0f, duration: ANIMATION_DURATION)).OnComplete(() => {
                    _canvas.enabled = false;
                });
        }
        else {
            _canvas.enabled = false;
        }
        OnPopupHide?.Invoke();
    }

}
