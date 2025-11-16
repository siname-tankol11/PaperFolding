using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Origami
{
    // 使用二维数组表示立方体展开图
    [Serializable]
    public class CubeNet
    {
        // 11种标准展开图的预定义布局
        public static readonly List<CubeNet> StandardNets = new List<CubeNet>();
        public static readonly List<int[]> StandardMaps = new List<int[]>();
        public static readonly List<CubeNet[]> GroupNets = new List<CubeNet[]>();
        public static readonly List<int[]> GroupMaps = new List<int[]>();

        // 展开图的二维数组表示 (0表示空白，1-6表示立方体的面)
        public int[,] Layout { get; set; }

        public int[] IdMap { get; set; }

        //public static List<int[,]> similarNets = new List<int[,]>();
        //public static List<int[]> similarMaps = new List<int[]>();

        public static CubeNet refNet = null;



        // 展开图的名称/编号
        public string Name { get; set; }

        public CubeNet(string name, int[,] layout, int[] map)
        {
            Name = name;
            Layout = layout;
            IdMap = map;
        }

        // 静态构造函数：初始化11种标准展开图
        static CubeNet()
        {
            InitializeStandardNets();
        }

        // 自动计算相邻边
        public List<Edge> CalculateEdges()
        {
            var edges = new List<Edge>();
            int rows = Layout.GetLength(0);
            int cols = Layout.GetLength(1);

            // 检查每对相邻单元格
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Layout[i, j] == 0) continue; // 跳过空白单元格

                    // 检查右侧单元格
                    if (j + 1 < cols && Layout[i, j + 1] != 0)
                    {
                        edges.Add(new Edge(Layout[i, j], Layout[i, j + 1]));
                    }

                    // 检查下方单元格
                    if (i + 1 < rows && Layout[i + 1, j] != 0)
                    {
                        edges.Add(new Edge(Layout[i, j], Layout[i + 1, j]));
                    }
                }
            }

            return edges;
        }

        private static void InitializeStandardNets()
        {
            // 类型1: 1-4-1型 (6种) - 中间一行4个正方形，上下各1个
            StandardNets.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                { 5, 0, 0, 0 },
                { 1, 2, 3, 4 },
                { 6, 0, 0, 0 }
            }, new int[] { 0, 0, 0, 0, 0, 0 }));


            StandardNets.Add(new CubeNet("Type 1-4-1 (2)", new int[,] {
                    { 0, 5, 0, 0 },
                    { 1, 2, 3, 4 },
                    { 0, 6, 0, 0 }
                }, new int[] { 0, 0, 0, 0, 90, -90 }));


            StandardNets.Add(new CubeNet("Type 1-4-1 (3)", new int[,] {
                { 5, 0, 0, 0 },
                { 1, 2, 3, 4 },
                { 0, 6, 0, 0 }
            }, new int[] { 0, 0, 0, 0, 0, -90 }));

            StandardNets.Add(new CubeNet("Type 1-4-1 (4)", new int[,] {
                { 0, 5, 0, 0 },
                { 1, 2, 3, 4 },
                { 0, 0, 6, 0 }
            }, new int[] { 0, 0, 0, 0, 90, -180 }));

            StandardNets.Add(new CubeNet("Type 1-4-1 (5)", new int[,] {
                { 5, 0, 0, 0 },
                { 1, 2, 3, 4 },
                { 0, 0, 6, 0 },
            }, new int[] { 0, 0, 0, 0, 0, -180 }));

            StandardNets.Add(new CubeNet("Type 1-4-1 (6)", new int[,] {
                { 5, 0, 0, 0 },
                { 1, 2, 3, 4 },
                { 0, 0, 0, 6 },
            }, new int[] { 0, 0, 0, 0, 0, 90 }));

            // 类型2: 2-3-1型 (3种) - 中间一行3个正方形，上面2个，下面1个
            StandardNets.Add(new CubeNet("Type 2-3-1 (1)", new int[,] {
                { 4, 5, 0, 0 },
                { 0, 1, 2, 3 },
                { 0, 0, 0, 6 }
            }, new int[] { 0, 0, 0, 90, 0, -180 }));

            StandardNets.Add(new CubeNet("Type 2-3-1 (2)", new int[,] {
                { 4, 5, 0, 0 },
                { 0, 1, 2, 3 },
                { 0, 0, 6, 0 }
            }, new int[] { 0, 0, 0, 90, 0, -90 }));

            StandardNets.Add(new CubeNet("Type 2-3-1 (3)", new int[,] {
                { 4, 5, 0, 0 },
                { 0, 1, 2, 3 },
                { 0, 6, 0, 0 }
            }, new int[] { 0, 0, 0, 90, 0, 0 }));


            // 类型3: 2-2-2型 (1种) - 每层2个正方形，共3层
            StandardNets.Add(new CubeNet("Type 2-2-2", new int[,] {
                { 4, 5, 0, 0 },
                { 0, 1, 2, 0 },
                { 0, 0, 6, 3 }
            }, new int[] { 0, 0, 90, 90, 0, -90 }));

            // 类型4: 3-3型 (1种) - 两行各3个正方形交错排列
            StandardNets.Add(new CubeNet("Type 3-3", new int[,] {
                { 6, 4, 5,0,0 },
                { 0, 0, 1,2,3 },
            }, new int[] { 0, 0, 0, 90, 0, 180 }));

            //refNet = StandardNets[0].Layout;
            //refMap = StandardNets[0].IdMap;
            refNet = StandardNets[0];

            List<CubeNet> rowList = new List<CubeNet>();
            List<CubeNet> columnList = new List<CubeNet>();


            //1 位置临面2
            columnList.Add(  new CubeNet("Type 1-4-1 (1)", new int[,] {
                                            { 2, 0, 0, 0 },
                                            { 1, 6, 3, 5},
                                            { 4, 0, 0, 0 } }, 
                            new int[] { -90, -90, 90, -90, -90, -90 }));

            //1 位置临面3
            columnList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                           { 4, 0, 0, 0 },
                                            { 1, 5, 3, 6},
                                            { 2, 0, 0, 0 }  },
                new int[] { 90, 90, -90, 90, 90, 90 }));

            //1 位置临面4
            columnList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                             { 6, 0, 0, 0 },
                                            { 1, 4, 3, 2},
                                            { 5, 0, 0, 0  } },
              new int[] {180, 180, 180, 180, 180, 180 }));


            //2->1
            rowList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                             { 5, 0, 0, 0 },
                                            { 4, 1, 2, 3 },
                                            { 6, 0, 0, 0 } },
              new int[] { 0,0,0,0,-90,90 }));

            //3->1
            rowList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                             { 5, 0, 0, 0 },
                                            { 3, 4, 1, 2 },
                                            { 6, 0, 0, 0 } },
              new int[] { 0, 0, 0, 0, -180, 180 }));

            //4->1
            rowList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                            { 5, 0, 0, 0 },
                                            { 2, 3, 4, 1 },
                                            { 6, 0, 0, 0 } },
              new int[] { 0, 0, 0, 0, 90, -90 }));

            //5->1
            rowList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                            { 1, 0, 0, 0 },
                                            { 2, 5, 4, 6 },
                                            { 3, 0, 0, 0 }},
              new int[] { 90, 90, 90, -90, 180, 0 }));

            //6->1
            rowList.Add(new CubeNet("Type 1-4-1 (1)", new int[,] {
                                           { 3, 0, 0, 0 },
                                            { 4, 5, 2, 6 },
                                            { 1, 0, 0, 0 }},
              new int[] { 90, -90, 90, 90, 0, 180 }));

            List<CubeNet>  type1List= GenerateSimilarNet(refNet,  columnList, rowList);

            GroupNets.Add(type1List.ToArray());

            for (int i = 1; i < StandardNets.Count; i++)
            {
                List<CubeNet> tmpList = new List<CubeNet>();
                foreach (CubeNet net in type1List)
                {
                    tmpList.Add(MapCubeNet(refNet, net, StandardNets[i])); 
                }
                GroupNets.Add(tmpList.ToArray());
            }

        }

        private static List<CubeNet> GenerateSimilarNet(CubeNet refNet, List<CubeNet> columnNets, List<CubeNet> rowNets)
        {
            List<CubeNet> retList = new List<CubeNet>();

            retList.Add(refNet);
            retList.AddRange(columnNets);

            foreach (CubeNet row in rowNets)
            {
                retList.Add(row);

                foreach (CubeNet col in columnNets)
                {
                   retList.Add(MapCubeNet(refNet, col, row));
                }
            }

            return retList;
        }

        private static CubeNet MapCubeNet(CubeNet srcNet, CubeNet cube1, CubeNet cube2)
        { 
            CubeNet ret = DeepCopyHelper.DeepCopy(cube2);

            Dictionary<int, int> dicNum = new Dictionary<int, int>();

            for(int j= 0; j<srcNet.Layout.GetLength(0); j++)
                for (int i = 0; i < srcNet.Layout.GetLength(1); i++)
                {
                    if (srcNet.Layout[j, i] > 0)
                        dicNum.Add(srcNet.Layout[j, i], cube1.Layout[j, i]);
                }
            for (int j = 0; j < cube2.Layout.GetLength(0); j++)
                for (int i = 0; i < cube2.Layout.GetLength(1); i++)
                {
                    if (cube2.Layout[j, i] > 0)
                        ret.Layout[j, i] = dicNum[cube2.Layout[j, i]];
                }

            ret.IdMap = (int[])cube1.IdMap.Clone();

            for (int i = 0; i < 6; i++)
            {
                ret.IdMap[dicNum[i + 1] - 1] += cube2.IdMap[i];
               ret.IdMap[dicNum[i+1]-1] = AdjustVal(ret.IdMap[dicNum[i+1]-1]);
            }
            return ret;
        }

        private static int AdjustVal(int val)
        {
            return (val+3600) % 360;
        }

        static Random _rand = new Random(Environment.TickCount);


        public static CubeNet CreateRandomUnSimlar(CubeNet srcNet)
        {

            int[,] arranges = Folding3DUtils._cubeArrangements;
            int randId = _rand.Next() % arranges.GetLength(0);
            int[] faceMap = Folding3DUtils._faceMap;


                CubeNet net = DeepCopyHelper.DeepCopy(srcNet);

                Dictionary<int, int> dicM = new Dictionary<int, int>();
                for (int i = 0; i < arranges.GetLength(1); i++)
                {
                    int id = arranges[randId, i];

                    dicM.Add(faceMap[i] + 1, faceMap[id - 1] + 1);

                }
                net.ReplaceVal(dicM);


                return net;
        }

        public static List<CubeNet> CreateUnSimilarArray(CubeNet srcNet)
        {
            List<CubeNet> retList = new List<CubeNet>();

            int[,] arranges = Folding3DUtils._cubeArrangements;
            int[] faceMap = Folding3DUtils._faceMap;

            for (int j = 0; j < arranges.GetLength(0); j++)
            {
                CubeNet net = DeepCopyHelper.DeepCopy(srcNet);

                Dictionary<int, int> dicM = new Dictionary<int, int>();
                for (int i = 0; i < arranges.GetLength(1); i++)
                {
                    int id = arranges[j, i];

                    dicM.Add(faceMap[i]+1, faceMap[id-1]+1);
                    
                }
                net.ReplaceVal(dicM);

                retList.Add(net);
            }

            return retList;
        }

        //public static List<CubeNet> CreateUnSimilarArray(CubeNet srcNet, CubeNet cube1)
        //{
        //    List<CubeNet> retList = new List<CubeNet>();

            

        //    int[,] arranges = Folding3DUtils._cubeArrangements;
        //    int[] faceMap = Folding3DUtils._faceMap;

        //    for (int j = 0; j < arranges.GetLength(0); j++)
        //    {
        //        CubeNet net = DeepCopyHelper.DeepCopy(srcNet);

        //        Dictionary<int, int> dicM = new Dictionary<int, int>();
        //        for (int i = 0; i < arranges.GetLength(1); i++)
        //        {
        //            int id = arranges[j, i];

        //            dicM.Add(faceMap[i] + 1, faceMap[id - 1] + 1);

        //        }
        //        net.ReplaceVal(dicM);

        //        retList.Add(net);
        //    }

        //    return retList;
        //}

        public void ReplaceVal(Dictionary<int, int> dic)
        {
            for(int j=0; j<Layout.GetLength(0); j++)
                for (int i = 0; i < Layout.GetLength(1); i++)
                {
                    if (Layout[j, i] > 0)
                        Layout[j, i] = dic[Layout[j, i]];
                }
        }
    }

    // 表示立方体两个面之间的连接边
    public struct Edge
    {
        public int Face1;
        public int Face2;

        public Edge(int face1, int face2)
        {
            Face1 = Math.Min(face1, face2);
            Face2 = Math.Max(face1, face2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge)
            {
                return Face1 == ((Edge)obj).Face1 && Face2 == ((Edge)obj).Face2;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Face1 * 10) + Face2;
        }
    }
}