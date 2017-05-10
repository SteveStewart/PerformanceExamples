using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructPerformanceGains
{
    /// <summary>
    /// Run without debugging enabled, ctrl & f5.
    /// </summary>
    public class StructTest
    {
        public void BeginTest()
        {
            var count = 10000000;

            Point2D[] point2Ds = new Point2D[count];
            Point2DStruct[] point2DStructs = new Point2DStruct[count];

            //Create a load of point2D in heap and a load of point2DStruct in the stack.
            for (int i = 0; i < count; ++i)
            {
                point2Ds[i] = new Point2D{X = i, Y = 10};
                point2DStructs[i] = new Point2DStruct{X=i, Y=10};
            }

            UpdatePoint2DY(point2Ds[1], 1);
            UpdatePoint2DStructY(ref point2DStructs[1], 1);

            //Next, we are going retrieve and update values in both and time it.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < count; i++)
            {
                UpdatePoint2DY(point2Ds[i], i);
            }

            long point2DTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

            for (int i = 0; i < count; i++)
            {
                //Passing a ref to the value type to ensure a copy is not made.
                UpdatePoint2DStructY(ref point2DStructs[i], i);
            }

            long point2DStructTime = stopwatch.ElapsedMilliseconds;
            
            Console.WriteLine($"Struct:{point2DStructTime} Class:{point2DTime}");
        }

        void UpdatePoint2DStructY(ref Point2DStruct point2DStruct, int count)
        {
            point2DStruct.Y = count;
        }

        void UpdatePoint2DY(Point2D point2D, int count)
        {
            point2D.Y = count;
        }

    }
}
