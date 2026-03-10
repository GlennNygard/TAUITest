using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsPopupItemView : MonoBehaviour {

    [SerializeField]
    private SettingsItemData _itemData;

    [SerializeField]
    private Image _mainImage;

    [SerializeField]
    private TextMeshProUGUI _mainText;

    void Start() {

        _mainImage.sprite = _itemData.MainIcon;
        _mainText.text = _itemData.MainText;
    }
}
