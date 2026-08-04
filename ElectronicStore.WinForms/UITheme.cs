using System.Drawing.Drawing2D;

namespace ElectronicStore.WinForms;

public static class UITheme
{
    public static readonly Color HeaderBackground = Color.FromArgb(15, 23, 42);
    public static readonly Color FormBackground = Color.FromArgb(248, 250, 252);
    public static readonly Color CardBackground = Color.White;
    public static readonly Color Primary = Color.FromArgb(37, 99, 235);
    public static readonly Color Success = Color.FromArgb(16, 185, 129);
    public static readonly Color Danger = Color.FromArgb(239, 68, 68);
    public static readonly Color TextMain = Color.FromArgb(15, 23, 42);
    public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);
    public static readonly Color TextLight = Color.White;
    public static readonly Color Border = Color.FromArgb(226, 232, 240);

    private static readonly Font DefaultFont = new("Segoe UI", 10F, FontStyle.Regular);

    public static void ApplyFormTheme(Form form)
    {
        form.BackColor = FormBackground;
        form.Font = DefaultFont;
        form.ForeColor = TextMain;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimumSize = new Size(900, 600);
    }

    public static void StyleHeaderPanel(Panel panel, Label lblTitle, Label lblSubtitle)
    {
        panel.BackColor = HeaderBackground;
        panel.Padding = new Padding(28, 16, 28, 14);

        lblTitle.ForeColor = TextLight;
        lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
        lblTitle.AutoSize = true;

        lblSubtitle.ForeColor = Color.FromArgb(203, 213, 225);
        lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        lblSubtitle.AutoSize = true;
    }

    public static void StyleCardPanel(Panel panel)
    {
        panel.BackColor = CardBackground;
        panel.Padding = new Padding(22);
        panel.BorderStyle = BorderStyle.FixedSingle;
    }

    public static void StylePrimaryButton(Button btn) => StyleButton(btn, Primary, TextLight);
    public static void StyleSuccessButton(Button btn) => StyleButton(btn, Success, TextLight);
    public static void StyleDangerButton(Button btn) => StyleButton(btn, Danger, TextLight);
    public static void StyleSecondaryButton(Button btn) => StyleButton(btn, Color.FromArgb(226, 232, 240), TextMain);

    private static void StyleButton(Button btn, Color backColor, Color foreColor)
    {
        btn.BackColor = backColor;
        btn.ForeColor = foreColor;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Cursor = Cursors.Hand;
        btn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btn.Height = 38;
        btn.UseVisualStyleBackColor = false;
    }

    public static void StyleDataGridView(DataGridView dgv)
    {
        dgv.BackgroundColor = CardBackground;
        dgv.BorderStyle = BorderStyle.None;
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgv.GridColor = Border;
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackground;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextLight;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6);
        dgv.ColumnHeadersHeight = 44;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgv.DefaultCellStyle.BackColor = CardBackground;
        dgv.DefaultCellStyle.ForeColor = TextMain;
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
        dgv.DefaultCellStyle.SelectionForeColor = TextMain;
        dgv.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        dgv.RowTemplate.Height = 38;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToResizeRows = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    public static void StyleTextBox(TextBox txt)
    {
        txt.BackColor = Color.White;
        txt.ForeColor = TextMain;
        txt.BorderStyle = BorderStyle.FixedSingle;
        txt.Font = DefaultFont;
        txt.Margin = new Padding(0, 6, 0, 14);
    }

    public static void StyleComboBox(ComboBox cbo)
    {
        cbo.BackColor = Color.White;
        cbo.ForeColor = TextMain;
        cbo.FlatStyle = FlatStyle.Flat;
        cbo.Font = DefaultFont;
        cbo.DropDownStyle = ComboBoxStyle.DropDownList;
    }
}
