using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Vector3 playerPosition; //creates a variable that represents the Players position
    Vector3 objectPosition; //creates a variable that represents the Objects position
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform.position; //sets playerPositions value to the transform.position of the player
        objectPosition = transform.position; //sets objectPositions value to the transform.position of the object
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position; //updates playerPosition
        objectPosition.y = playerPosition.y;
        objectPosition.x = playerPosition.x; //sets the x and y of objectPosition to playerPositions x and y
        transform.position = objectPosition; //sets the transform.position of the object to objectPosition
    }
}
