using PrimeTween;
using UnityEngine;


public class LevelCompleteTitleView : MonoBehaviour {

    [SerializeField]
    private RectAnimator _titleTopRectAnimator;

    [SerializeField]
    private RectAnimator _titleBottomRectAnimator;

    [Header("Configuration")]
    [SerializeField]
    private float _titleAnimationDuration = 3f;


    public void Show() {

        _titleTopRectAnimator.ElementTransform.localScale = Vector3.one * 0.9f;
        _titleBottomRectAnimator.ElementTransform.localScale = Vector3.one * 0.9f;

        Tween.Custom(
            0f, 1f,
            duration: _titleAnimationDuration,
            ease: Ease.OutCubic,
            onValueChange: (float val) => {

                _titleTopRectAnimator.ElementTransform.localScale = Vector3.Lerp(
                    Vector3.one * 0.9f, Vector3.one, val);

                _titleBottomRectAnimator.ElementTransform.localScale = Vector3.Lerp(
                    Vector3.one * 0.9f, Vector3.one, val);
        });
    }
}
