using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public class Contato
        {
            public int Codigo { get; set; }
            public String Nome { get; set; }
            public string Telefone { get; set; }
        }

        private List<Contato> lista = new List<Contato>();

        private int codigo = -1;

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaDataGridView();
        }

        private void CarregaDataGridView()
        {
            AgendaContato.DataSource = lista.ToList();
        }

        private int ObterCodigo()
        {
            int retorno = 0;
       
            if (lista.Count == 0)
            {
                retorno = 1;
                return retorno;
            }
       
            else
            {
                retorno = lista.Max(x => x.Codigo) + 1;
                return retorno;
            }
        }

        private void LimpaControles()
        {
            textNome.Text = "";
            textTelefone.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            if (codigo == -1)
            {
                var Contato = new Contato();
                Contato.Codigo = ObterCodigo();
                Contato.Nome = textNome.Text;
                Contato.Telefone = textTelefone.Text;
                lista.Add(Contato);
                CarregaDataGridView();
                LimpaControles();
                MessageBox.Show("Contato inserido com sucesso!");
            }
            else
            {
                int cod = Convert.ToInt32(AgendaContato.CurrentRow.Cells[0].Value);
                var Contato = lista.SingleOrDefault(x => x.Codigo == cod);
                Contato.Nome = textNome.Text;
                Contato.Telefone = textTelefone.Text;
                CarregaDataGridView();
                LimpaControles();
                codigo = -1;
                MessageBox.Show("Contato Alterado com sucesso!");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
            if (AgendaContato.CurrentRow != null)
            {
                int cod = Convert.ToInt32(AgendaContato.CurrentRow.Cells[0].Value);
                codigo = cod;
                var Contato = lista.SingleOrDefault(x => x.Codigo == cod);
                textNome.Text = Contato.Nome;
                textTelefone.Text = Contato.Telefone;
            }
            else
            {
                MessageBox.Show("Você deve selecionar um Contato!");
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (AgendaContato.CurrentRow != null)
            {
                int cod = Convert.ToInt32(AgendaContato.CurrentRow.Cells[0].Value);
                var Contato = lista.SingleOrDefault(x => x.Codigo == cod);
                lista.Remove(Contato);
                CarregaDataGridView();
                MessageBox.Show("Contato Excluído com sucesso");
            }
            else
            {
                MessageBox.Show("Você deve selecionar um Contato!");
            }
        }
    }
}
