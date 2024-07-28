using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera GetCamera { get => _camera; }
    [SerializeField] private Camera _camera;
}
