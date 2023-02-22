using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchBullets : MonoBehaviour
{
    public AudioData AttackaudioData;
    [SerializeField] VoidEventChanels VoidEventChanels_BranchBullets;
    [SerializeField] VoidEventChanels VoidEventChanels_StopBranches;
    public List<GameObject> bulletType = new List<GameObject>();
    public int indexBullet;
    float BranchDir;
    [SerializeField, Header("子弹发射速度")] float bulletVelocity = 1f;
    [SerializeField, Header("子弹发射间隔")] float BranchTime = 1f;
    WaitForSeconds WaitForSecondsBulletTime;
    public PlayerInput playerInput;
    private void Awake()
    {

        WaitForSecondsBulletTime = new WaitForSeconds(BranchTime);
    }

    private void OnEnable()
    {
        VoidEventChanels_BranchBullets.AddListener(BranchBullet);
        VoidEventChanels_StopBranches.AddListener(StopBranchBulletCoroutine);

    }
    private void OnDisable()
    {
        VoidEventChanels_BranchBullets.RemoveListener(BranchBullet);
        VoidEventChanels_StopBranches.AddListener(StopBranchBulletCoroutine);
    }

    void branch()
    {
        BranchDir = this.transform.parent.transform.localScale.x;
        var bullet = PoolManager.Release(bulletType[indexBullet]);
        bullet.transform.localScale = new Vector3(BranchDir, bullet.transform.localScale.y, bullet.transform.localScale.z);
        bullet.transform.localPosition = this.transform.position;
        bullet.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity * BranchDir, 0);
        AduioManager.instance.PlayerSFX(AttackaudioData);
    }

    void BranchBullet()
    {
        StopCoroutine(nameof(BranchBulletCoroutine));
        StartCoroutine(nameof(BranchBulletCoroutine));
    }

    void StopBranchBulletCoroutine()
    {
        StopCoroutine(nameof(BranchBulletCoroutine));
    }
    IEnumerator BranchBulletCoroutine()
    {
        while (true)
        {
            branch();
            yield return WaitForSecondsBulletTime;

        }

    }
    private void Update()
    {
        if (playerInput.SwithBullet && bulletType.Count > 1)
        {
            indexBullet = indexBullet == 0 ? 1 : 0; //切换子弹
        }
    }



}
