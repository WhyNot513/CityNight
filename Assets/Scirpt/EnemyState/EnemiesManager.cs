using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager inter_;
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();
    [SerializeField, Header("生成敌人数目")] int CreateAmount = 20;
    [SerializeField, Header("怪物生成点位置")] List<GameObject> CreatePoint = new List<GameObject>();//怪物生成点位置 //关卡yi
    [SerializeField, Header("怪物生成点位置")] List<GameObject> CreatePoint2 = new List<GameObject>();//怪物生成点位置 //关卡2
    public List<GameObject> EnemyDieVfx = new List<GameObject>();
    public List<GameObject> EnemyBullet = new List<GameObject>();
    List<Vector3> CreatePos = new List<Vector3>();//怪物生成点位置
    List<Vector3> CreatePos2 = new List<Vector3>();//怪物生成点位置
    public Dictionary<int, List<Vector3>> levelEnemyPos = new Dictionary<int, List<Vector3>>();
    public static List<GameObject> levelEnemy = new List<GameObject>();

    public static UnityAction<int> CreateEnemt = delegate { };

    public void Awake()
    {
        if (inter_ == null)
        {
            inter_ = this;
        }



    }
    private void Start()
    {
        CreateEnemt += createEnemies;

        foreach (GameObject obj in CreatePoint)
        {
            CreatePos.Add(obj.transform.localPosition);

        }
        foreach (GameObject obj in CreatePoint2)
        {
            CreatePos2.Add(obj.transform.localPosition);

        }
        levelEnemyPos.Add(0, CreatePos);
        levelEnemyPos.Add(1, CreatePos2);
        //  createEnemies();
    }
    private void OnDestroy()
    {
        CreateEnemt -= createEnemies;
    }
    public void OnEnable()
    {

    }
    void createEnemies()
    {
        for (int i = 0; i < CreateAmount; i++)
        {
            levelEnemy.Add(PoolManager.Release(Enemies[Random.Range(0, Enemies.Count)], CreatePos[Random.Range(0, CreatePos.Count)]));
        }
    }
    public void createEnemies(int level)
    {
        if (levelEnemy != null)
        {
            foreach (var item in levelEnemy)
            {
                item.SetActive(false);
            }
        }
        levelEnemy.Clear();
        for (int i = 0; i < CreateAmount; i++)
        {
            levelEnemy.Add(PoolManager.Release(Enemies[Random.Range(0, Enemies.Count)], levelEnemyPos[level][Random.Range(0, CreatePos.Count)]));
        }
    }
    public void BranchBullet(int index, Vector3 pos, float velocity)
    {
        var bullet = PoolManager.Release(EnemyBullet[index], pos);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
        //bullet.
    }
}
