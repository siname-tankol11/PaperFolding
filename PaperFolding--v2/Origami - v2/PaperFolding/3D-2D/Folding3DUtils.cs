using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // 添加这一行
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Imaging; // 用于 BitmapData 和 PixelFormat
using System.Runtime.InteropServices; // 用于 Marshal 类


namespace Origami
{
    /*
     * 
     *  1. XML 各种模板解析。
     *     格式设计：
     *     3D， 2D设计。映射关联？？
     *     因为是已知的，可以设计简单的数据结构来表征相关图形。
     *  2. 2D文件与3D图像的映射关联。
     *     测试所有2D模版生成3D图形的式样。
     *     包括四面体和六面体。
     *  3. 随机单元生成。 （镂空或其他给定图形。）
     *      三角形更为复杂一些
     *      四边形呢？边界判断更为容易？
     *  4. 2D渲染成图像
     *  5. 3D渲染。
     *  6. 多个3D渲染成图像。
     *  7. 尝试设计
     *  8. 导出设计：
     *      2D->3D
     *      任选一个平面2D模版，随机生成图案。
     *      11+2 = 13模版。  任意生成图形，如20个sampling
     *      
     *      生成标准答案，3D图形渲染的图片。
     *      1. 干扰1： 生成干扰答案， 对于有方向的图案，调整方案
     *      2. 干扰2： 对于非居中图形，适当偏移位置？？
     *      3. 干扰3：改变数据相对位置，比如，临接，对面。
     *      
     * 
     *      两个提问方式：
     *      问，那个图像不是模板生成的  （1个有错误） （如果针对性的设计干扰）
     *      问，那个图案是模板生成的。 （3个有错误）  
     *      
     * 
     *    3D-2D，如何展开？？？？给出任意的3D，给出多个视图？？
     *    
     *     设计题型？ 依据2D模版生成3D图像，把3D逆向展示为各类临接图形？？
     *         是否也有2类提问方式？？
     * 
     * 排布表示方法
以立方体的 6 个面为基准：

F（前面）、B（后面）（相对面）；
U（上面）、D（下面）（相对面）；
L（左面）、R（右面）（相对面）。

通过固定前面（F=1，利用对称性消除旋转冗余），分 5 类讨论后面（B）的可能值（2-6），每类对应 6 种剩余 4 个数字（U、R、D、L）的排列，共 30 种。
30 种不同排布（F=1 固定）
第一类：后面 B=2（剩余数字 3、4、5、6）
(F=1, B=2, U=3, R=4, D=5, L=6)
(F=1, B=2, U=3, R=4, D=6, L=5)
(F=1, B=2, U=3, R=5, D=4, L=6)
(F=1, B=2, U=3, R=5, D=6, L=4)
(F=1, B=2, U=3, R=6, D=4, L=5)
(F=1, B=2, U=3, R=6, D=5, L=4)
第二类：后面 B=3（剩余数字 2、4、5、6）
(F=1, B=3, U=2, R=4, D=5, L=6)
(F=1, B=3, U=2, R=4, D=6, L=5)
(F=1, B=3, U=2, R=5, D=4, L=6)
(F=1, B=3, U=2, R=5, D=6, L=4)
(F=1, B=3, U=2, R=6, D=4, L=5)
(F=1, B=3, U=2, R=6, D=5, L=4)
第三类：后面 B=4（剩余数字 2、3、5、6）
(F=1, B=4, U=2, R=3, D=5, L=6)
(F=1, B=4, U=2, R=3, D=6, L=5)
(F=1, B=4, U=2, R=5, D=3, L=6)
(F=1, B=4, U=2, R=5, D=6, L=3)
(F=1, B=4, U=2, R=6, D=3, L=5)
(F=1, B=4, U=2, R=6, D=5, L=3)
第四类：后面 B=5（剩余数字 2、3、4、6）
(F=1, B=5, U=2, R=3, D=4, L=6)
(F=1, B=5, U=2, R=3, D=6, L=4)
(F=1, B=5, U=2, R=4, D=3, L=6)
(F=1, B=5, U=2, R=4, D=6, L=3)
(F=1, B=5, U=2, R=6, D=3, L=4)
(F=1, B=5, U=2, R=6, D=4, L=3)
第五类：后面 B=6（剩余数字 2、3、4、5）
(F=1, B=6, U=2, R=3, D=4, L=5)
(F=1, B=6, U=2, R=3, D=5, L=4)
(F=1, B=6, U=2, R=4, D=3, L=5)
(F=1, B=6, U=2, R=4, D=5, L=3)
(F=1, B=6, U=2, R=5, D=3, L=4)
(F=1, B=6, U=2, R=5, D=4, L=3)

以上 30 种排布涵盖了所有通过旋转无法重合的立方体数字排布方式。

     * 
     
     */


