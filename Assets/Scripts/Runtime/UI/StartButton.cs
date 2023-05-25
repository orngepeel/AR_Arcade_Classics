using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class StartButton : MonoBehaviour
    {

        [SerializeField] string gameName;
        [SerializeField] GameObject startPrefab;
        public string anchorKey = "AnchorKey";

        public void StartButtonPressed()
        {
            string positionKey = anchorKey + "Position";
            string rotationKey = anchorKey + "Rotation";

            Transform parent = startPrefab.transform.parent;

            PlayerPrefs.SetString(positionKey, Vector3ToString(parent.transform.position));
            PlayerPrefs.SetString(rotationKey, QuaternionToString(parent.transform.rotation));

            if (Application.CanStreamedLevelBeLoaded(gameName))
                SceneManager.LoadScene(gameName, LoadSceneMode.Single);
        
        }

        private string Vector3ToString(Vector3 vector)
        {
            return vector.x + "," + vector.y + "," + vector.z;
        }

        private string QuaternionToString(Quaternion quaternion)
        {
            return quaternion.x + "," + quaternion.y + "," + quaternion.z + "," + quaternion.w;
        }
    }
}


