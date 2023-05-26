using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SavePosition : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    private string anchorKey = "AnchorKey";

    private void OnEnable()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SaveAnchor(trackedImage);
        }
    }

    private void SaveAnchor(ARTrackedImage trackedImage)
    {
        string positionKey = anchorKey + "Position";
        string rotationKey = anchorKey + "Rotation";
        
        PlayerPrefs.SetString(positionKey, Vector3ToString(trackedImage.transform.position));
        PlayerPrefs.SetString(rotationKey, QuaternionToString(trackedImage.transform.rotation));
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

