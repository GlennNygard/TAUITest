using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PrimeTween;


[RequireComponent(typeof(LayoutElement))]
[RequireComponent(typeof(Button))]
public class HomeScreenBottomBarItem : MonoBehaviour {

    /*
    These could be made inspector variables or be read
    from somewhere else, but since we don't have a great system
    for setting this up yet (and these are individual item views an not a managing view),
    I think it's easier to leave them as constants for now.
    */
    private const float ANIMATION_DURATION = 0.25f;

    private const float ACTIVE_WIDTH_MULTIPLIER = 2f;

    [SerializeField]
    private HomeScreenBottomBarItemData _itemData;

    [SerializeField]
    private TextMeshProUGUI _mainItemText;

    [SerializeField]
    private Image _icon;

    [SerializeField]
    private Image _background;

    [HideInInspector]
    public Button MainButton;

    public string ButtonLabel {
        get {return _mainItemText.text;}
    }


    public bool Locked {
        get {
            return _itemData.Locked;
        }
    }


    private RectTransform _iconRectTransform;
    private LayoutElement _layoutElement;
    private LayoutElement _textLayoutElement;
    private float _initialWidth;
    private float _initialTextHeight;


    // Tweens.
    private Tween _backgroundTween;
    private Tween _textTween;
    private Tween _widthTween;
    private Tween _iconTween;


    void Awake() {

        MainButton = GetComponent<Button>();

        _layoutElement = GetComponent<LayoutElement>();
        _initialWidth = _layoutElement.preferredWidth;

        _iconRectTransform = _icon.GetComponent<RectTransform>();

        if(!_itemData.LocString.IsEmpty) {
            _itemData.LocString.GetLocalizedStringAsync().Completed += op => {
                _mainItemText.text = op.Result;};
        }
        _textLayoutElement = _mainItemText.gameObject.GetComponent<LayoutElement>();
        _initialTextHeight = _textLayoutElement.preferredHeight;

        _icon.sprite = _itemData.MainIcon;

        Deactivate();
    }

    public void LockedClickEffect() {
        _iconTween.Stop();
        _iconTween = Tween.Custom(0f, 1f, duration: 0.1f, cycles: 2, cycleMode: CycleMode.Yoyo, onValueChange: (float val)=> {
            _iconRectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.9f, val);
        });
    }

    public void Activate() {
        _mainItemText.enabled = true;

        _textTween.Stop();
        _textTween = Tween.Custom(0f, 1f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
            _textLayoutElement.preferredHeight = val * _initialTextHeight;
        });

        if(_background != null) {
            _background.enabled = true;
            _backgroundTween.Stop();
            _backgroundTween = Tween.Custom(_background.color.a, 1f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
                _background.color = new Color(
                    _background.color.r, _background.color.g, _background.color.b, val);
            });
        }

        _widthTween.Stop();
        _widthTween = Tween.Custom(_initialWidth, _initialWidth * ACTIVE_WIDTH_MULTIPLIER, duration: ANIMATION_DURATION, ease: Ease.OutQuad, onValueChange: (float val)=> {
            _layoutElement.preferredWidth = val;
        });

        // Idle icon animation.
        _iconTween.Stop();
        _iconTween = Tween.Custom(0f, 1f, duration: 1f, cycles: -1, cycleMode: CycleMode.Yoyo, onValueChange: (float val)=> {
            _iconRectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 1.05f, val);
        });
    }

    public void Deactivate() {
        _mainItemText.enabled = false;

        _textTween.Stop();
        _textTween = Tween.Custom(1f, 0f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
            _textLayoutElement.preferredHeight = _initialTextHeight* val;
        });

        if(_background != null) {
            _backgroundTween.Stop();
            _backgroundTween = Tween.Custom(_background.color.a, 0f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
                _background.color = new Color(
                    _background.color.r, _background.color.g, _background.color.b, val);
            }).OnComplete(() => {
                _background.enabled = false;});
        }

        _widthTween.Stop();
        _widthTween = Tween.Custom(_initialWidth * ACTIVE_WIDTH_MULTIPLIER, _initialWidth, duration: ANIMATION_DURATION * 0.5f, onValueChange: (float val)=> {
            _layoutElement.preferredWidth = val;
        });

        _iconTween.Stop();
    }
}
