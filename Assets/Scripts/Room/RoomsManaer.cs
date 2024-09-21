using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class RoomsManaer : MonoBehaviour
{
    [SerializeField] private List<SingleRoom> rooms = new List<SingleRoom>();

    private SaveModel saveModel => DI.di.savemanager.model;

    private void Awake()
    {
        Debug.Log("RoomsManaer :: Awake");
        Assert.IsTrue(rooms.Count > 0, "Please Add a room");

        if (saveModel.roomStates.Count <= 0)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                saveModel.roomStates.Add(RoomState.Locked);
            }
        }

        for (int i = 0; i < saveModel.roomsUnlocked; i++)
        {
            rooms[i].UnlockRoom();
        }
    }

    private void Start()
    {


    }
}
