using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Localization;


public class SettingsPopupView : BasePopup {

    [SerializeField]
    private TextMeshProUGUI _headerText;

    // [SerializeField]
    // private Button _tcButton;

    // [SerializeField]
    // private Button _privacyButton;

    // [SerializeField]
    // private Button _supportButton;

    [Header("Localisation")]

    [SerializeField]
    private LocalizedString _headerTextLS;

    // [SerializeField]
    // private LocalizedString _tcTextLS;

    // [SerializeField]
    // private LocalizedString _privacyTextLS;

    // [SerializeField]
    // private LocalizedString _supportTextLS;

    // Not doing anything with this for now.
    private GameObject _settingsItemsParent;

    // Other settings popup UI elements would also be added here.



    protected override void Setup() {
        _headerTextLS.GetLocalizedStringAsync().Completed += op => {
            _headerText.text = op.Result;};

        // _tcTextLS.GetLocalizedStringAsync().Completed += op => {
        //     _tcButton.GetComponentInChildren<TextMeshProUGUI>().text = op.Result;};

        // _privacyTextLS.GetLocalizedStringAsync().Completed += op => {
        //     _privacyButton.GetComponentInChildren<TextMeshProUGUI>().text = op.Result;};

        // _supportTextLS.GetLocalizedStringAsync().Completed += op => {
        //     _supportButton.GetComponentInChildren<TextMeshProUGUI>().text = op.Result;};
    }
}
