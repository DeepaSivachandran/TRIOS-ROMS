using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    /// <summary>
    /// Drop this form/panel into your existing WinForms application.
    /// It shows a simple chat interface that talks to the ChatbotAPI.
    /// </summary>
    public class ChatForm : Form
    {
        // ── Controls ──────────────────────────────────
        private Panel pnlChat;
        private RichTextBox rtbHistory;
        private TextBox txtQuestion;
        private Button btnSend;
        private Button btnClear;
        private Label lblStatus;
        private Panel pnlInput;

        // ── Config ────────────────────────────────────
        // Change this to your server's IP/hostname if running on a different machine
        private const string API_BASE = "http://localhost:5050/api/chat";

        private readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        public ChatForm()
        {
            InitializeComponents();
            AppendMessage("🤖 Assistant", "Hello! I can answer questions about your sales, purchases, payments, and stock. What would you like to know?", Color.FromArgb(0, 120, 212));
        }

        // ── UI Builder ────────────────────────────────
        private void InitializeComponents()
        {
            this.Text = "Business Assistant";
            this.Size = new Size(700, 600);
            this.MinimumSize = new Size(500, 400);
            this.Font = new Font("Segoe UI", 9f);

            // Chat history area
            rtbHistory = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Font = new Font("Segoe UI", 9.5f)
            };

            // Status label
            lblStatus = new Label
            {
                Dock = DockStyle.Top,
                Height = 22,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8.5f),
                Padding = new Padding(4, 0, 0, 0)
            };

            // Input panel at bottom
            pnlInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(6)
            };

            txtQuestion = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10f),
               //
               //PlaceholderText = "Ask anything... e.g. 'Show pending payments', 'Today's sales total'"
            };
            txtQuestion.KeyDown += TxtQuestion_KeyDown;

            btnSend = new Button
            {
                Text = "Send",
                Dock = DockStyle.Right,
                Width = 70,
                BackColor = Color.FromArgb(0, 120, 212),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.Click += BtnSend_Click;

            btnClear = new Button
            {
                Text = "Clear",
                Dock = DockStyle.Right,
                Width = 60,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 4, 0)
            };
            btnClear.Click += (s, e) =>
            {
                rtbHistory.Clear();
                AppendMessage("🤖 Assistant", "Chat cleared. How can I help you?", Color.FromArgb(0, 120, 212));
            };

            pnlInput.Controls.Add(txtQuestion);
            pnlInput.Controls.Add(btnSend);
            pnlInput.Controls.Add(btnClear);

            // Suggested questions panel
            var pnlSuggestions = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                BackColor = Color.FromArgb(245, 245, 245),
                AutoScroll = false,
                Padding = new Padding(4, 4, 4, 0),
                WrapContents = false
            };

            string[] suggestions = {
                "Pending payments", "Today's sales", "Low stock items",
                "Top suppliers", "Monthly purchase total"
            };

            foreach (var s in suggestions)
            {
                var btn = new Button
                {
                    Text = s,
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(0, 0, 4, 0),
                    Font = new Font("Segoe UI", 8f)
                };
                btn.FlatAppearance.BorderColor = Color.LightGray;
                string captured = s;
                btn.Click += (_, __) =>
                {
                    txtQuestion.Text = captured;
                    btnSend.PerformClick();
                };
                pnlSuggestions.Controls.Add(btn);
            }

            // Assemble
            this.Controls.Add(rtbHistory);
            this.Controls.Add(lblStatus);
            this.Controls.Add(pnlSuggestions);
            this.Controls.Add(pnlInput);
        }

        // ── Send Message ──────────────────────────────
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text.Trim();
            if (string.IsNullOrEmpty(question)) return;

            txtQuestion.Clear();
            btnSend.Enabled = false;
            lblStatus.Text = "⏳ Thinking...";

            AppendMessage("👤 You", question, Color.FromArgb(40, 40, 40));

            try
            {
                var requestBody = JsonSerializer.Serialize(new { question });
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var response = await _http.PostAsync(API_BASE, content);

                var responseStr = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using (var doc = JsonDocument.Parse(responseStr))
                    {
                        string answer = doc.RootElement.GetProperty("answer").GetString() ?? "No answer received.";
                        int rowCount = doc.RootElement.GetProperty("rowCount").GetInt32();

                        AppendMessage("🤖 Assistant", answer, Color.FromArgb(0, 120, 212));
                        lblStatus.Text = $"✓ {rowCount} records found";
                    }
                }
                else
                {
                    using (var doc = JsonDocument.Parse(responseStr))
                    {
                        string error = doc.RootElement.TryGetProperty("Error", out var e2)
                            ? e2.GetString() ?? "Unknown error"
                            : responseStr;
                        AppendMessage("⚠️ Error", error, Color.DarkRed);
                        lblStatus.Text = "Error occurred";
                    }
                }
            }
            catch (TaskCanceledException)
            {
                AppendMessage("⚠️ Timeout", "The request took too long. Please try again.", Color.DarkOrange);
                lblStatus.Text = "Request timed out";
            }
            catch (HttpRequestException)
            {
                AppendMessage("⚠️ Connection Error",
                    "Cannot connect to the API server. Make sure ChatbotAPI is running on port 5050.",
                    Color.DarkRed);
                lblStatus.Text = "Connection failed";
            }
            finally
            {
                btnSend.Enabled = true;
                txtQuestion.Focus();
            }
        }

        private void TxtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSend.PerformClick();
            }
        }

        // ── Append Message to Chat ────────────────────
        private void AppendMessage(string sender, string message, Color senderColor)
        {
            if (rtbHistory.TextLength > 0)
                rtbHistory.AppendText("\n\n");

            // Sender name
            int start = rtbHistory.TextLength;
            rtbHistory.AppendText(sender + "\n");
            rtbHistory.Select(start, sender.Length);
            rtbHistory.SelectionColor = senderColor;
            rtbHistory.SelectionFont = new Font("Segoe UI", 9f, FontStyle.Bold);

            // Message text
            int msgStart = rtbHistory.TextLength;
            rtbHistory.AppendText(message);
            rtbHistory.Select(msgStart, message.Length);
            rtbHistory.SelectionColor = Color.FromArgb(30, 30, 30);
            rtbHistory.SelectionFont = new Font("Segoe UI", 9.5f);

            // Scroll to bottom
            rtbHistory.SelectionStart = rtbHistory.TextLength;
            rtbHistory.ScrollToCaret();
        }
    }
}
