using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField]
        GameObject m_StartButton;
        [SerializeField]
        private string GameName;

        public GameObject backButton
        {
            get => m_StartButton;
            set => m_StartButton = value;
        }

        void Start()
        {
            if (Application.CanStreamedLevelBeLoaded(GameName))
                m_StartButton.SetActive(true);
        }

        public void StartButtonPressed()
        {
            if (Application.CanStreamedLevelBeLoaded(GameName))
                
                SceneManager.LoadScene(GameName, LoadSceneMode.Single);
        }
    }
}
