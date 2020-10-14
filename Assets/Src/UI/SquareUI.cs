using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Map;

public class SquareUI : MonoBehaviour
{
    public static SquareUI _instance;
    #region 文字
    /// <summary>
    /// 记录坐标和高度
    /// </summary>
    public Text Position;
    /// <summary>
    /// 地形种类
    /// </summary>
    public Text SQType;
    /// <summary>
    /// 地形标签
    /// </summary>
    public Text Tags;
    /// <summary>
    /// 地形说明
    /// </summary>
    public Text Info;
    #endregion


    private bool showing = false;
    private Square target;

    public void TakeSqure(Square get)
    {
        target = get;
        //UI设置
        Position.text = string.Format
            ("<X:{0} ,Y:{1}> H:{2}", target.Position.x, target.Position.y, target.Height);

        SQType.text = target.Type.ToString();

        StringBuilder tagSB = new StringBuilder();
        foreach(Square.SqureTag st in target.Tags)
        {
            tagSB.Append(st.ToString());
            tagSB.Append(",");
        }
        Tags.text = tagSB.ToString();

        if (!showing)
        {
            showup();
        }
    }

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void showup()
    {
        showing = true;
    }

    private void close()
    {
        showing = false;
    }
}