    public class Folding3DUtils
    {
        // 初始化30种立方体排布的二维数组 [30, 6]
        // (F=1, B=2, U=3, R=4, D=5, L=6)


        //FBURDL
        public static int[] _faceMap = new int[] {0,2,4,1,5,3 };

        public static int[,] _faceMapGroup = new int[24, 6]
        {
            {0,2,4,1,5,3 },  //123456
            {0,2,1,5,3,4},   //163524
            {0,2,5,3,4,1},  //143265  
            {0,2,3,4,1,5}, //153642,

            {1,3,4,2,5,0}, //234156
            {1,3,0,4,2,5}, //254613
            {1,3,5,0,4,2},  //214365
            {1,3,2,5,0,4},  //264531 
  
            {2,0,4,3,5,1},  //341256
            {2,0,1,4,3,5},  //351624
            {2,0,5,1,4,3},  //321465
            {2,0,3,5,1,4},  //361542

            {3,1,4,0,5,2},  //412356
            {3,1,2,4,0,5},  //452631
            {3,1,5,2,4,0},  //432165
            {3,1,0,5,2,4},  //462513

            {4,5,2,1,0,3},  //526431
            {4,5,3,2,1,0},  //536142
            {4,5,0,3,2,1},  //546213
            {4,5,1,0,3,2},  //516324

            {5,4,0,1,2,3},  //625413
            {5,4,3,0,1,2},  //615342
            {5,4,2,3,0,1},  //645231
            {5,4,1,2,3,0},  //635124
        };

        public static int[,] _cubeArrangements = new int[30, 6]
        {
            // 第一类：B=2（剩余数字3、4、5、6）
            { 1, 2, 3, 4, 5, 6 },
            { 1, 2, 3, 4, 6, 5 },
            { 1, 2, 3, 5, 4, 6 },
            { 1, 2, 3, 5, 6, 4 },
            { 1, 2, 3, 6, 4, 5 },
            { 1, 2, 3, 6, 5, 4 },

            // 第二类：B=3（剩余数字2、4、5、6）
            { 1, 3, 2, 4, 5, 6 },
            { 1, 3, 2, 4, 6, 5 },
            { 1, 3, 2, 5, 4, 6 },
            { 1, 3, 2, 5, 6, 4 },
            { 1, 3, 2, 6, 4, 5 },
            { 1, 3, 2, 6, 5, 4 },

            // 第三类：B=4（剩余数字2、3、5、6）
            { 1, 4, 2, 3, 5, 6 },
            { 1, 4, 2, 3, 6, 5 },
            { 1, 4, 2, 5, 3, 6 },
            { 1, 4, 2, 5, 6, 3 },
            { 1, 4, 2, 6, 3, 5 },
            { 1, 4, 2, 6, 5, 3 },

            // 第四类：B=5（剩余数字2、3、4、6）
            { 1, 5, 2, 3, 4, 6 },
            { 1, 5, 2, 3, 6, 4 },
            { 1, 5, 2, 4, 3, 6 },
            { 1, 5, 2, 4, 6, 3 },
            { 1, 5, 2, 6, 3, 4 },
            { 1, 5, 2, 6, 4, 3 },

            // 第五类：B=6（剩余数字2、3、4、5）
            { 1, 6, 2, 3, 4, 5 },
            { 1, 6, 2, 3, 5, 4 },
            { 1, 6, 2, 4, 3, 5 },
            { 1, 6, 2, 4, 5, 3 },
            { 1, 6, 2, 5, 3, 4 },
            { 1, 6, 2, 5, 4, 3 }
        };


