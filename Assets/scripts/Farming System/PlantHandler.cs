using System.Collections;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
    public int FarmManagerID;
    private Plant _referencePlant;
    [SerializeField]
    private bool IsTree = false;
    [SerializeField]
    private Transform _plantMesh;
    private GrowingPhase _currntPhase;
    public bool IsPlantable(ItemHandler block)
    {
        _referencePlant = FarmDataHandler.Instance.FarmingManager.GetReferncePlant(FarmManagerID);

        if (_referencePlant == null) return false;

        foreach (ItemHandler handlingBlock in _referencePlant.PlantableBlocks)
        {
            if (handlingBlock.itemID == block.itemID)
            {
                return true;
            }
        }
        return false;
    }

    public void Plant()
    {
        StartCoroutine(OnPlanted());
    }

    private IEnumerator OnPlanted()
    {
        _referencePlant = FarmDataHandler.Instance.FarmingManager.GetReferncePlant(FarmManagerID);
        foreach (GrowingPhase phase in _referencePlant.Phases)
        {
            _currntPhase = phase;
            if (_currntPhase.PhaseMesh != null)
            {
                if (_plantMesh != null)
                {
                    Destroy(_plantMesh.gameObject);
                }
                _plantMesh = Instantiate(_currntPhase.PhaseMesh, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(_currntPhase.Duration);
            }
        }
        if (IsTree) Destroy(gameObject);
    }

    public void DestroyPlant()
    {
        StopAllCoroutines();

        if (_currntPhase.Drop.Count > 0)
        {
            foreach (ItemHandler dropPrefab in _currntPhase.Drop)
            {
                ItemHandler drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
                drop.OnDrop();
            }

        }
        if (_plantMesh != null) Destroy(_plantMesh.gameObject);
        Destroy(gameObject);
    }
}
