using UnityEngine;

public class LaserTower : Tower
{
    TargetPoint target;

    [SerializeField]
    Transform turret = default, laserBeam = default;
    
    Vector3 laserBeamScale;
    
    [SerializeField, Range(1f, 100f)]
    float damagePerSecond = 10f;

    public override TowerType TowerType => TowerType.Laser;

    public override void GameUpdate()
    {
        Debug.Log("Searching for target...");
        if (TrackTarget(ref target) || AcquireTarget(out target))
        {
            // Debug.Log("Locked on target");
            Shoot();
        }
        else
        {
            laserBeam.localScale = Vector3.zero;
        }
    }

    void Shoot()
    {
        Vector3 point = target.Position;
        turret.LookAt(point);
        laserBeam.localRotation = turret.localRotation;
        
		float d = Vector3.Distance(turret.position, point);
		laserBeamScale.z = d;
		laserBeam.localScale = laserBeamScale;
        laserBeam.localPosition = turret.localPosition + 0.5f * d * laserBeam.forward;
        
        target.Enemy.ApplyDamage(damagePerSecond * Time.deltaTime);
    }

    void Awake()
    {
        laserBeamScale = laserBeam.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
