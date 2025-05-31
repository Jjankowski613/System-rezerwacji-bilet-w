namespace Projekt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridViewFilmy = new DataGridView();
            tableLayoutPanelMiejsca = new TableLayoutPanel();
            textBoxImie = new TextBox();
            textBoxEmail = new TextBox();
            btnRezerwuj = new Button();
            labelImie = new Label();
            labelEmail = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilmy).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFilmy
            // 
            dataGridViewFilmy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFilmy.Location = new Point(22, 12);
            dataGridViewFilmy.Name = "dataGridViewFilmy";
            dataGridViewFilmy.Size = new Size(366, 150);
            dataGridViewFilmy.TabIndex = 0;
            dataGridViewFilmy.CellContentClick += dataGridView1_CellContentClick;
            dataGridViewFilmy.SelectionChanged += dataGridViewFilmy_SelectionChanged;
            // 
            // tableLayoutPanelMiejsca
            // 
            tableLayoutPanelMiejsca.ColumnCount = 2;
            tableLayoutPanelMiejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMiejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMiejsca.Location = new Point(470, 51);
            tableLayoutPanelMiejsca.Name = "tableLayoutPanelMiejsca";
            tableLayoutPanelMiejsca.RowCount = 2;
            tableLayoutPanelMiejsca.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMiejsca.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelMiejsca.Size = new Size(489, 279);
            tableLayoutPanelMiejsca.TabIndex = 1;
            tableLayoutPanelMiejsca.Paint += tableLayoutPanel1_Paint;
            // 
            // textBoxImie
            // 
            textBoxImie.Location = new Point(22, 199);
            textBoxImie.Name = "textBoxImie";
            textBoxImie.Size = new Size(100, 23);
            textBoxImie.TabIndex = 2;
            textBoxImie.TextChanged += textBoxImie_TextChanged;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(22, 260);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(165, 23);
            textBoxEmail.TabIndex = 3;
            textBoxEmail.TextChanged += textBox2_TextChanged;
            // 
            // btnRezerwuj
            // 
            btnRezerwuj.Location = new Point(22, 307);
            btnRezerwuj.Name = "btnRezerwuj";
            btnRezerwuj.Size = new Size(75, 23);
            btnRezerwuj.TabIndex = 4;
            btnRezerwuj.Text = "Rezerwuj";
            btnRezerwuj.UseVisualStyleBackColor = true;
            btnRezerwuj.Click += btnRezerwuj_Click;
            // 
            // labelImie
            // 
            labelImie.AutoSize = true;
            labelImie.Location = new Point(22, 181);
            labelImie.Name = "labelImie";
            labelImie.Size = new Size(33, 15);
            labelImie.TabIndex = 1;
            labelImie.Text = "Imię:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(22, 242);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(44, 15);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "E-mail:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 543);
            Controls.Add(labelImie);
            Controls.Add(labelEmail);
            Controls.Add(btnRezerwuj);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxImie);
            Controls.Add(tableLayoutPanelMiejsca);
            Controls.Add(dataGridViewFilmy);
            Name = "Form1";
            Text = "Rezerwacja miejsc w kinie";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilmy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewFilmy;
        private TableLayoutPanel tableLayoutPanelMiejsca;
        private TextBox textBoxImie;
        private TextBox textBoxEmail;
        private Button btnRezerwuj;
        private Label labelImie;
        private Label labelEmail;
        private ContextMenuStrip contextMenuStrip1;
    }
}
