using Serilog;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace System
{
    public static class ConsoleEx
    {
        readonly static string messageHeader = "********************Data Layer - START LOG************************ \n";
        readonly static string messageFooter = "********************Data Layer - END LOG************************ \n";

        #region Console Extensions

        /// <summary>
        /// Writes the exception message to the console with the specified background and foreground colors
        /// </summary>
        /// <param name="Background">Background Color</param>
        /// <param name="Foreground">Foreground Color</param>
        /// <param name="Ex">Exception</param>
        /// <param name="Message">Message</param>
        public static void WriteLine(ConsoleColor? Background, ConsoleColor? Foreground, Exception Ex = null, string Message = null)
        {
            if (Background.HasValue)
                BackgroundColor = Background.Value;

            if (Foreground.HasValue)
                ForegroundColor = Foreground.Value;

            (Ex == null ? Message : Ex.Message)
                .ToConsole();
        }
        /// <summary>
        /// Writes the exception message to the console with a red background and white text
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Ex"></param>
        public static void WriteLineRed(string Message = null, Exception Ex = null)
        {
            BackgroundColor = ConsoleColor.Red;
            ForegroundColor = ConsoleColor.White;

            (Ex == null ? Message : Ex.Message)
                .ToConsole();
        }
        /// <summary>
        /// Writes the exception message to the console with a green background and black text
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Ex"></param>
        public static void WriteLineGreen(string Message = null, Exception Ex = null)
        {
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.Black;

            (Ex == null ? Message : Ex.Message)
                .ToConsole();
        }
        /// <summary>
        /// Writes the exception message to the console with a yellow background and black text
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Ex"></param>
        public static void WriteLineYellow(string Message = null, Exception Ex = null)
        {
            BackgroundColor = ConsoleColor.Yellow;
            ForegroundColor = ConsoleColor.Black;

            (Ex == null ? Message : Ex.Message)
                 .ToConsole();
        }
        /// <summary>
        /// Writes the exception message to the console with a blue background and white text
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Ex"></param>
        public static void WriteLineBlue(string Message = null, Exception Ex = null)
        {
            BackgroundColor = ConsoleColor.Blue;
            ForegroundColor = ConsoleColor.White;

            (Ex == null ? Message : Ex.Message)
                .ToConsole();
        }
        #endregion

        #region Logger Debug
        /// <summary>
        /// Logger and Console Debug Message in Blue
        /// </summary>
        /// <param name="l">Logger</param>
        /// <param name="Msg">Message Template</param>
        /// <param name="Ex">Exception</param>
        /// <param name="Value">Value to Include</param>
        public static void Debug(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Debug(Msg, Ex, Value);
            WriteLineBlue(Msg, Ex);
        }
        public static void DebugRed(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Debug(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);
        }
        public static void DebugGreen(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Debug(Msg, Ex, Value);
            WriteLineGreen(Msg, Ex);
        }
        public static void DebugBlue(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Debug(Msg, Ex, Value);
            WriteLineBlue(Msg, Ex);
        }
        public static void DebugYellow(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Debug(Msg, Ex, Value);
            WriteLineYellow(Msg, Ex);
        }
        #endregion

        #region Logger Warning
        /// <summary>
        /// Logger and Console Warning Message in Yellow
        /// </summary>
        /// <param name="l">Logger</param>
        /// <param name="Msg">Message</param>
        /// <param name="Ex">Exception</param>
        /// <param name="Value">Value to Include</param>
        public static void Warning(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Warning(Msg, Ex, Value);
            WriteLineYellow(Msg, Ex);
        }
        public static void WarningRed(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Warning(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);
        }
        public static void WarningGreen(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Warning(Msg, Ex, Value);
            WriteLineGreen(Msg, Ex);
        }
        public static void WarningBlue(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Warning(Msg, Ex, Value);
            WriteLineBlue(Msg, Ex);
        }
        public static void WarningYellow(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Warning(Msg, Ex, Value);
            WriteLineYellow(Msg, Ex);
        }
        #endregion

        #region Logger Error
        /// <summary>
        /// Logger and Console Error Message in Red
        /// </summary>
        /// <param name="l">Logger</param>
        /// <param name="Msg">Message</param>
        /// <param name="Ex">Exception</param>
        /// <param name="Value">Value to Include</param>
        public static void Error(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Error(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void ErrorRed(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Error(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void ErrorGreen(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Error(Msg, Ex, Value);
            WriteLineGreen(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void ErrorBlue(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Error(Msg, Ex, Value);
            WriteLineBlue(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void ErrorYellow(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Error(Msg, Ex, Value);
            WriteLineYellow(Msg, Ex);

            Msg.ToFileAsync();
        }
        #endregion

        #region Logger Fatal
        /// <summary>
        /// Logger and Console Error Message in Red
        /// </summary>
        /// <param name="l">Logger</param>
        /// <param name="Msg">Message</param>
        /// <param name="Ex">Exception</param>
        /// <param name="Value">Value to Include</param>
        public static void Fatal(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Fatal(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void FatalRed(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Fatal(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void FatalGreen(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Fatal(Msg, Ex, Value);
            WriteLineGreen(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void FatalBlue(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Fatal(Msg, Ex, Value);
            WriteLineBlue(Msg, Ex);

            Msg.ToFileAsync();
        }
        public static void FatalYellow(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Fatal(Msg, Ex, Value);
            WriteLineYellow(Msg, Ex);

            Msg.ToFileAsync();
        }
        #endregion

        #region Logger Information
        /// <summary>
        /// Logger and Console Information Message in Green
        /// </summary>
        /// <param name="l">Logger</param>
        /// <param name="Msg">Message</param>
        /// <param name="Ex">Exception</param>
        /// <param name="Value">Value to Include</param>
        public static void Information(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Information(Msg, Ex, Value);
            WriteLineGreen(Msg, Ex);
        }
        public static void InformationRed(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Information(Msg, Ex, Value);
            WriteLineRed(Msg, Ex);
        }
        public static void InformationGreen(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Information(Msg, Ex, Value);
            WriteLineGreen(Msg, Ex);
        }
        public static void InformationBlue(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Information(Msg, Ex, Value);
            WriteLineBlue(Msg, Ex);
        }
        public static void InformationYellow(this ILogger l, string Msg, Exception Ex = null, object Value = null)
        {
            l.Information(Msg, Ex, Value);
            WriteLineYellow(Msg, Ex);
        }
        #endregion

        #region Helper Methods
        static Task ToFileAsync(this string Msg)
        {
            var tempMessage = new[] { $"Error( {DateTime.UtcNow:HH:mm:ss} ): {Msg}" };
            var rootDirectory = Directory.GetCurrentDirectory();
            var errorLogPath = Path.Combine(rootDirectory, $"Logs\\errorLog{DateTime.UtcNow:yyyy-MM-dd-hh}.txt");

            File.AppendAllLinesAsync(
                path: errorLogPath,
                contents: tempMessage,
                cancellationToken: new CancellationToken());

            return Task.CompletedTask;
        }
        static void ToConsole(this string Message)
        {
            Console.WriteLine($"{messageHeader}\n\n{Message}\n\n{messageFooter}");

            BackToBlack();
        }
        static void BackToBlack()
        {
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}