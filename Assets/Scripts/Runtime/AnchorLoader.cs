using UnityEngine;

public class AnchorLoader : MonoBehaviour
{
    /// This class relies on there being one object with the "Container" tag in the scene.
    /// It also assumes that the object with the tag is the child of this object.
    GameObject[] gameContainer;

    private string anchorPositionKey = "SavedAnchorPosition";
    private string anchorRotationKey = "SavedAnchorRotation";
    private bool hasLoaded = false;

    private void Start()
    {
        /// Load game as soon as the anchor container in the scene is initialized
        gameContainer = GameObject.FindGameObjectsWithTag("Container");
        LoadGame();
    }

    private void Update()
    {
        /// If for whatever reason the game did not load on start, load it ASAP
        if(!hasLoaded)
        {
            LoadGame();
        }
    }

    private void LoadGame()
    {
        /// <summary>
        /// This method checks if an anchor's position and rotation are saved in PlayerPrefs.
        /// If they are, it sets the position and rotation of this object accordingly.
        /// It then centers the gameContainer object at the saved position and rotation.
        /// This method should run once in the scene.
        /// </summary>
        if (PlayerPrefs.HasKey(anchorPositionKey) && PlayerPrefs.HasKey(anchorRotationKey))
        {
            Vector3 savedPosition = StringToVector3(PlayerPrefs.GetString(anchorPositionKey));
            Quaternion savedRotation = StringToQuaternion(PlayerPrefs.GetString(anchorRotationKey));
            
            transform.position = savedPosition;
            transform.rotation = savedRotation;

            gameContainer[0].transform.localPosition = new Vector3(0,0,0);
            gameContainer[0].transform.localRotation = Quaternion.identity;

            hasLoaded = true;
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
}
