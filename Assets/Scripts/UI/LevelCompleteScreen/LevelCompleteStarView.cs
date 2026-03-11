using System;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class LevelCompleteStarView : MonoBehaviour {

    static readonly int GrowthID = Shader.PropertyToID("_Growth");
    static readonly int ExpandID = Shader.PropertyToID("_Expand");
    static readonly int RadialScaleID = Shader.PropertyToID("_RadialScale");
    static readonly int VignetteSizeID = Shader.PropertyToID("_VignetteSize");


    [SerializeField]
    private Image _starImage;

    [SerializeField]
    private Image _starCrackleImage;

    [Header("Configuration")]

    [SerializeField]
    private float _starCrackleAnimationDuration = 0.3f;

    [SerializeField]
    private float _starIntroAnimationDuration = 0.4f;

    private RectTransform _starImageRect;
    private Vector2 _initialStarSize;
    private Quaternion _initialStarRotation;
    private Material _starCrackleMat;


    void Awake() {
        _starImageRect = _starImage.rectTransform;
        _initialStarSize = _starImageRect.sizeDelta;
        _initialStarRotation = _starImageRect.rotation;
        _starCrackleMat = _starCrackleImage.material;
    }

    public void Show(Action onComplete) {

        _starImage.enabled = false;
        Tween.Custom(0.2f, 1f, duration: _starCrackleAnimationDuration, ease: Easing.Overshoot(1.2f), onValueChange: (float val) => {
            _starCrackleMat.SetFloat(GrowthID, Mathf.Min(val, 1f));
            _starCrackleMat.SetFloat(ExpandID, Mathf.Min(val, 1f));
            _starCrackleMat.SetFloat(RadialScaleID, Mathf.Lerp(1f, 2f, val));
            _starCrackleMat.SetFloat(VignetteSizeID, Mathf.Lerp(0.5f, 1.2f, val));
        }).OnComplete(()=> {
            onComplete.Invoke();
            _starImage.enabled = true;
        });

        _starImageRect.Rotate(Vector3.forward, -100);
        Quaternion starImageStartRot = _starImageRect.rotation;
        Color starImageStartColor = _starImage.color;
        Tween.Custom(
            0f, 1f,
            duration: _starIntroAnimationDuration,
            startDelay: _starCrackleAnimationDuration,
            ease: Easing.Overshoot(1.2f),
            onValueChange: (float val) => {
                _starImage.color = new Color(
                    starImageStartColor.r, starImageStartColor.g, starImageStartColor.b,
                    Mathf.Lerp(0.75f, 1f, val));
                _starImageRect.sizeDelta = _initialStarSize * Mathf.Lerp(0.65f, 1f, val);
                _starCrackleMat.SetFloat(VignetteSizeID, Mathf.Lerp(1.2f, 1f, val));

                _starImageRect.rotation = Quaternion.Lerp(starImageStartRot, _initialStarRotation, val);
        });
    }
}
