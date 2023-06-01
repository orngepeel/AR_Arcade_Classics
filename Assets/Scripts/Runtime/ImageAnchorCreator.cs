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
        /// Subscribe to tracked images changed events on enable
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        /// Unsubscribe from tracked images changed events on disable
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        /// When a new image from the reference image library is detected, create an anchor
        foreach (var trackedImage in eventArgs.added)
        {
            CreateAnchor(trackedImage.transform.position, trackedImage.transform.rotation);
        }
    }

    private void CreateAnchor(Vector3 position, Quaternion rotation)
    {
        /// <summary>
        /// This method creates an anchor at the given position and rotation.
        /// It then passes the anchor to SaveAnchor.
        /// </summary>
        ARAnchor anchor = gameObject.AddComponent<ARAnchor>();
        anchor.transform.SetPositionAndRotation(position, rotation);
        SaveAnchor(anchor);
    }

    private void SaveAnchor(ARAnchor anchor)
    {
        /// <summary>
        /// This method stores the given anchor's position and rotation in the PlayerPrefs.
        /// </summary>
        string positionKey = anchorKey + "Position";
        string rotationKey = anchorKey + "Rotation";
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
