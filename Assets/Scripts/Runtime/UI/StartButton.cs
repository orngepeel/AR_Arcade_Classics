using UnityEngine.InputSystem;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField]
        GameObject m_StartButton;
        [SerializeField]
        private string GameName;
        [SerializeField]
        GameObject GameStartPrefab;
        GameObject ActivatedGame;

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
                ActivatedGame = GameObject.Find("/"+GameName);
                ActivatedGame.SetActive(true);
                ActivatedGame.transform.parent = GameStartPrefab.transform.parent;
                GameStartPrefab.SetActive(false);
                
        }
    }
}
