using System;
using UnityEngine;


public class HomeScreenController : MonoBehaviour {


    [SerializeField]
    private HomeScreenTopBarView _homeScreenTopBarView;

    [SerializeField]
    private HomeScreenBottomBarView _homeScreenBottomBarView;

    [SerializeField]
    private HomeScreenDebugRowView _homeScreenDebugRowView;


    [SerializeField]
    private SettingsPopupController _settingsPopUpController;

    [SerializeField]
    private  LevelCompleteController _levelCompleteController;


    void Start() {

        if(_homeScreenTopBarView == null) {
            _homeScreenTopBarView = GetComponentInChildren<HomeScreenTopBarView>();
        }

        _settingsPopUpController.Hide(skipAnimations: true);
        _levelCompleteController.Hide();
        _homeScreenTopBarView.OnSettingsSelected += () => {
            _settingsPopUpController.Show();
        };

        _homeScreenDebugRowView.OnLevelCompleteSelected += () => {
            _levelCompleteController.Show();
        };


        // Runs when a new bottom bar item has been toggled on.
        _homeScreenBottomBarView.OnContentActivated += (HomeScreenBottomBarItem item) => {
            Debug.Log(String.Format("New content clicked: {0}.", item.ButtonLabel));
        };

        // Runs when all bottom bar items have been deactivated. Provides last clicked item.
        _homeScreenBottomBarView.OnClosed += (HomeScreenBottomBarItem item) => {
            Debug.Log(String.Format("All content closed. Last clicked item: {0}.", item.ButtonLabel));
        };

        _homeScreenBottomBarView.Show();
    }
}
