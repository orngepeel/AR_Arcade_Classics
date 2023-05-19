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
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (trackedImage.referenceImage.name == specificReferenceImageName)
            {
                CreateAnchor(trackedImage);
            }
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.referenceImage.name == specificReferenceImageName)
            {
                UpdateAnchor(trackedImage);
            }
        }
    }

    private void CreateAnchor(ARTrackedImage trackedImage)
    {
        GameObject anchorObject = Instantiate(anchorPrefab, trackedImage.transform.position, trackedImage.transform.rotation);

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
