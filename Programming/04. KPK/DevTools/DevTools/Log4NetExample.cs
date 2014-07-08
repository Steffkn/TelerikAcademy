namespace DevTools
{
    using System;
    using System.Linq;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Some log4net functionality example
    /// </summary>
    class Log4NetExample
    {
        private static readonly ILog log = LogManager.GetLogger("Login System");

        /// <summary>
        /// Main function
        /// </summary>
        static void Main()
        {
            BasicConfigurator.Configure();
            log.Debug("Debug msg");
            log.Error("Error msg");
            log.Info("Some Info about ur login");
            log.Info("Some Info about ur login", new Exception("Failed to login"));
        }

        /// <summary>
        /// Test Sandcastle
        /// </summary>
        private void SandcastleTest() { }
    }

}
