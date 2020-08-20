using System;
using System.Threading;

namespace ATF.Windows.Common
{
    public class RetryHelper
    {
        public static T TryGetUntil<T>(Func<T> func, int maxTries = 30, int waitBetweenTries = 50)
        {
            var output = GetFunctionOutput(func);
            var numOfTries = 0;
            while (output == null && numOfTries < maxTries)
            {
                Thread.Sleep(waitBetweenTries);
                output = GetFunctionOutput(func);
                numOfTries++;
            }

            return output;
        }

        private static T GetFunctionOutput<T>(Func<T> func)
        {
            T output;
            try
            {
                output = func();
            }
            catch (Exception)
            {
                output = default;
            }

            return output;
        }
    }
}
