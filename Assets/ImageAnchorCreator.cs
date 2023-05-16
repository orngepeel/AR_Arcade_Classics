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

        Instantiate(anchorPrefab, anchor.transform.position, anchor.transform.rotation);
    }

    private void SaveAnchor(ARAnchor anchor)
    {
        PlayerPrefs.SetString(anchorKey, anchor.trackableId.ToString());
    }
}
