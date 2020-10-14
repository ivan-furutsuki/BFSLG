using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Command;
using Character;
using Map;

public class BattleControlUI : MonoBehaviour
{
    public static BattleControlUI bc;
    private Camera mainCamera;
    public Transform Selected = null;

    [SerializeField]
    private Transform selectMark;

    #region 文字元素
    
    #endregion


    public void GetCommandList()
    {

    }



    /// <summary>
    /// 选取地图块
    /// </summary>
    public void GetMapSqure()
    {

    }

    /// <summary>
    /// 选取操作物
    /// </summary>
    public void GetBasPO()
    {

    }

    public void ShowInfo()
    {

    }


    private void Awake()
    {

        bc = this;
        mainCamera = Camera.main;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rh = new RaycastHit();
        Ray clickRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(clickRay, out rh);

        if (hit)
        {
            //当点击时
            #region 点击
            if (Input.GetMouseButtonDown(0))
            {
                Selected = rh.transform;
                if (null != Selected.GetComponent<Square>())
                {

                    Debug.Log(Selected.GetComponent<Square>().ToString());
                    if (moveAllow)
                    {
                        //MoveChara(playerCharas[0].transform, Selected);
                    }

                }
                else if (null != Selected.GetComponent<Character.BasePO>())
                {

                }

            }
            #endregion

            Square qs = rh.transform.GetComponent<Square>();
            if (hit && null != qs)
            {
                MoveMark(rh.transform);
                SquareUI._instance.TakeSqure(qs);
            }
        }

        

    }


    private bool moveAllow = true;
    /// <summary>
    /// 棋子移动
    /// </summary>
    /// <param name="Chara">棋子Transform</param>
    /// <param name="DestiSquare">目的格Transform</param>
    private void MoveChara(Transform Chara, Transform DestiSquare)
    {
        if (!moveAllow)
        {
            return;
        }
        moveAllow = false;
        Debug.Log("Start" + Time.time);
        Chara.SetParent(DestiSquare);
        Chara.DOLocalMove(Vector3.up * 0.85f, CommonUtil.MovingDuration);
        Invoke("resetMoveControl", CommonUtil.MovingDuration);
    }

    /// <summary>
    /// 移动结束
    /// </summary>
    private void resetMoveControl()
    {
        moveAllow = true;
        Debug.Log("End" + Time.time);
    }


    /// <summary>
    /// 设置光标到指定方块
    /// </summary>
    /// <param name="target">方块Transform</param>
    private void MoveMark(Transform target)
    {
        selectMark.SetParent(target);
        selectMark.localPosition = Vector3.up * 0.52f;
    }
}
