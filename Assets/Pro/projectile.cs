using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject shootPoint;
    public Rigidbody2D BulletPrefab;
    public Rigidbody2D shadowPrefab;
    public GameObject effectArea;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 10f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                Instantiate(effectArea,hit.point,Quaternion.identity);
                
                Vector2 projectile = CalculateProjectileVelocity(shootPoint.transform.position, hit.point, 1f);
                
                Rigidbody2D fireBullet = Instantiate(BulletPrefab, shootPoint.transform.position, Quaternion.identity);
                fireBullet.velocity = projectile;
                
                
                Rigidbody2D shadow = Instantiate(shadowPrefab, shootPoint.transform.position + (transform.forward*1), Quaternion.identity);
                shadow.velocity = new Vector3(direction.x, direction.y);
                
            }


        }
        



    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t)
    {
        Vector3 distance = target - origin;
        
        float distX = distance.x;
        float disty = distance.y;

        float vX = distX / t;
        float vY = disty / t + 0.5f * Mathf.Abs(10) * t;

        Vector2 result = new Vector2(vX, vY);

        return result;

    }
        



        



}
