using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HomeScreenTopBarItemView : MonoBehaviour {

    [SerializeField]
    private HomeScreenInventoryItemData _itemData;

    [SerializeField]
    private Image _mainImage;

    [SerializeField]
    private Button _addButton;

    [SerializeField]
    private TextMeshProUGUI _labelText;

    [SerializeField]
    private TextMeshProUGUI _iconText;


    void Start() {

        _mainImage.sprite = _itemData.MainIcon;

        // The item count should obviously just be
        // read from a proper inventory somewhere,
        // but this works for the purposes of a simple showcase.
        _labelText.text = _itemData.LabelText;
        _iconText.text = _itemData.IconText;

        // We just set the button as active or not for now,
        // to illustrate the intended effect.
        _addButton.gameObject.SetActive(_itemData.CanAdd);

    }
}
