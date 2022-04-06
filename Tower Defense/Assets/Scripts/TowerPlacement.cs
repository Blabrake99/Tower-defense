using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject tower;
    public LayerMask placementCheckMask;
    public LayerMask placementCollideMask;
    public int towerCost;
    void Update()
    {
        if (tower != null)
        {
            Ray camray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitInfo;
            if (Physics.Raycast(camray, out HitInfo, 100f, placementCollideMask))
            {
                tower.transform.position = HitInfo.point;
            }
            if (Input.GetMouseButtonDown(0) && HitInfo.collider.gameObject != null)
            {
                if (!HitInfo.collider.gameObject.CompareTag("CantPlace") && !Player.ClickingOnTower(tower))
                {
                    BoxCollider towerCollider = tower.gameObject.GetComponent<BoxCollider>();
                    towerCollider.isTrigger = true;

                    Vector3 boxCenter = tower.gameObject.transform.position + towerCollider.center;
                    Vector3 halfExtents = towerCollider.size / 2;
                    if (Physics.CheckBox(boxCenter, halfExtents, Quaternion.identity, placementCheckMask, QueryTriggerInteraction.Ignore))
                    {
                        towerCollider.isTrigger = false;
                        tower.GetComponent<Turret>().active = true;
                        Player.UpdateCurrency(-towerCost);
                        tower = null;
                    }
                }
            }
        }
    }
}
