using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Projekt
{
    public partial class Form1 : Form
    {
        private KinoContext? _context;
        private Film? _wybranyFilm;
        private readonly List<Miejsce> wybraneMiejsca = new();
        private Panel panelContainer;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Rezerwacja miejsc w kinie";
            dataGridViewFilmy.DataBindingComplete += dataGridViewFilmy_DataBindingComplete;
            dataGridViewFilmy.ReadOnly = true;
            dataGridViewFilmy.AllowUserToAddRows = false;
            dataGridViewFilmy.AllowUserToDeleteRows = false;



        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new KinoContext();
            _context.Database.EnsureCreated();
            _context.Filmy.Include(f => f.Sala).Load();
            dataGridViewFilmy.DataSource = _context.Filmy.Local.ToBindingList();
            dataGridViewFilmy.Columns["FilmId"].HeaderText = "ID";
            dataGridViewFilmy.Columns["Tytul"].HeaderText = "Film";
            dataGridViewFilmy.Columns["Data"].HeaderText = "Data";
            dataGridViewFilmy.Columns["SalaId"].HeaderText = "Numer sali";
            dataGridViewFilmy.Columns["Sala"].HeaderText = "Sala";

        }


        private void dataGridViewFilmy_SelectionChanged(object sender, EventArgs e)
        {
            if (_context == null || dataGridViewFilmy.CurrentRow == null) return;

            _wybranyFilm = (Film)dataGridViewFilmy.CurrentRow.DataBoundItem;
            if (_wybranyFilm != null)
            {
                _context.Entry(_wybranyFilm).Reference(f => f.Sala).Load();
                _context.Entry(_wybranyFilm.Sala).Collection(s => s.Miejsca).Load();
                GenerujWidokMiejsc(_wybranyFilm.Sala);
            }
        }

        private void GenerujWidokMiejsc(Sala sala)
        {
            tableLayoutPanelMiejsca.SuspendLayout(); // zatrzymaj rysowanie

            int rzadOd = 1;
            int rzadDo = sala.LiczbaRzedow;
            int kolumnaOd = 1;
            int kolumnaDo = sala.LiczbaMiejscWRzedzie;

            var miejscaWidoczne = sala.Miejsca
                .Where(m => m.Rzad >= rzadOd && m.Rzad <= rzadDo && m.Numer >= kolumnaOd && m.Numer <= kolumnaDo)
                .ToList();

            int widocznychRzedow = rzadDo - rzadOd + 1;
            int widocznychKolumn = kolumnaDo - kolumnaOd + 1;

            tableLayoutPanelMiejsca.Controls.Clear();
            tableLayoutPanelMiejsca.RowStyles.Clear();
            tableLayoutPanelMiejsca.ColumnStyles.Clear();

            int cellWidth = 28;
            int cellHeight = 28;

            tableLayoutPanelMiejsca.RowCount = widocznychRzedow + 1;
            tableLayoutPanelMiejsca.ColumnCount = widocznychKolumn + 1;

            for (int i = 0; i < tableLayoutPanelMiejsca.ColumnCount; i++)
                tableLayoutPanelMiejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellWidth));

            for (int i = 0; i < tableLayoutPanelMiejsca.RowCount; i++)
                tableLayoutPanelMiejsca.RowStyles.Add(new RowStyle(SizeType.Absolute, cellHeight));

            for (int col = 1; col <= widocznychKolumn; col++)
            {
                var labelTop = new Label
                {
                    Text = (kolumnaOd + col - 1).ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Font = new Font("Segoe UI", 6.5f),
                    Margin = new Padding(0),
                };
                tableLayoutPanelMiejsca.Controls.Add(labelTop, col, 0);
            }

            for (int row = 1; row <= widocznychRzedow; row++)
            {
                char litera = (char)('A' + rzadOd + row - 2);
                var labelLeft = new Label
                {
                    Text = litera.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Font = new Font("Segoe UI", 6.5f),
                };
                tableLayoutPanelMiejsca.Controls.Add(labelLeft, 0, row);
            }

            foreach (var miejsce in miejscaWidoczne)
            {
                var btn = new Button
                {
                    Width = cellWidth,
                    Height = cellHeight,
                    MaximumSize = new Size(cellWidth, cellHeight),
                    MinimumSize = new Size(cellWidth, cellHeight),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 5.5f),
                    Tag = miejsce,
                    Enabled = !miejsce.Zarezerwowane,
                    Margin = new Padding(0),
                    Dock = DockStyle.Fill
                };

                bool isSelected = wybraneMiejsca.Any(x => x.MiejsceId == miejsce.MiejsceId);

                btn.BackColor = miejsce.Zarezerwowane
                    ? Color.Gray
                    : isSelected
                        ? Color.ForestGreen
                        : Color.LightGreen;

                btn.Click += Miejsce_Click;

                int rowIndex = miejsce.Rzad - rzadOd + 1;
                int colIndex = miejsce.Numer - kolumnaOd + 1;

                tableLayoutPanelMiejsca.Controls.Add(btn, colIndex, rowIndex);
            }

            tableLayoutPanelMiejsca.ResumeLayout(); // wznowienie rysowania
                                                    // Oblicz rozmiar panelu na podstawie liczby kolumn i wierszy
            int panelWidth = (widocznychKolumn + 1) * cellWidth;  // +1 na etykiety kolumn
            int panelHeight = (widocznychRzedow + 1) * cellHeight; // +1 na etykiety rzêdów

            tableLayoutPanelMiejsca.Size = new Size(panelWidth, panelHeight);

        }


        private void Miejsce_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Miejsce miejsce)
            {
                var istnieje = wybraneMiejsca.FirstOrDefault(x => x.MiejsceId == miejsce.MiejsceId);
                if (istnieje != null)
                {
                    wybraneMiejsca.Remove(istnieje);
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    wybraneMiejsca.Add(miejsce);
                    btn.BackColor = Color.ForestGreen;
                }
            }
        }

        private void btnRezerwuj_Click(object sender, EventArgs e)
        {
            if (_context == null || _wybranyFilm == null)
            {
                MessageBox.Show("Nie wybrano filmu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxImie.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("WprowadŸ swoje dane: imiê i e-mail.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (wybraneMiejsca.Count == 0)
            {
                MessageBox.Show("Nie wybrano ¿adnych miejsc.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rezerwacja = new Rezerwacja
            {
                ImieNazwisko = textBoxImie.Text,
                Email = textBoxEmail.Text,
                Miejsca = new List<Miejsce>()
            };

            foreach (var miejsce in wybraneMiejsca)
            {
                var m = _context.Miejsca.FirstOrDefault(x => x.MiejsceId == miejsce.MiejsceId);
                if (m != null)
                {
                    m.Zarezerwowane = true;
                    m.Rezerwacja = rezerwacja;
                    rezerwacja.Miejsca.Add(m);
                }
            }

            _context.Rezerwacje.Add(rezerwacja);
            _context.SaveChanges();

            wybraneMiejsca.Clear();
            MessageBox.Show("Rezerwacja zakoñczona sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GenerujWidokMiejsc(_wybranyFilm.Sala);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _context?.Dispose();
        }
        private void dataGridViewFilmy_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridViewFilmy.Columns["FilmId"] != null)
                dataGridViewFilmy.Columns["FilmId"].Visible = false;

            if (dataGridViewFilmy.Columns["Sala"] != null)
                dataGridViewFilmy.Columns["Sala"].Visible = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBoxImie_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }


}
