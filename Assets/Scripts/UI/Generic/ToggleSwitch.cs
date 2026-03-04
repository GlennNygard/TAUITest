using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Toggle))]
public class ToggleSwitch : MonoBehaviour {

    [SerializeField]
    private RectTransform _handleTransform;

    private Vector2 _handlePosition;

    void Awake() {
        _handlePosition = _handleTransform.anchoredPosition;
    }

    public void OnSwitch(bool state) {
        _handleTransform.anchoredPosition = state ? _handlePosition : -_handlePosition;
    }
}
