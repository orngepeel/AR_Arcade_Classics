using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageAnchorController : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject anchorPrefab;
    [SerializeField] public GameObject[] inactiveElements;
    [SerializeField] public string specificReferenceImageName;

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
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            if (newImage.referenceImage.name == specificReferenceImageName)
            {
                CreateAnchor(newImage);
                break;
            }
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
            if (updatedImage.referenceImage.name == specificReferenceImageName)
            {
                UpdateAnchor(updatedImage);
                break;
            }
        }
    }

    private void CreateAnchor(ARTrackedImage trackedImage)
    {
        GameObject anchorObject = Instantiate(anchorPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
        anchorObject.transform.SetParent(trackedImage.transform);

        foreach (var element in inactiveElements)
        {
            element.SetActive(true);
            element.transform.position = anchorObject.transform.position;
            element.transform.rotation = anchorObject.transform.rotation;
        }
    }

    private void UpdateAnchor(ARTrackedImage trackedImage)
    {
        // Update the anchor's position and rotation to match the tracked image
        GameObject anchorObject = trackedImage.transform.GetChild(0).gameObject;
        anchorObject.transform.position = trackedImage.transform.position;
        anchorObject.transform.rotation = trackedImage.transform.rotation;

        foreach (var element in inactiveElements)
        {
            element.transform.position = anchorObject.transform.position;
            element.transform.rotation = anchorObject.transform.rotation;
        }
    }
}
