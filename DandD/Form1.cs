﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DandD.Telas;
using DandD.Herois;

namespace DandD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_iniciarJogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_pontosStatus form = new frm_pontosStatus(txt_nome.ToString(), cbo_heroi.SelectedItem.ToString());
            form.ShowDialog();
        }

        private void btn_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
