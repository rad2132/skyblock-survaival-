using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FarmlandHandler : MonoBehaviour
{
    [SerializeField]
    private LayerMask _LiquidLayer;
    [SerializeField]
    private ItemHandler _dryPrefab;
    public float Calldown = 30f;
    private void Awake()
    {
        StartCoroutine(CheckWaterNearby());
    }

    private IEnumerator CheckWaterNearby()
    {
        while (true)
        {
            yield return new WaitForSeconds(Calldown);
            Vector3 boxSize = new Vector3(.6f, .1f, .6f);
            List<Collider> colliders = Physics.OverlapBox(transform.position, boxSize, transform.rotation).ToList();
            bool blockDried = true;
            foreach (Collider collider in colliders)
            {
                Liquid liquid = collider.GetComponent<Liquid>();
                if (liquid != null && liquid.LiquidType == LiquidType.Water)
                {
                    blockDried = false;
                    break;
                }
            }

            if (blockDried)
            {
                plantPrefab();
                break;
            }

        }
    }

    private void plantPrefab()
    {
        Instantiate(_dryPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
