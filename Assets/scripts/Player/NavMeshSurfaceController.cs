using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshSurfaceController : MonoBehaviour
{
    public static NavMeshSurfaceController Instance;
    [SerializeField]
    private NavMeshSurface NavMeshSurface;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

    }
    public void GenerateNavmesh()
    {
        NavMeshSurface.BuildNavMesh();
    }
}
