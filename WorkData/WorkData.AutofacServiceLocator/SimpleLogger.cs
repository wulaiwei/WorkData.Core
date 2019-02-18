using System;

namespace WorkData.AutofacServiceLocator
{
    public interface ILogger
    {
        string Get();
    }

    public class SimpleLogger : ILogger
    {
        public string  A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public string Get()
        {
            var sp = "123";
            for (int i = 0; i < 1000; i++)
            {
                sp += i;
            }
            return Guid.NewGuid().ToString()+ sp; 
        }
    }
}