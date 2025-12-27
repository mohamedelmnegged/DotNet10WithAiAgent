using System;
using System.Windows.Forms;
using AiAgent.GuiChat.Agent;

namespace AiAgent.GuiChat
{
    public partial class MainForm : Form
    {
        private TextBox _chatBox;
        private TextBox _inputBox;
        private Button _sendButton;
        private readonly IAgentService _agentService;

        public MainForm()
        {
            _agentService = new LocalAgentService();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "AI Agent Chat";
            this.Width = 700;
            this.Height = 500;

            _chatBox = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Top,
                Height = 360
            };

            _inputBox = new TextBox()
            {
                Multiline = false,
                Dock = DockStyle.Bottom,
                Height = 24
            };

            _sendButton = new Button()
            {
                Text = "Send",
                Dock = DockStyle.Bottom,
                Height = 30
            };

            _sendButton.Click += SendButton_Click;

            this.Controls.Add(_chatBox);
            this.Controls.Add(_sendButton);
            this.Controls.Add(_inputBox);
        }

        private async void SendButton_Click(object? sender, EventArgs e)
        {
            var userMessage = _inputBox.Text.Trim();
            if (string.IsNullOrEmpty(userMessage))
                return;

            AppendMessage("User", userMessage);
            _inputBox.Clear();

            AppendMessage("Agent", "Thinking...");

            var response = await _agentService.GetReplyAsync(userMessage);

            // Remove the "Thinking..." line and append actual response.
            var current = _chatBox.Text;
            var lines = current.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            if (lines.Length > 0 && lines[^1].StartsWith("Agent: Thinking"))
            {
                // remove last line
                _chatBox.Text = string.Join(Environment.NewLine, lines, 0, lines.Length - 1) + Environment.NewLine;
            }

            AppendMessage("Agent", response);
        }

        private void AppendMessage(string who, string message)
        {
            _chatBox.AppendText($"{who}: {message}{Environment.NewLine}");
        }
    }
}
