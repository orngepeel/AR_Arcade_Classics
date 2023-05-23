using UnityEngine.InputSystem;

namespace UnityEngine.XR.ARFoundation.ARcadeClassics
{
    public class StartButton : MonoBehaviour
    {

        [SerializeField] GameObject snakeHeadPrefab;
        [SerializeField] GameObject gameBoard;
        [SerializeField] GameObject GameStartPrefab;
        [SerializeField] GameActivator gameActivator;

        public void StartButtonPressed()
        {
        
        Vector3 localPosition = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0.5f)); // some logic for getting the local position relative to the board
        Quaternion localRotation = Quaternion.identity; // some logic for getting local rotation relative to the board
        GameObject SnakeHead = Instantiate(snakeHeadPrefab, localPosition, localRotation, gameBoard.transform);
        // whatever else needs to happen when the game starts
        
        gameActivator.DeactivateGameStartPrefab();

        }
    }
}


