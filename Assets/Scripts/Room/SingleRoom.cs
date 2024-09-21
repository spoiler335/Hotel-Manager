using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingleRoom : MonoBehaviour
{
    [field: SerializeField] public int roomId { get; private set; }
    [SerializeField] private GameObject blocker;
    [field: SerializeField] public Transform roomTarget { get; private set; }
    public RoomState cuurentState { get; private set; } = RoomState.Locked;

    public bool isUnlocked { get; private set; } = false;
    private SaveModel saveModel => DI.di.savemanager.model;

    private void Awake()
    {
        blocker.SetActive(true);
    }

    public void UnlockRoom()
    {
        Debug.Log($"Room {roomId} unlocked");
        isUnlocked = true;
        blocker.SetActive(false);
    }

    private void Start()
    {
        Debug.Log($"1-Setting Room {roomId} to exp = {cuurentState} state = {saveModel.roomStates[roomId]}");
        if (isUnlocked && saveModel.roomStates[roomId] == RoomState.Locked)
        {
            Debug.Log($"2-Setting Room {roomId} to exp = {cuurentState} state = {saveModel.roomStates[roomId]}");
            cuurentState = RoomState.Unoccupied;
            saveModel.roomStates[roomId] = cuurentState;
            Debug.Log($"3-Setting Room {roomId} to exp = {cuurentState} state = {saveModel.roomStates[roomId]}");
        }
    }
}
