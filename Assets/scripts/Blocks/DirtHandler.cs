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
        StartCoroutine(CheckGrassNearby());
        enabled = true;
    }

    private IEnumerator CheckGrassNearby()
    {
        while (true)
        {
            yield return new WaitForSeconds(Calldown);
            Vector3 boxSize = new Vector3(.6f, .1f, .6f);
            List<Collider> colliders = Physics.OverlapBox(transform.position, boxSize, transform.rotation).ToList();
            
            foreach (Collider collider in colliders)
            {
                ItemHandler itemHandler = collider.GetComponent<ItemHandler>();
                if (itemHandler != null && itemHandler.gameObject.layer == gameObject.layer)
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
