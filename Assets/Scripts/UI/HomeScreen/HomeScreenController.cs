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

        _homeScreenBottomBarView.Show();
    }
}
