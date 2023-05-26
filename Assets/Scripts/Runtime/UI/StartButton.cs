using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class StartButton : MonoBehaviour
    {

        [SerializeField] string gameName;
        [SerializeField] GameObject startPrefab;

        public void StartButtonPressed()
        {
            if (Application.CanStreamedLevelBeLoaded(gameName))
                SceneManager.LoadScene(gameName, LoadSceneMode.Single);
        }   
    }
}


