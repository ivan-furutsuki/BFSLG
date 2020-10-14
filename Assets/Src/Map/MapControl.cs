using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Map
{
    /// <summary>
    /// 包括地图的所有主控操作.包含在地图内的点击,
    /// </summary>
    public class MapControl : MonoBehaviour
    {
        public Square[,] Squares;
        public Object SquareCube;

        [SerializeField]
        private List<Character.BaseChar> playerCharas;


        // Start is called before the first frame update
        void Start()
        {
            MapBuild(5, 6);
        }

        // Update is called once per frame
        void Update()
        {
          


        }

        /// <summary>
        /// 临时生成格子用方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MapBuild(int x,int y)
        {
            Squares = new Square[x, y];
            //Squares[0, 0] = BuildSquare();
            //Squares[0, 0].SetPosition(1, 1, 0.5f);
            //Debug.Log(Squares[0, 0].ToString());
            for (int i = 0; i < x; i++)
                //外层X循环
            {
                for(int j = 0; j < y; j++)
                {
                    Squares[i,j]= BuildSquare();
                    Squares[i, j].SetPosition(i + 1, j + 1);
                }

            }
            //Square.Instantiate
        }



        /// <summary>
        /// 生成方块用
        /// </summary>
        /// <returns></returns>
        private Square BuildSquare()
        {
            GameObject temp = (GameObject)Instantiate(SquareCube, this.transform);
            return temp.GetComponent<Square>();
        }


        /// <summary>
        /// 地图格坐标,用以指示格子,或相对位置(含以个人视角为参照方向时).
        /// </summary>
        public struct 坐标
        {
            /// <summary>
            /// 东+西-方向,左-右+方向
            /// </summary>
            public int x;
            /// <summary>
            /// 南-北+方向,前+后-方向
            /// </summary>
            public int y;
        }

        /// <summary>
        /// 方向东
        /// </summary>
        public 坐标 Direction_East
        {
            get
            {
                return new 坐标 { x = 1, y = 0 };
            }
        }

        /// <summary>
        /// 方向西
        /// </summary>
        public 坐标 Direction_West
        {
            get
            {
                return new 坐标 { x = -1, y = 0 };
            }
        }

        /// <summary>
        /// 方向南
        /// </summary>
        public 坐标 Direction_South
        {
            get
            {
                return new 坐标 { x = 0, y = -1 };
            }
        }

        /// <summary>
        /// 方向北
        /// </summary>
        public 坐标 Direction_North
        {
            get
            {
                return new 坐标 { x = 0, y = 1 };
            }
        }
    }
}

