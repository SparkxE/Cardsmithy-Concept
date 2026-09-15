using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private double timeSincePress = 0; //time counter since most recent movement button press
    private PlayerActions playerActions; //playerActions action map for reading movement inputs
    private Vector2 currentInput; //current directional input

    //tile ID "spacing"
    [SerializeField] private int tileSpaceVert = 3;
    [SerializeField] private int tileSpaceHoriz = 1;

    //current tile details
    [SerializeField] private GameObject currentTile;
    [SerializeField] private TileStates currentTileState;

    //combat start values
    [SerializeField] private Transform startPosition;
    [SerializeField] private float moveSpacing = 0;
    [SerializeField] private float startBuffer = 0;

    // Start is called before the first frame update
    // ensure player is located at startPosition regardless of editor position, 
    // create playerActions object to read movement inputs,
    // get state details for the starting tile
    void Start()
    {
        gameObject.transform.position = startPosition.position;
        currentTile = startPosition.parent.GameObject();
        playerActions = new PlayerActions();
        playerActions.Enable();
        GetTileState();
    }

    // called at a fixed framerate
    void FixedUpdate()
    {
        //increment time since movement pressed & check for valid movement input
        timeSincePress += Time.fixedDeltaTime;
        GetInput();
        if (currentInput != Vector2.zero)
        {
            Move(currentInput);
        }
    }

    private void GetInput()
    {
        currentInput = playerActions.Movement.TileMovement.ReadValue<Vector2>();
    }

    private void Move(Vector2 input)
    {
        if (Time.fixedTime >= startBuffer)  //ensure start window is cleared before performing inputs
        {
            if (timeSincePress >= moveSpacing) //ensure movement happens between movement buffer windows
            {
                //reset timeSincePress and call relevant movement input function
                timeSincePress = 0;
                if (input.y > 0)
                {
                    MoveUp();
                }
                else if (input.y < 0)
                {
                    MoveDown();
                }
                else if (input.x > 0)
                {
                    MoveRight();
                }
                else if (input.x < 0)
                {
                    MoveLeft();
                }
            }
        }
    }

    private void MoveUp()
    {
        if (currentTileState.IsTop == false)
        {
            //search for the tile above the current tile, set as new current tile and move to its CenterNode
            GameObject newTile = GameObject.Find("TileAlly" + (currentTileState.TileNum - tileSpaceVert));
            Transform newPosition = newTile.transform.GetChild(1).transform;
            gameObject.transform.position = newPosition.position;
            currentTile = newTile;
            GetTileState();
        }
    }

    private void MoveDown()
    {
        if (currentTileState.IsBot == false)
        {
            //search for the tile below the current tile, set as new current tile and move to its CenterNode
            GameObject newTile = GameObject.Find("TileAlly" + (currentTileState.TileNum + tileSpaceVert));
            Transform newPosition = newTile.transform.GetChild(1).transform;
            gameObject.transform.position = newPosition.position;
            currentTile = newTile;
            GetTileState();
        }
    }

    private void MoveLeft()
    {
        if (currentTileState.IsLeft == false)
        {
            //search for the tile left of the current tile, set as new current tile and move to its CenterNode
            GameObject newTile = GameObject.Find("TileAlly" + (currentTileState.TileNum - tileSpaceHoriz));
            Transform newPosition = newTile.transform.GetChild(1).transform;
            gameObject.transform.position = newPosition.position;
            currentTile = newTile;
            GetTileState();
        }
    }

    private void MoveRight()
    {
        if (currentTileState.IsRight == false)
        {
            //search for the tile right of the current tile, set as new current tile and move to its CenterNode
            GameObject newTile = GameObject.Find("TileAlly" + (currentTileState.TileNum + tileSpaceHoriz));
            Transform newPosition = newTile.transform.GetChild(1).transform;
            gameObject.transform.position = newPosition.position;
            currentTile = newTile;
            GetTileState();
        }
    }

    private void GetTileState()
    {
        //get details about the current tile
        currentTileState = currentTile.GetComponent<TileStates>();
    }
}
