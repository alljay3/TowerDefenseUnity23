using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject spiritPrefab;
    [SerializeField] private int Hp;
    public int damage = 1;
    public float speed = 2;
    public int giveMoney = 1;
    public bool freezEffect = false;
    private MoveToWayPoints moveToWayPoints;
    private Coroutine coroutineDamageForSecond;
    public int curHp {get;set; }
    private Animator _anim;
    public bool flipX = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        moveToWayPoints = GetComponent<MoveToWayPoints>();
        moveToWayPoints.flipX = flipX;
        curHp = Hp;
    }

    public void selfDmg(int dmg)
    {
        curHp -= dmg;
    }

    private bool IsWounded()
    {
        if (curHp < Hp / 2)
            return true;
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {
        moveToWayPoints.Speed = speed;
        if (curHp <= 0)
        {
            thisKill();
        }
        _anim?.SetBool("wounded", IsWounded());
    }


    void thisKill()
    {
        MeinScript.CurMoney += giveMoney;
        GameObject b = GameObject.Instantiate(spiritPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }

    IEnumerator DamageForSecond(int second, int dmg)
    {
        while (true)
        {
            selfDmg(dmg);
            yield return new WaitForSeconds(second);
        }
    }

    public void StartDamageForSecond(int second, int dmg)
    {
        if (coroutineDamageForSecond == null)
        {
            coroutineDamageForSecond = StartCoroutine(DamageForSecond(second,dmg));
        }
    }

    public void StopDamageForSecond()
    {
        if (coroutineDamageForSecond != null)
        {
            StopCoroutine(coroutineDamageForSecond);
            coroutineDamageForSecond = null;
        }
    }
}
