using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class SettingsButtonScript : MonoBehaviour
    {
        [SerializeField]
        GameObject m_SettingsButton;

        public GameObject SettingsButton
        {
            get => m_SettingsButton;
            set => m_SettingsButton = value;
        }

        void Start()
        {
            if (Application.CanStreamedLevelBeLoaded("Settings"))
                m_SettingsButton.SetActive(true);
        }

        public void SettingsButtonPressed()
        {
            if (Application.CanStreamedLevelBeLoaded("Settings"))
                SceneManager.LoadScene("Settings", LoadSceneMode.Single);
        }
    }
}
