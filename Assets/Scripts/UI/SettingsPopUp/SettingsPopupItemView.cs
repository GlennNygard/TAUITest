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

    void Awake() {

        _mainImage.sprite = _itemData.MainIcon;

        _itemData.LocString.GetLocalizedStringAsync().Completed += op => {
            _mainText.text = op.Result;};
    }
}
