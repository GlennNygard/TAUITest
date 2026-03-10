using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PrimeTween;


[RequireComponent(typeof(LayoutElement))]
[RequireComponent(typeof(Button))]
public class HomeScreenBottomBarItem : MonoBehaviour {

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


    public bool Locked {
        get {
            return _itemData.Locked;
        }
    }


    private LayoutElement _layoutElement;
    private LayoutElement _iconLayoutElement;
    private LayoutElement _textLayoutElement;
    private float _initialWidth;
    private float _initialIconWidth;

    private float _initialTextHeight;


    // Tweens.
    private Tween _mainTween;


    void Awake() {

        MainButton = GetComponent<Button>();

        _layoutElement = GetComponent<LayoutElement>();
        _initialWidth = _layoutElement.preferredWidth;

        _iconLayoutElement = _icon.GetComponent<LayoutElement>();
        if(_iconLayoutElement != null) {
            _initialIconWidth = _iconLayoutElement.minWidth;
        }

        _mainItemText.text = _itemData.MainText;
        _textLayoutElement = _mainItemText.gameObject.GetComponent<LayoutElement>();
        _initialTextHeight = _textLayoutElement.preferredHeight;

        _icon.sprite = _itemData.MainIcon;

        Deactivate();
    }

    public void Activate() {
        _mainItemText.enabled = true;

        Tween.Custom(0f, 1f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
            _textLayoutElement.preferredHeight = val * _initialTextHeight;
        });

        if(_background != null) {
            _background.enabled = true;
            _mainTween.Stop();
            _mainTween = Tween.Custom(_background.color.a, 1f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
                _background.color = new Color(
                    _background.color.r, _background.color.g, _background.color.b, val);
                // _layoutElement.preferredWidth = val * _initialWidth * ACTIVE_WIDTH_MULTIPLIER;
            });
        }
        if(_iconLayoutElement != null) {
            Tween.UIMinWidth(
                _iconLayoutElement,
                new TweenSettings<float>(_initialIconWidth, _initialIconWidth * 1.2f, ease: Ease.InOutBounce));
        }

        Tween.Custom(_initialWidth, _initialWidth * ACTIVE_WIDTH_MULTIPLIER, duration: ANIMATION_DURATION, ease: Ease.OutQuad, onValueChange: (float val)=> {
            _layoutElement.preferredWidth = val;
        });
    }

    public void Deactivate() {
        _mainItemText.enabled = false;

        Tween.Custom(1f, 0f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
            _textLayoutElement.preferredHeight = val * _initialTextHeight;
        });

        if(_background != null) {
            _mainTween.Stop();
            _mainTween = Tween.Custom(_background.color.a, 0f, duration: ANIMATION_DURATION, onValueChange: (float val)=> {
                _background.color = new Color(
                    _background.color.r, _background.color.g, _background.color.b, val);
                // _layoutElement.preferredWidth = val * _initialWidth * ACTIVE_WIDTH_MULTIPLIER;
            }).OnComplete(() => {
                _background.enabled = false;});
        }

        Tween.Custom(_initialWidth * ACTIVE_WIDTH_MULTIPLIER, _initialWidth, duration: ANIMATION_DURATION * 0.5f, onValueChange: (float val)=> {
            _layoutElement.preferredWidth = val;
        });
    }
}
