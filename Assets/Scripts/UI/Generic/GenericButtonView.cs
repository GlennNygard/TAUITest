using UnityEngine;
using TMPro;


public class GenericButtonView : MonoBehaviour {

    [SerializeField]
    private GenericButtonData _itemData;

    [SerializeField]
    private TextMeshProUGUI _mainText;

    void Awake() {
        _itemData.LocString.GetLocalizedStringAsync().Completed += op => {
            _mainText.text = op.Result;};
    }
}
