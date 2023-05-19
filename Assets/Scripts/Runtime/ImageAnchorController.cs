using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageAnchorController : MonoBehaviour
{
    [SerializeField] private GameObject anchorPrefab;
    [SerializeField] public GameObject[] inactiveElements;
    [SerializeField] public string specificReferenceImage;
    private ARTrackedImageManager trackedImageManager;

    private void Start()
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
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            if (newImage.referenceImage.name == specificReferenceImage)
            {
                CreateAnchor(newImage);
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
}
