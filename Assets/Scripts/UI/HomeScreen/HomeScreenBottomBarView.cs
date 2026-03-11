using System;
using PrimeTween;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class HomeScreenBottomBarView : MonoBehaviour {

    [SerializeField]
    /* Using an index here instead of storing an item ref
    directly allows us to easily set a default panel
    in the inspector.
    */
    private int _activeItemIndex;

    [Header("Configuration")]
    [SerializeField]
    private float _bottomBarTransitionDuration = 0.5f;

    public event Action<HomeScreenBottomBarItem> OnContentActivated;
    public event Action<HomeScreenBottomBarItem> OnClosed;

    private HomeScreenBottomBarItem[] _itemList;

    private RectTransform _rectTransform;
    private Vector2 _initialBarSize;


    void Awake() {
        _itemList = GetComponentsInChildren<HomeScreenBottomBarItem>();
        _rectTransform = GetComponent<RectTransform>();
        _initialBarSize = _rectTransform.sizeDelta;
    }

    void Start() {

        for(int i = 0; i < _itemList.Length; i++) {
            HomeScreenBottomBarItem item = _itemList[i];

            if(item.Locked) {
                item.MainButton.onClick.AddListener(()=> {
                    item.LockedClickEffect();});
                continue;
            }

            int index = i;
            if(index == _activeItemIndex) {
                item.Activate();
            }

            item.MainButton.onClick.AddListener(()=> {
                if(_activeItemIndex != -1) {
                    _itemList[_activeItemIndex].Deactivate();
                }
                if(index != _activeItemIndex) {
                    _activeItemIndex = index;
                    _itemList[_activeItemIndex].Activate();
                    OnContentActivated?.Invoke(_itemList[_activeItemIndex]);
                }
                else {
                    if(_activeItemIndex != -1) {
                        OnClosed?.Invoke(_itemList[_activeItemIndex]);
                    }
                    _activeItemIndex = -1;
                }
            });
        }
    }

    public void Show() {
        PrimeTween.Tween.UISizeDelta(
            _rectTransform, new TweenSettings<Vector2>(
                new Vector2(_initialBarSize.x, 0), _initialBarSize, _bottomBarTransitionDuration, Easing.Overshoot(1.2f)));
    }

    public void Hide() {
        PrimeTween.Tween.UISizeDelta(
            _rectTransform, new TweenSettings<Vector2>(
                _initialBarSize, new Vector2(_initialBarSize.x, 0),  _bottomBarTransitionDuration));
    }
}
