using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageAnchorCreator : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public ARAnchorManager anchorManager;
    public GameObject anchorPrefab;

    private string anchorKey = "SavedAnchor";

    private void OnEnable()
    {
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
            CreateAndPersistAnchor(trackedImage.transform.position, trackedImage.transform.rotation);
        }
    }

    private void CreateAndPersistAnchor(Vector3 position, Quaternion rotation)
    {
        ARAnchor anchor = gameObject.AddComponent<ARAnchor>();
        anchor.transform.SetPositionAndRotation(position, rotation);
        SaveAnchor(anchor);
    }

    private void SaveAnchor(ARAnchor anchor)
    {
        string positionKey = anchorKey + "Position";
        string rotationKey = anchorKey + "Rotation";
        // Get the position of the tracked image
        ARTrackedImage trackedImage = GetComponent<ARTrackedImage>();
        Vector3 imagePosition = trackedImage.transform.position;
        Quaternion imageRotation = trackedImage.transform.rotation;

        // Update the anchor's position
        anchor.transform.position = imagePosition;
        anchor.transform.rotation = imageRotation;

        // Save the updated anchor position and rotation
        PlayerPrefs.SetString(positionKey, Vector3ToString(anchor.transform.position));
        PlayerPrefs.SetString(rotationKey, QuaternionToString(anchor.transform.rotation));
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
