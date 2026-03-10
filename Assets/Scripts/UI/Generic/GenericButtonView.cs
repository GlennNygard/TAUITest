using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GenericButtonView : MonoBehaviour {

    [SerializeField]
    private GenericButtonData _itemData;

    [SerializeField]
    private TextMeshProUGUI _mainText;

    void Start() {
        _mainText.text = _itemData.MainText;
    }
}
