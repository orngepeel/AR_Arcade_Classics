using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameActivator : MonoBehaviour
{
    [SerializeField] GameObject GameContainer;
    private string anchorPositionKey = "AnchorKeyPosition";
    private string anchorRotationKey = "AnchorKeyRotation";
    
    void Awake()
    {
        ActivateGame();
    }

    void ActivateGame()
    {
        if (PlayerPrefs.HasKey(anchorPositionKey) && PlayerPrefs.HasKey(anchorRotationKey))
        {
            Vector3 savedPosition = StringToVector3(PlayerPrefs.GetString(anchorPositionKey));
            Quaternion savedRotation = StringToQuaternion(PlayerPrefs.GetString(anchorRotationKey));

            GameContainer.SetActive(true);
            GameContainer.transform.position = savedPosition;
            GameContainer.transform.rotation = savedRotation;
        }
    }

    private Vector3 StringToVector3(string serializedVector)
    {
        string[] values = serializedVector.Split(',');
        float x = float.Parse(values[0]);
        float y = float.Parse(values[1]);
        float z = float.Parse(values[2]);
        return new Vector3(x, y, z);
    }

    private Quaternion StringToQuaternion(string serializedQuaternion)
    {
        string[] values = serializedQuaternion.Split(',');
        float x = float.Parse(values[0]);
        float y = float.Parse(values[1]);
        float z = float.Parse(values[2]);
        float w = float.Parse(values[3]);
        return new Quaternion(x, y, z, w);
    }
}
