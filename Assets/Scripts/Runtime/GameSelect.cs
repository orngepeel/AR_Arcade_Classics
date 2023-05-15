using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class GameSelect : MonoBehaviour
    {
        [SerializeField]
        GameObject m_startButton;

        [SerializeField]
        string m_gameTitle;
        

        public GameObject startButton
        {
            get => m_startButton;
            set => m_startButton = value;
        }

        void Start()
        {
            if (Application.CanStreamedLevelBeLoaded(m_gameTitle))
                m_startButton.SetActive(true);
        }

        public void StartButtonPressed()
        {
            if (Application.CanStreamedLevelBeLoaded(m_gameTitle))
                SceneManager.LoadScene(m_gameTitle, LoadSceneMode.Single);
        }
    }
}
