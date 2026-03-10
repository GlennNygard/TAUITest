using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class RectAnimator : MonoBehaviour {

    public Vector2 InitialSize {
        get {return _initialSize;}}

    public Vector2 InitialOffsetMin {
        get {return _initialOffsetMin;}}

    public Vector2 InitialOffsetMax {
        get {return _initialOffsetMax;}}

    public RectTransform ElementTransform {
        get {return _elementTransform;}}

    private RectTransform _elementTransform;

    private Vector2 _initialSize;
    private Vector2 _initialOffsetMin;
    private Vector2 _initialOffsetMax;


    void Awake() {
        _elementTransform = GetComponent<RectTransform>();
        _initialSize = _elementTransform.sizeDelta;
        _initialOffsetMin = _elementTransform.offsetMin;
        _initialOffsetMax = _elementTransform.offsetMax;
    }
}
