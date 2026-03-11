using PrimeTween;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;


public class LevelCompleteTitleView : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _titleTopText;

    [SerializeField]
    private TextMeshProUGUI _titleBottomText;

    [Header("Localisation")]

    [SerializeField]
    private LocalizedString _titleTopLS;

    [SerializeField]
    private LocalizedString _titleBottomLS;

    [Header("Configuration")]
    [SerializeField]
    private float _titleAnimationDuration = 3f;


    private void Awake() {
        _titleTopLS.GetLocalizedStringAsync().Completed += op => {
            _titleTopText.text = op.Result;};
        _titleBottomLS.GetLocalizedStringAsync().Completed += op => {
            _titleBottomText.text = op.Result;};
    }


    public void Show() {

        _titleTopText.transform.localScale = Vector3.one * 0.9f;
        _titleBottomText.transform.localScale = Vector3.one * 0.9f;

        Tween.Custom(
            0f, 1f,
            duration: _titleAnimationDuration,
            ease: Ease.OutCubic,
            onValueChange: (float val) => {

                _titleTopText.transform.localScale = Vector3.Lerp(
                    Vector3.one * 0.9f, Vector3.one, val);

                _titleBottomText.transform.localScale = Vector3.Lerp(
                    Vector3.one * 0.9f, Vector3.one, val);
        });
    }
}
