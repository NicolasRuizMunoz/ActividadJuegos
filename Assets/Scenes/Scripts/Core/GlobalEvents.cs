using UnityEngine;
using System;

[DisallowMultipleComponent]
public class GlobalEvents : MonoBehaviour
{
    public static GlobalEvents Instance { get; private set; }

    // Eventos que cualquiera puede observar
    public event Action OnWin;
    public event Action OnLose;
    public event Action OnWallBump; // opcional (para beep al chocar pared)

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Métodos para emitir eventos
    public void RaiseWin() => OnWin?.Invoke();
    public void RaiseLose() => OnLose?.Invoke();
    public void RaiseWallBump() => OnWallBump?.Invoke();
}
