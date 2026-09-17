using UnityEngine;
using System.Collections.Generic;

public class Json : MonoBehaviour
{
    public PlayerData playerData;

    private void Start()
    {
        playerData = JsonUtility.FromJson<PlayerData>(json);
    }

    [System.Serializable]
    public class PlayerData
    {
        public string username;
        public float level;
        public Resources resources;
        public List<string> units;
    }

    [System.Serializable]
    public class Resources
    {
        public int gold;
        public int wood;
        public int iron;
    }

    [TextArea(4, 10)] public string json;
}
