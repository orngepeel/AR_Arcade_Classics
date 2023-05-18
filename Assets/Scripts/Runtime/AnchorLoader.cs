using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AnchorLoader : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public ARAnchorManager anchorManager;
    public GameObject anchorPrefab;
    private ARAnchor anchor;
    private GameObject arSessionOrigin;

    private string anchorPositionKey = "SavedAnchorPosition";
    private string anchorRotationKey = "SavedAnchorRotation";

    private void Start()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

        arSessionOrigin = FindObjectOfType<ARSessionOrigin>().gameObject;
    }

    private void Update()
    {
        LoadAnchor();
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.referenceImage.name == "qrcode")
            {
                // Update the anchor's position based on the tracked image's location
                PlayerPrefs.SetString(anchorPositionKey, Vector3ToString(trackedImage.transform.position));
                PlayerPrefs.SetString(anchorRotationKey, QuaternionToString(trackedImage.transform.rotation));
            }
        }
    }

    private void LoadAnchor()
    {
        if (PlayerPrefs.HasKey(anchorPositionKey) && PlayerPrefs.HasKey(anchorRotationKey))
        {
            Vector3 savedPosition = StringToVector3(PlayerPrefs.GetString(anchorPositionKey));
            Quaternion savedRotation = StringToQuaternion(PlayerPrefs.GetString(anchorRotationKey));

            // Instantiate the anchor at the saved position
            GameObject instantiatedObject = Instantiate(anchorPrefab, savedPosition, savedRotation);

            ARAnchor anchor = instantiatedObject.GetComponent<ARAnchor>();
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

    private string Vector3ToString(Vector3 vector)
    {
        return vector.x + "," + vector.y + "," + vector.z;
    }

    private string QuaternionToString(Quaternion quaternion)
    {
        return quaternion.x + "," + quaternion.y + "," + quaternion.z + "," + quaternion.w;
    }
}
