using UnityEngine;

[DisallowMultipleComponent]
public class LevelFactory : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject horizontalWallPrefab;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private GameObject gazerPrefab;
    [SerializeField] private GameObject drunkenArcherPrefab;  

    [Header("Level file (Resources/Levels/<name>.json)")]
    [SerializeField] private string levelFileName = "exported_level"; // sin .json

    [Header("Import options")]
    [SerializeField] private bool positionsAreWorldSpace = true;
    [SerializeField] private float gridSize = 1f;

    [System.Serializable] private class LevelData { public LevelObject[] objects; }
    [System.Serializable]
    private class LevelObject
    {
        public string type;
        public float x, y;
        public float sx = 1f, sy = 1f;
        public float rot = 0f;
    }

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        var json = Resources.Load<TextAsset>($"Levels/{levelFileName}");
        if (!json) { Debug.LogError($"No se encontró Resources/Levels/{levelFileName}.json"); return; }

        var data = JsonUtility.FromJson<LevelData>(json.text);
        if (data?.objects == null) { Debug.LogError("JSON sin 'objects'"); return; }

        foreach (var o in data.objects)
        {
            var prefab = GetPrefabByType(o.type);
            if (!prefab) { Debug.LogWarning($"Tipo desconocido: {o.type}"); continue; }

            var pos = positionsAreWorldSpace ? new Vector3(o.x, o.y, 0f)
                                             : new Vector3(o.x * gridSize, o.y * gridSize, 0f);

            var go = Instantiate(prefab, pos, Quaternion.Euler(0, 0, o.rot));
            go.transform.localScale = new Vector3(o.sx, o.sy, 1f);
        }

        Debug.Log($"Nivel '{levelFileName}' instanciado ({data.objects.Length} objetos).");
    }

    private GameObject GetPrefabByType(string type)
    {
        switch (type)
        {
            case "Wall": return wallPrefab;
            case "HorizontalWall": return horizontalWallPrefab ? horizontalWallPrefab : wallPrefab;
            case "Exit": return exitPrefab;
            case "Gazer": return gazerPrefab;
            case "DrunkenArcher": return drunkenArcherPrefab;
            default: return null;
        }
    }
}
