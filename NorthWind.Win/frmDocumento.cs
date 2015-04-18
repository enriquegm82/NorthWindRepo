using NorthWind.DAO;
using NorthWind.Entity;
using NorthWind.Win.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind.Win
{
    public partial class frmDocumento : Form
    {
        public frmDocumento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton Seleccionar Cliente
            frmCliente oFrmCliente = new frmCliente();
            oFrmCliente.onClienteSeleccionado += new EventHandler<TbClienteBE>(
                oFrmCliente_OnClienteSeleccionado);
            oFrmCliente.Show();
        }

        TbClienteBE otmpCliente;
        void oFrmCliente_OnClienteSeleccionado(object sender, TbClienteBE e)
        {
            txtcliente.Text = e.Nombre;
            txtruc.Text = e.Ruc;
            otmpCliente = e;
        }

        TbProductoBE otmpProducto;
        void oFrmProducto_OnProductoSeleccionado(object sender, TbProductoBE e)
        {
            txtproducto.Text=e.Descripcion;
            txtprecio.Text=e.Precio;
            otmpProducto = e;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton Seleccionar Producto
            frmProducto oFrmProducto = new frmProducto();
            oFrmProducto.onProductoSeleccionado += new EventHandler<TbProductoBE>(
                oFrmProducto_OnProductoSeleccionado);
            oFrmProducto.Show();
        }

        DocumentoBL oFacturaBL = new DocumentoBL();
        private void button3_Click(object sender, EventArgs e)
        {
            //Validar TextBox Cantidad Sea Numerico y != Nulo
            string cantidad = txtcantidad.Text;
            if (string.IsNullOrWhiteSpace(cantidad) || !(cantidad.Any(Char.IsDigit)))
            {
                MessageBox.Show("Por favor ingresar cantidad con valores numericos y diferente a Nulo");
                txtcantidad.Focus();
                return;
            }
            
            //Boton Agregar a Factura
            oFacturaBL.AgregarDetalle(new ItemBE()
            {
                Cantidad= Convert.ToInt32(txtcantidad.Text),
                Precio=Convert.ToDecimal(txtprecio.Text),
                Producto = otmpProducto
            });

            //Actualizar DataGrid
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = oFacturaBL.GetDetalle();

            txtsubtotal.Text = oFacturaBL.SubTotal.ToString();
            txtigv.Text = oFacturaBL.IGV.ToString();
            txttotal.Text = oFacturaBL.Total.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<ItemBE> Lista = new List<ItemBE>();
            Lista = oFacturaBL.GetDetalle();
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                if (i < 0) {return;}
                string Numitem = dataGridView1.Rows[i].Cells[0].Value.ToString();
                int iNumItem = Convert.ToInt32(Numitem);
                ItemBE oItem = (from item in Lista.ToArray()
                                where item.Item.Equals(iNumItem)
                                select item).Single();

                //Boton Eliminar Detalle
                oFacturaBL.EliminarDetalle(oItem);

                //Actualizar DataGrid
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = oFacturaBL.GetDetalle();

                txtsubtotal.Text = oFacturaBL.SubTotal.ToString();
                txtigv.Text = oFacturaBL.IGV.ToString();
                txttotal.Text = oFacturaBL.Total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existen items en el detalle");
                return;
            }

        }
    }
}
