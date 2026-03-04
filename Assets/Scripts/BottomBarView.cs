using UnityEngine;


public class BottomBarView : MonoBehaviour {

    [SerializeField]
    private int _activeItemIndex;

    private BottomBarItem[] _itemList;

    void Awake() {
        _itemList = GetComponentsInChildren<BottomBarItem>();
    }

    void Start() {
        if(_activeItemIndex >= _itemList.Length) {
            Debug.LogWarning("Active item index outside the item range.");
            _activeItemIndex = 0;
        }

        for(int i = 0; i < _itemList.Length; i++) {
            BottomBarItem item = _itemList[i];

            int index = i;

            if(index == _activeItemIndex) {
                item.Activate();
            }

            item.MainButton.onClick.AddListener(()=> {
                if(index == _activeItemIndex) {
                    return;
                }
                _itemList[_activeItemIndex].Deactivate();
                _itemList[index].Activate();
                _activeItemIndex = index;
            });
        }
    }
}
