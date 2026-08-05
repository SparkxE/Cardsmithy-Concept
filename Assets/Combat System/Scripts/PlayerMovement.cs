using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private double timeSincePress = 0;
    private PlayerInput playerInput;
    private PlayerActions playerActions;
    private Vector2 currentInput;
    private InputActionPhase fireRanged;
    private InputActionPhase fireMelee;
    [SerializeField] private int tileSpaceVert = 3;
    [SerializeField] private int tileSpaceHoriz = 1;
    [SerializeField] private GameObject currentTile;
    [SerializeField] private TileStates currentTileState;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float moveSpacing = 0;
    [SerializeField] private float startBuffer = 0;
    // Start is called before the first frame update
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
        timeSincePress += Time.fixedDeltaTime;
        GetInput();
        if (currentInput != Vector2.zero)
        {
            Move(currentInput);
        }
        // if (fireRanged == InputActionPhase.Performed)
        // {
        //     RangedAttack();
        // }
        // else if(fireMelee == InputActionPhase.Performed)
        // {
        //     MeleeAttack();
        // }
    }

    private void GetInput()
    {
        currentInput = playerActions.Movement.TileMovement.ReadValue<Vector2>();
        // fireRanged = playerActions.Attack.RangedAttack.phase;
        // fireMelee = playerActions.Attack.MeleeAttack.phase;
    }

    public void RangedAttack(InputAction.CallbackContext context)
    {
        if (Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started) { Debug.Log("Ranged Attack Fired"); }
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (Time.fixedTime >= startBuffer && context.phase == InputActionPhase.Started) { Debug.Log("Melee Attack Fired"); }
    }

    private void Move(Vector2 input)
    {
        if (Time.fixedTime >= startBuffer)
        {
            if (timeSincePress >= moveSpacing)
            {
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
            GameObject newTile = GameObject.Find("TileAlly" + (currentTileState.TileNum + tileSpaceHoriz));
            Transform newPosition = newTile.transform.GetChild(1).transform;
            gameObject.transform.position = newPosition.position;
            currentTile = newTile;
            GetTileState();
        }
    }

    private void GetTileState()
    {
        currentTileState = currentTile.GetComponent<TileStates>();
        // Debug.Log(currentTileState.TileNum);
    }
}