        // 初始化2种四面体排布的二维数组 [2, 4]
        // 每一行对应一种排布，列顺序：面0、面1、面2、面3
        public static int[,] _tetraArrangements = new int[2, 4]
        {
            { 1, 2, 3, 4 },  // 第一种排布
            { 1, 2, 4, 3 }   // 第二种排布（与第一种旋转不重合）
        };



        // 示例1：使用默认参数生成图片
        public static Bitmap[] GenerateDefaultImages()
        {
            return RandomImageGenerator.Generate6Images(null);
        }

        // 示例2：生成仅包含几何图形和箭头的图片
        public static Bitmap[] GenerateGeoArrowImages()
        {
            ImageGenerationOptions options = new ImageGenerationOptions
            {
                Size = 128,
                Categories = ImageCategory.Geometric | ImageCategory.Arrow,
                GeoUseRandomColors = true,
                AllowDuplicates = false
            };

            return RandomImageGenerator.Generate6Images(options);
        }

        // 示例3：生成高线条密度的线条图案
        public static Bitmap[] GenerateHighDensityLineImages()
        {
            ImageGenerationOptions options = new ImageGenerationOptions
            {
                Categories = ImageCategory.Lines,
                LineDensity = 30, // 高密度线条
                Size = 200
            };

            return RandomImageGenerator.Generate6Images(options);
        }

        public static List<int> GetUniqueRandomNumbers(int N, int num)
        {
            // 校验参数合法性
            int maxPossible = N + 1; // 0~N共N+1个数字

            // 场景1：num接近N（如N=100，num=80），用洗牌算法更高效（避免频繁去重）
            if (num >= maxPossible * 0.5) // 阈值可调整，此处取50%作为分界
            {
                // 生成完整序列
                List<int> allNumbers = Enumerable.Range(0, maxPossible).ToList();
                Random random = new Random();
                // 洗牌（用临时变量交换，兼容.NET Framework 4）
                for (int i = allNumbers.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    // 传统交换方式（替代元组赋值）
                    int temp = allNumbers[i];
                    allNumbers[i] = allNumbers[j];
                    allNumbers[j] = temp;
                }
                return allNumbers.Take(num).ToList();
            }
            // 场景2：num远小于N（如N=10000，num=3），用随机生成+去重更高效
            else
            {
                HashSet<int> resultSet = new HashSet<int>();
                Random random = new Random();
                // 循环生成随机数，直到收集到num个不重复数字
                while (resultSet.Count < num)
                {
                    int randomNum = random.Next(0, maxPossible); // 生成0~N的随机数
                    resultSet.Add(randomNum); // HashSet自动去重，重复的数字会被忽略
                }
                return resultSet.ToList();
            }
        }

 
public static  Bitmap GetSubBitmap(Bitmap source, Rectangle rect)
{
    if (source == null)
        throw new ArgumentNullException("source", "源Bitmap不能为空");
    
    // 确保矩形区域在源图像范围内
    if (rect.X < 0 || rect.Y < 0 || 
        rect.Right > source.Width || 
        rect.Bottom > source.Height)
    {
        throw new ArgumentException("矩形区域超出了源图像的范围", "rect");
    }
    
    // 克隆指定区域的图像
    return source.Clone(rect, source.PixelFormat);
}
    }

}
