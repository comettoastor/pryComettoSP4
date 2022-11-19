using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryComettoSP4
{
    public partial class frmMain : Form
    {
        public float[,] matImportes = new float[6,5];
        public void llenarMatriz()
        {
            for (int f = 0; f < matImportes.GetLength(0) - 1; f++)
            {
                for (int c = 0; c < matImportes.GetLength(1) - 1; c++)
                {
                    matImportes[f, c] = Convert.ToSingle(dgvMozos.Rows[f].Cells[c + 1].Value);
                }
            }

        }
        public void dgvMozosLoad()
        {
            dgvMozos.Rows.Add();
            dgvMozos[0, 0].Value = "Julio";
            dgvMozos.Rows.Add();
            dgvMozos[0, 1].Value = "Esteban";
            dgvMozos.Rows.Add();
            dgvMozos[0, 2].Value = "Javier";
            dgvMozos.Rows.Add();
            dgvMozos[0, 3].Value = "Gonzalo";
            dgvMozos.Rows.Add();
            dgvMozos[0, 4].Value = "Alberto";
            for (int c = 1; c < dgvMozos.ColumnCount; c++)
            {
                for (int f = 0; f < dgvMozos.Rows.Count; f++)
                {
                    if (dgvMozos[c, f].Value == null)
                    {
                        dgvMozos[c, f].Value = 0;
                    }
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvMozosLoad();
        }

        private void btnValidarDatos_Click(object sender, EventArgs e)
        {
            lstTotales.Items.Clear();
            txtMozoDia.Text = "";
            Array.Clear(matImportes,0,matImportes.Length);
            bool datosValidados = true;
            for (int c = 1; c < dgvMozos.ColumnCount; c++)
            {
                for (int r = 0; r < dgvMozos.Rows.Count; r++)
                {
                    if (dgvMozos[c, r].Value == null)
                    {
                        datosValidados = false;
                        MessageBox.Show("Faltan datos en:\nMozo: " + dgvMozos[0, r].Value + ", Categoría: " + dgvMozos.Columns[c].Name, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            if (datosValidados == true)
            {
                MessageBox.Show("Datos Validados Correctamente!","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnTotales.Enabled = true;
            }
            llenarMatriz();
            for (int f = 0; f < matImportes.GetLength(0) - 1; f++)
            {
                for (int c = 0; c < matImportes.GetLength(1) - 1; c++)
                {
                    matImportes[f, 4] = matImportes[f, 4] + matImportes[f, c];
                }
            }
            for (int c = 0; c < matImportes.GetLength(1) - 1; c++)
            {
                for (int f = 0; f < matImportes.GetLength(0) - 1; f++)
                {
                    matImportes[5, c] = matImportes[5, c] + matImportes[f, c];
                }
            }

            btnMozoDia.Enabled= true;
            btnTotales.Enabled= true;
        }

        private void btnTotales_Click(object sender, EventArgs e)
        {
            lstTotales.Items.Clear();
            lstTotales.Items.Add("Totales de Mozos");
            lstTotales.Items.Add("Total Julio: $" + matImportes[0, 4]);
            lstTotales.Items.Add("Total Esteban: $" + matImportes[1, 4]);
            lstTotales.Items.Add("Total Javier: $" + matImportes[2, 4]);
            lstTotales.Items.Add("Total Gonzalo: $" + matImportes[3, 4]);
            lstTotales.Items.Add("Total Alberto: $" + matImportes[4, 4]);
            lstTotales.Items.Add("─────────────────────────");
            lstTotales.Items.Add("Totales de Categorías");
            lstTotales.Items.Add("Total Comidas: $" + matImportes[5, 0]);
            lstTotales.Items.Add("Total Bebidas sin alcohol: $" + matImportes[5, 1]);
            lstTotales.Items.Add("Total Bebidas con alcohol: $" + matImportes[5, 2]);
            lstTotales.Items.Add("Total Postres: $" + matImportes[5, 3]);
            btnTotales.Enabled= false;
        }

        private void btnMozoDia_Click(object sender, EventArgs e)
        {
            float totalMayor = matImportes[0,0];
            int indice = 0;
            for (int f = 0; f < matImportes.GetLength(0) - 1; f++)
            {
                if (totalMayor < matImportes[f,4])
                {
                    totalMayor = matImportes[f, 4];
                    indice = f;
                }
            }
            if (indice == 0)
            {
                txtMozoDia.Text = "Julio - $" + matImportes[0, 4];
            }
            else
            {
                if (indice == 1)
                {
                    txtMozoDia.Text = "Esteban - $" + matImportes[1, 4];
                }
                else
                {
                    if (indice == 2)
                    {
                        txtMozoDia.Text = "Javier - $" + matImportes[2, 4];
                    }
                    else
                    {
                        if (indice == 3)
                        {
                            txtMozoDia.Text = "Gonzalo - $" + matImportes[3, 4];
                        }
                        else
                        {
                            if (indice == 4)
                            {
                                txtMozoDia.Text = "Alberto - $" + matImportes[4, 4];
                            }
                        }
                    }
                }
            }
            btnMozoDia.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
