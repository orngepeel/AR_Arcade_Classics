using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AnchorLoader : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public ARAnchorManager anchorManager;
    public GameObject anchorPrefab;
    private ARAnchor anchor;
    public GameObject anchorParent;

    private string anchorPositionKey = "SavedAnchorPosition";
    private string anchorRotationKey = "SavedAnchorRotation";

    private Vector3 lastPosition;
    private Quaternion lastRotation;

    private void Start()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
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

                // Store the latest position and rotation
                lastPosition = trackedImage.transform.position;
                lastRotation = trackedImage.transform.rotation;

                // Update the anchor if it exists
                if (anchor != null)
                {
                    anchor.transform.position = lastPosition;
                    anchor.transform.rotation = lastRotation;
                }
                else
                {
                    // Instantiate the anchor at the saved position
                    Vector3 savedPosition = StringToVector3(PlayerPrefs.GetString(anchorPositionKey));
                    Quaternion savedRotation = StringToQuaternion(PlayerPrefs.GetString(anchorRotationKey));
                    GameObject instantiatedObject = Instantiate(anchorPrefab, savedPosition, savedRotation);
                    anchor = instantiatedObject.GetComponent<ARAnchor>();
                    anchor.transform.SetParent(anchorParent.transform);
                }

                break; // Exit the loop after processing the first tracked image
            }
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
