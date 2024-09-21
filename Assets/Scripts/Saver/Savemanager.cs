using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Savemanager : MonoBehaviour
{
    private const float SAVE_INTERVAL = 5f;
    private float timeSinceLastChecked = 0f;
    public SaveModel model { get; private set; } = new SaveModel();

    private void Awake()
    {
        if (DI.di.savemanager != null)
        {
            Destroy(gameObject);
            return;
        }
        DI.di.SetSaveManager(this);

        if (PlayerPrefs.HasKey(PPF_Constants.SAVE_KEY))
        {
            model = JsonUtility.FromJson<SaveModel>(PlayerPrefs.GetString(PPF_Constants.SAVE_KEY));
        }
        EventsModel.SAVE_DATA_READY?.Invoke();
    }

    private void Start()
    {
        Debug.Log($"SaveManager :: Data::\n{JsonUtility.ToJson(model)}");
    }

    private void Update()
    {
        timeSinceLastChecked += Time.deltaTime;
        if (timeSinceLastChecked >= SAVE_INTERVAL)
        {
            Save();
            // TODO :: Add UI Event 
            timeSinceLastChecked = 0f;
        }
    }

    private void Save()
    {
        string data = JsonUtility.ToJson(model);
        PlayerPrefs.SetString(PPF_Constants.SAVE_KEY, data);
        Debug.Log($"Saving data {data}");
    }

    private void OnDestroy() => Save();
    private void OnApplicationFocus(bool focusStatus) => Save();
    private void OnApplicationQuit() => Save();
    private void OnApplicationPause(bool pauseStatus) => Save();
}

public class SaveModel
{
    public EconomyModel economy = new EconomyModel();
    public List<RoomState> roomStates = new List<RoomState>();
    public int roomsUnlocked = 1;
}