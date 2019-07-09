using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudosTestes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:/Users/paulo/Documents/Aula5-VB") == false) {
                MessageBox.Show("O caminho informado não existe", "Informação", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Caminho encontrado!", "Informação", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            var arquivoOriginal = new FileStream("C:/Users/paulo/Documents/teste.txt", FileMode.Open);
            var arquivoNovo = new FileStream("C:/Users/paulo/Documents/teste_copia.txt", FileMode.Create);
            var buffer = new byte[1024];

            using (arquivoOriginal)
            using (arquivoNovo)
            {
                var bytesLidos = -1;
                while (bytesLidos != 0)
                {
                    bytesLidos = arquivoOriginal.Read(buffer, 0, 1024);
                    arquivoNovo.Write(buffer, 0, bytesLidos);
                }
            }

            var rodape = Encoding.UTF8.GetBytes("Este documento é uma cópia do original");
            arquivoNovo.Write(rodape, 0, rodape.Length);
        }
    }
}
