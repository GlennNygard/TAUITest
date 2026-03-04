using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Localization;


public class SettingsPopupView : BasePopup {

    [SerializeField]
    private TextMeshProUGUI _headerText;

    [Header("Localisation")]

    [SerializeField]
    private LocalizedString _headerTextLS;

    // Other settings popup UI elements would also be added here.



    protected override void Setup() {
        _headerTextLS.GetLocalizedStringAsync().Completed += op => {
            _headerText.text = op.Result;};
    }
}
