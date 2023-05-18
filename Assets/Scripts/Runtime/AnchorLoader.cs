using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AnchorLoader : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject anchorPrefab;
    public GameObject anchorParent;

    private string anchorPositionKey = "SavedAnchorPosition";
    private string anchorRotationKey = "SavedAnchorRotation";

    private ARAnchor anchor;
    private Vector3 savedPosition;
    private Quaternion savedRotation;
    private bool isAnchorLoaded;

    private void Start()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        isAnchorLoaded = false;
    }

    private void Update()
    {
        if (!isAnchorLoaded)
            LoadAnchor();
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.referenceImage.name == "qrcode")
            {
                // Update the saved position and rotation
                savedPosition = trackedImage.transform.position;
                savedRotation = trackedImage.transform.rotation;
            }
        }
    }

    private void LoadAnchor()
    {
        if (savedPosition != Vector3.zero && savedRotation != Quaternion.identity)
        {
            if (anchor == null)
            {
                // Instantiate the anchor at the saved position
                GameObject instantiatedObject = Instantiate(anchorPrefab, savedPosition, savedRotation);
                anchor = instantiatedObject.GetComponent<ARAnchor>();

                // Attach the anchor to the AR session origin
                anchor.transform.SetParent(anchorParent.transform);

                isAnchorLoaded = true;
            }
            else
            {
                // Move the existing anchor to the saved position
                anchor.transform.position = savedPosition;
                anchor.transform.rotation = savedRotation;

                isAnchorLoaded = true;
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