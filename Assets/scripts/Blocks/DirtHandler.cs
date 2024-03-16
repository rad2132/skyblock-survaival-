using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DirtHandler : MonoBehaviour
{
    public float Calldown = 30f;
    [SerializeField]
    private ItemHandler grassPrefab;
    private void Awake()
    {
        CheckGrassNearby();
        
    }

    private IEnumerator CheckGrassNearby()
    {
        while (true)
        {
            yield return new WaitForSeconds(Calldown);
            Vector3 boxSize = new Vector3(2f, 0.1f, 2f);
            List<Collider> colliders = Physics.OverlapBox(transform.position, boxSize, Quaternion.identity, gameObject.layer).ToList();

            foreach (Collider collider in colliders)
            {
                ItemHandler itemHandler = collider.GetComponent<ItemHandler>();
                if (itemHandler != null)
                {
                    if (itemHandler.itemID == grassPrefab.itemID)
                    {
                        PlantGrass();
                        break;
                    }
                }
            }
        }

    }

    private void PlantGrass()
    {
        Instantiate(grassPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
