using Microsoft.Extensions.Logging;

namespace AspNetCoreWebAppTodoList.Logging.Extensions
{
    internal static class Log4NetExt
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }
    }
}