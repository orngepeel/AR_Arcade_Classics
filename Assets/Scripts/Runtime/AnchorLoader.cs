using UnityEngine;

public class AnchorLoader : MonoBehaviour
{
    public GameObject anchorPrefab;
    public GameObject gameContainer;

    private string anchorPositionKey = "SavedAnchorPosition";
    private string anchorRotationKey = "SavedAnchorRotation";

    private void Start()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey(anchorPositionKey) && PlayerPrefs.HasKey(anchorRotationKey))
        {
            Vector3 savedPosition = StringToVector3(PlayerPrefs.GetString(anchorPositionKey));
            Quaternion savedRotation = StringToQuaternion(PlayerPrefs.GetString(anchorRotationKey));
            
            transform.position = savedPosition;
            transform.rotation = savedRotation;

            Instantiate(anchorPrefab, transform);
            anchorPrefab.transform.localPosition = new Vector3(0,0,0);
            anchorPrefab.transform.localRotation = Quaternion.identity;
            gameContainer.transform.SetParent(anchorPrefab.transform);
            gameContainer.transform.localPosition = new Vector3(0,0,0);
            gameContainer.transform.localRotation = Quaternion.identity;
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
