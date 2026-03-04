using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PrimeTween;


[RequireComponent(typeof(LayoutElement))]
[RequireComponent(typeof(Button))]
public class BottomBarItem : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _mainItemText;

    [SerializeField]
    private Image _background;

    [HideInInspector]
    public Button MainButton;


    private LayoutElement _layoutElement;
    private float _initialWidth;

    void Awake() {

        MainButton = GetComponent<Button>();

        _layoutElement = GetComponent<LayoutElement>();
        _initialWidth = _layoutElement.preferredWidth;

        Deactivate();
    }

    public void Activate() {
        if(_mainItemText != null) {
            _mainItemText.enabled = true;
        }
        if(_background != null) {
            _background.enabled = true;
            Tween.Custom(_background.color.a, 1f, duration: 0f, onValueChange: (float val)=> {
                _background.color = new Color(
                    _background.color.r, _background.color.g, _background.color.b, val);
            });
        }
        _layoutElement.preferredWidth = _initialWidth * 1.75f;
    }

    public void Deactivate() {
        if(_mainItemText != null) {
            _mainItemText.enabled = false;
        }
        //if(_background != null) {
        //    _background.enabled = false;
        //}
        _layoutElement.preferredWidth = _initialWidth;
        Tween.Custom(_background.color.a, 0f, duration: 0f, onValueChange: (float val)=> {
            _background.color = new Color(
                _background.color.r, _background.color.g, _background.color.b, val);
        });
    }
}
