using System.Collections.Generic;
using System;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            double expY = 0;
            bool isFirstElement = true;
            var e = data.GetEnumerator();

            while (e.MoveNext())
            {
                if (isFirstElement)
                {
                   expY = e.Current.OriginalY;
                    isFirstElement = false;
                }
                else
                    expY = alpha * e.Current.OriginalY + (1 - alpha) * expY;
                var newData = e.Current.WithExpSmoothedY(expY);
                yield return newData;
            }
        }
    }
}