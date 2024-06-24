using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSencitivity = 10f;
    [SerializeField] private float cameraLimitAngle = 30f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float gravity = -9.8f;

    private bool canBePanelClosed = false;

    [SerializeField] private CastUIController castUIController;
    [SerializeField] private InventoryUIController inventoryUIController;
    [SerializeField] private WarningPanelController warningPanelController;
    [SerializeField] private FishController fishController;
    [SerializeField] private CaughtFishUIController caughtFishUIController;

    [SerializeField] private GameManager gameManager;
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 move = Vector3.zero;
    private float xRotation = 0f;
    private float currentSpeed;
    [SerializeField] private float currentCastPower = 0f;
    private float factorCastPower = 100f;

    private Camera playerCamera;
    private CharacterController characterController;
    private GameInput gameInput;
    private GameState gameState;
    public enum GameState {isReady, isCast, isWater, isFishCaught, isInventory}
    
    [SerializeField] private FishingLineController floaterLineController = null;
    [SerializeField] private FishingLineController fishingRodController = null;
    [SerializeField] private FishingLineController cargoController = null;
    [SerializeField] private FishingLineController hookController = null;
    
    private bool invertTemp = false;
    private void Awake()
    {
        gameInput = new GameInput();
        gameInput.Game.Enable();
    }

    private void Start()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        gameState = GameState.isReady;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.isReady:
                Looking();
                Run();
                Movement();
                ChooseBait();
                
                SetBobberDepth();
                if (gameInput.Game.Inventory.WasPressedThisFrame())
                {
                    gameState = GameState.isInventory;
                }
                
                if (gameInput.Game.Cast.WasPressedThisFrame() && inventoryUIController.CanBeBaitChoosen())
                {
                    castUIController.SetCastSliderActive(true); 
                    gameState = GameState.isCast; 
                    SetIsReadyAll(false);
                }
                else if (gameInput.Game.Cast.WasPressedThisFrame() && !inventoryUIController.CanBeBaitChoosen())
                {
                    warningPanelController.StartFadeOutWarning();
                }
                
                break;
            case GameState.isCast:
                Looking();
                CastFishingRod();
                break;
            case GameState.isWater:
                Looking();
                Run();
                Movement();
                FishActions();
                
                FishingRodWinding();
                break;
            case GameState.isFishCaught:
                CatchedFishUI();
                //FishPickUp();
                //ReleaseFish();
                break;
            case GameState.isInventory:
                InventoryActions();
                break;
            default:
                Looking();
                Run();
                Movement();
                break;
        }
    }

    private void Movement()
    {
        velocity.y += gravity * Time.deltaTime;

        if (characterController.isGrounded)
        {
            Vector2 moveAxis = gameInput.Game.Movement.ReadValue<Vector2>();
            float x = moveAxis.x;
            float y = moveAxis.y;

            move = transform.right * x + transform.forward * y;
            move *= currentSpeed;

            velocity.y = -2f;
        }
        characterController.Move((velocity + move) * Time.deltaTime);
    }

    private void Looking()
    {
        Vector2 mouseAxis = gameInput.Game.Looking.ReadValue<Vector2>() * Time.smoothDeltaTime;
        float mouseX = mouseAxis.x * mouseSencitivity;
        float mouseY = mouseAxis.y * mouseSencitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -cameraLimitAngle, cameraLimitAngle);
        
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Run()
    {
        if (characterController.isGrounded && gameInput.Game.Run.IsPressed())
        {
            currentSpeed = runSpeed;
        }
        else if (gameInput.Game.Run.WasReleasedThisFrame())
        {
            currentSpeed = walkSpeed;
        }
    }
    
    private void FishingRodWinding()
    {
        if (gameInput.Game.Hooking.IsPressed())
        {
            fishingRodController.UpdateWinch(invertTemp);
        }

        if (fishingRodController.GetIsReady())
        {
            if (fishController.IsFishSpawned())
            {
                gameState = GameState.isFishCaught;
                gameManager.MinusBait(1);
                inventoryUIController.AttachBait();
                fishController.DestroyFish();
            }
            else
            {
                gameState = GameState.isReady;
            }
            SetIsReadyAll(true);
        }
    }
    
    private void SetBobberDepth()
    {
        if (gameInput.Game.BobberDepthUp.IsPressed())
        {
            floaterLineController.UpdateBobberDepth(true);
            fishingRodController.SetFishingRodFloaterDepth(floaterLineController.GetRopeLength());
        }
        else if (gameInput.Game.BobberDepthDown.IsPressed())
        {
            floaterLineController.UpdateBobberDepth(false);
            fishingRodController.SetFishingRodFloaterDepth(floaterLineController.GetRopeLength());
        }
    }

    private void CastFishingRod()
    {
        if (gameInput.Game.Cast.IsPressed())
        {

            currentCastPower += factorCastPower * Time.deltaTime;
            castUIController.SetCastPowerSlider(currentCastPower);
            if (currentCastPower > 100f)
            {
                currentCastPower = 100f;
            }
        }

        if (gameInput.Game.Cast.WasReleasedThisFrame())
        {
            gameState = GameState.isWater;
            castUIController.SetCastSliderActive(false);
            fishingRodController.CastFishingRod(currentCastPower, transform.forward);
            currentCastPower = 0f;
        }
    }

    private void SetIsReadyAll(bool isReady)
    {
        if (fishingRodController != null)
        {
            fishingRodController.SetIsReadyFishingRod(isReady);
        }
        if (floaterLineController != null)
        {
            floaterLineController.SetIsReadyFishingRod(isReady);
        }
        if (cargoController != null)
        {
            cargoController.SetIsReadyFishingRod(isReady);
        }
        if (hookController != null)
        {
            hookController.SetIsReadyFishingRod(isReady);
        }
    }

    private void FishActions()
    {
        Fish fish = null;
        if (!fishController.IsFishSpawned())
        {
            fish = fishController.CreateNewFish();
            fishController.InstantiateFish(fish);
        }
        else if (fishController.IsFishSpawned())
        {
            inventoryUIController.DestroyBait();
            fishController.FishSwim();
        }
    }

    private void ChooseBait()
    {
        
        if (gameInput.Game.ChooseBait.WasPressedThisFrame())
        {
            inventoryUIController.NextBait();
            
            inventoryUIController.AttachBait();
        }
    }

    private void CatchedFishUI()
    {
        if (!caughtFishUIController.caughtFishPanel.activeInHierarchy)
        {
            caughtFishUIController.ShowWindow();
            canBePanelClosed = true;
        }
    }

    private void InventoryActions()
    {
        inventoryUIController.OpenInventory();
    }
    
    public void FishPickUp()
    {
     
        gameManager.PickUpFish();
        caughtFishUIController.CloseWindow();
        gameState = GameState.isReady;
    }

    public void ReleaseFish()
    {
        Debug.Log("fish released");
        caughtFishUIController.CloseWindow();
        gameState = GameState.isReady;
    }

    public void CloseInventory()
    {
        inventoryUIController.CloseInventory();
        gameState = GameState.isReady;
    }

}
