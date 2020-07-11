using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    List<Fire> all_fire;
    
    public Fire firePrefab;
    public float tileSize = 0.32f;

    private void Awake()
    {
            
    }

    // Start is called before the first frame update
    void Start()
    {
        all_fire = FindObjectsOfType<Fire>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveTurn();
        }
    }

    void MoveTurn()
    {
        bool has_spread = false;

        List<Fire> new_flames = new List<Fire>();
        foreach (Fire fire in all_fire)
        {
            Vector2 upPos = new Vector2(fire.transform.position.x, fire.transform.position.y + tileSize);
            RaycastHit2D upHit = Physics2D.Raycast(upPos, Vector2.zero);
            if (upHit.collider == null)
            {
                Fire new_fire = Instantiate(firePrefab, upPos, Quaternion.identity, fire.transform.parent);
                new_flames.Add(new_fire);
                has_spread = true;
            }

            Vector2 leftPos = new Vector2(fire.transform.position.x - tileSize, fire.transform.position.y);
            RaycastHit2D leftHit = Physics2D.Raycast(leftPos, Vector2.zero);
            if (leftHit.collider == null)
            {
                Fire new_fire = Instantiate(firePrefab, leftPos, Quaternion.identity, fire.transform.parent);
                new_flames.Add(new_fire);
                has_spread = true;
            }
            else
            {
                if (leftHit.collider.tag == "Protected")
                {
                    Debug.Log("GameLose");
                }
            }



            Vector2 rightPos = new Vector2(fire.transform.position.x + tileSize, fire.transform.position.y);
            RaycastHit2D rightHit = Physics2D.Raycast(rightPos, Vector2.zero);
            if (rightHit.collider == null)
            {
                Fire new_fire = Instantiate(firePrefab, rightPos, Quaternion.identity, fire.transform.parent);
                new_flames.Add(new_fire);
                has_spread = true;
            }

            Vector2 downPos = new Vector2(fire.transform.position.x, fire.transform.position.y - tileSize);
            RaycastHit2D downHit = Physics2D.Raycast(downPos, Vector2.zero);
            if (downHit.collider == null)
            {
                Fire new_fire = Instantiate(firePrefab, downPos, Quaternion.identity, fire.transform.parent);
                new_flames.Add(new_fire);
                has_spread = true;
            }
        }

        all_fire.AddRange(new_flames);

        if (!has_spread)
        {
            Debug.Log("GameWin");
            // TODO game win
        }
    }
}

