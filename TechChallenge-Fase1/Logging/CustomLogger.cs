using System.Reflection;

namespace TechChallenge_Fase1.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _loggerConfig;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerName = loggerName;
            _loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var mensagem = string.Format("{0} - {1} - {2} - {3}", logLevel.ToString(), eventId.Id, formatter(state, exception), exception?.Message);
            GravarLog(mensagem);
        }

        private void GravarLog(string mensagem)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string logsFolderName = "Logs";

            string logsFolderPath = Path.Combine(baseDirectory, logsFolderName);

            Directory.CreateDirectory(logsFolderPath);
            string caminho = Path.Combine(logsFolderPath, "arquivo.log");

            using StreamWriter sw = new StreamWriter(caminho, true);
            sw.WriteLine(mensagem);
            sw.Flush();
            sw.Close();
        }
    }
}
