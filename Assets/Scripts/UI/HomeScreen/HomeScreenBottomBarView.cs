using PrimeTween;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class HomeScreenBottomBarView : MonoBehaviour {

    [SerializeField]
    private int _activeItemIndex;

    private HomeScreenBottomBarItem[] _itemList;

    private RectTransform _rectTransform;
    private Vector2 _initialBarSize;
    private TweenSettings _moveInTweenSettings;

    void Awake() {
        _itemList = GetComponentsInChildren<HomeScreenBottomBarItem>();
        _rectTransform = GetComponent<RectTransform>();
        _initialBarSize = _rectTransform.sizeDelta;

        _moveInTweenSettings = new TweenSettings(
            duration: 0.4f, ease: Ease.InCubic);
    }

    void Start() {
        // if(_activeItemIndex >= _itemList.Length) {
        //     Debug.LogWarning("Active item index outside the item range.");
        //     _activeItemIndex = 0;
        // }

        for(int i = 0; i < _itemList.Length; i++) {
            HomeScreenBottomBarItem item = _itemList[i];

            int index = i;

            if(index == _activeItemIndex) {
                item.Activate();
            }

            if(item.Locked) {
                continue;
            }

            item.MainButton.onClick.AddListener(()=> {
                if(_activeItemIndex != -1) {
                    _itemList[_activeItemIndex].Deactivate();
                }
                if(index != _activeItemIndex) {
                    _itemList[index].Activate();
                    _activeItemIndex = index;
                }
                else {
                    _activeItemIndex = -1;
                }
            });
        }
    }

    public void Show() {
        PrimeTween.Tween.UISizeDelta(
            _rectTransform, new TweenSettings<Vector2>(
                new Vector2(_initialBarSize.x, 0), _initialBarSize, _moveInTweenSettings));
    }

    public void Hide() {
        PrimeTween.Tween.UISizeDelta(
            _rectTransform, new TweenSettings<Vector2>(
                _initialBarSize, new Vector2(_initialBarSize.x, 0), new TweenSettings()));

    }
}
