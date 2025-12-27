using System;
using System.Windows.Forms;
using AiAgent.GuiChat.Agent;

namespace AiAgent.GuiChat
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
