using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DandD.Herois;
using DandD.Monstros;


namespace DandD.Telas
{
    public partial class frm_batalha : Form
    {
        public Heroi Heroi { get; set; }
        public Monstro Monstro { get; set; }

        bool cura_usada = false;

        public frm_batalha(Heroi heroi)
        {
            InitializeComponent();

            this.Heroi = heroi;

            lbl_agilidade.Text += Heroi.Status.Agilidade;
            lbl_defesa.Text += Heroi.Status.Defesa;
            lbl_forca.Text += Heroi.Status.Forca;
            lbl_sorte.Text += Heroi.Status.Sorte;
            lbl_mana.Text += Heroi.Status.Mana;
            lbl_vida.Text += Heroi.Status.Vida;

            if(this.Heroi.Classe != "Mago")
            {
                btn_curar.Enabled = false;
            }
         
            Random rand = new Random();
            int sorteio = rand.Next(0, 3);

            if (sorteio == 1)
            {
                pcb_monstro.Image = Properties.Resources.goblin;
                this.Monstro = new Goblin(1, 80, 5, 40, 5, 100, 10);
            }
            else if (sorteio == 2)
            {
                pcb_monstro.Image = Properties.Resources.aranha;
                this.Monstro = new Aranha(1, 110, 5, 10, 10, 130, 10);
            }
            else
            {
                pcb_monstro.Image = Properties.Resources.dragao;
                this.Monstro = new Dragao(1, 90, 10, 30, 10, 170, 1);
            }
            lbl_vidaMonstro.Text += Monstro.Status.Vida; 
        }

        private void btn_atacar_Click(object sender, EventArgs e)
        {
            this.Heroi.atacar(Monstro);
            lbl_vidaMonstro.Text = "Vida Monstro: " + Monstro.Status.Vida;

            lbl_vida.Text = "Vida: " + Heroi.Status.Vida;

            if (this.Monstro.Status.Vida <= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Deseja passar no mercado antes de prosseguir?", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frm_comprarItens menu = new frm_comprarItens(this.Heroi);
                    menu.ShowDialog();
                    this.Hide();
                }
                else
                {             
                    frm_batalha form = new frm_batalha(Heroi);
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                this.Monstro.atacar(Heroi);
            }

            if (Heroi.Status.Vida <= 0)
            {
                MessageBox.Show("GAME OVER");
            }
        }

        private void btn_curar_Click(object sender, EventArgs e)
        {
            if (!cura_usada)
            {
                Heroi.curar();
                lbl_vida.Text = "Vida: " + Heroi.Status.Vida;
                lbl_mana.Text = "Mana: " + Heroi.Status.Mana;

                cura_usada = true;
            }
            else
            {
                MessageBox.Show("Você já se curou neste turno");
            }
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 menu = new Form1();
            menu.Show();
        }
    }
}
