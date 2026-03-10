using System;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;


public class LevelCompleteView : MonoBehaviour {

    static readonly int GrowthID = Shader.PropertyToID("_Growth");
    static readonly int ExpandID = Shader.PropertyToID("_Expand");
    static readonly int RadialScaleID = Shader.PropertyToID("_RadialScale");
    static readonly int VignetteSizeID = Shader.PropertyToID("_VignetteSize");

    [SerializeField]
    private Button _homeButton;

    [SerializeField]
    private LevelCompleteTitleView _levelCompleteTitleView;

    [SerializeField]
    private Image _starImage;

    [SerializeField]
    private Image _starCrackleImage;

    [Header("Configuration")]

    [SerializeField]
    private float _starCrackleAnimationDuration = 1f;

    public event Action OnHomeButtonSelected;

    private ParticleSystem[] _particleSystems;

    private RectTransform _starImageRect;
    private Vector2 _initialStarSize;
    private Quaternion _initialStarRotation;

    void Awake() {
        _particleSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: true);
        _starImageRect = _starImage.rectTransform;
        _initialStarSize = _starImageRect.sizeDelta;
        _initialStarRotation = _starImageRect.rotation;
        Hide();
    }

    void Start() {

        if(_homeButton != null) {
            _homeButton.onClick.AddListener(()=> OnHomeButtonSelected?.Invoke());
        }
    }

    public void Show() {

        _starImage.enabled = false;

        _levelCompleteTitleView.Show();

        Material starCrackleMat = _starCrackleImage.material;
        Tween.Custom(0f, 1f, duration: _starCrackleAnimationDuration, ease: Easing.Overshoot(1.2f), onValueChange: (float val) => {
            starCrackleMat.SetFloat(GrowthID, val);
            starCrackleMat.SetFloat(ExpandID, val);
            starCrackleMat.SetFloat(RadialScaleID, Mathf.Lerp(1f, 2f, val));
            starCrackleMat.SetFloat(VignetteSizeID, Mathf.Lerp(0.5f, 1.2f, val));
        }).OnComplete(()=> {
            foreach(ParticleSystem ps in _particleSystems) {
                ps.Play();
            }
        });

        float bounceDuration = 0.4f;

        Tween.Custom(
            0f, 1f,
            duration: bounceDuration,
            startDelay: _starCrackleAnimationDuration,
            ease: Easing.Overshoot(1.2f),
            onValueChange: (float val) => {
                _starImage.enabled = true;
                Color c = _starImage.color;
                _starImage.color = new Color(c.r, c.g, c.b, Mathf.Lerp(0.75f, 1f, val));
                _starImageRect.sizeDelta = _initialStarSize * Mathf.Lerp(0.65f, 1f, val);
                starCrackleMat.SetFloat(VignetteSizeID, Mathf.Lerp(1.2f, 1f, val));

                _starImageRect.Rotate(Vector3.forward, -100);
                _starImageRect.rotation = Quaternion.Lerp(_starImageRect.rotation, _initialStarRotation, val);
        });
    }

    public void Hide() {
        foreach(ParticleSystem ps in _particleSystems) {
            ps.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmittingAndClear);
            // ps.gameObject.SetActive(false);
        }
    }
}
