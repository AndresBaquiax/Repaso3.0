namespace Repaso3._0
{
    public partial class Form1 : Form
    {
        List<Propietario> listPropietarios = new List<Propietario>();
        List<Propiedad> listPropiedades = new List<Propiedad>();
        List<Combinacion> listCombinacion = new List<Combinacion>();
        List<Combinacion> listCombinacionAltas = new List<Combinacion>();
        List<Combinacion> listCombinacionBajas = new List<Combinacion>();
        List<Combinacion> listCombinacionValorAlto = new List<Combinacion>();
        public Form1()
        {
            InitializeComponent();
        }
        private void cargarPropietarios()
        {
            FileStream stream = new FileStream("Propietarios.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propietario objPropietarios = new Propietario();
                objPropietarios.dpi = reader.ReadLine();
                objPropietarios.nombre = reader.ReadLine();
                objPropietarios.apellido = reader.ReadLine();
                listPropietarios.Add(objPropietarios);
            }
            reader.Close();
        }
        private void cargarPropiedades()
        {
            FileStream stream = new FileStream("Propiedades.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propiedad objPropiedad = new Propiedad();
                objPropiedad.numeroCasa = reader.ReadLine();
                objPropiedad.dpiDueno = reader.ReadLine();
                objPropiedad.cuotaMantenimiento = Convert.ToDecimal(reader.ReadLine());
                listPropiedades.Add(objPropiedad);
            }
            reader.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarPropiedades();
            cargarPropietarios();
            foreach (var a in listPropietarios)
            {
                foreach (var b in listPropiedades)
                {
                    if (a.dpi == b.dpiDueno)
                    {
                        Combinacion objCombinaciones = new Combinacion();
                        objCombinaciones.nombre = a.nombre;
                        objCombinaciones.apellido = a.apellido;
                        objCombinaciones.numeroCasa = b.numeroCasa;
                        objCombinaciones.cuotaMantenimiento = b.cuotaMantenimiento;
                        listCombinacion.Add(objCombinaciones);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = listCombinacion;
            dataGridView1.Refresh();
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            listCombinacion = listCombinacion.OrderByDescending(a => a.cuotaMantenimiento).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = listCombinacion;
            dataGridView1.Refresh();
        }

        private void buttonCuotasAltas_Click(object sender, EventArgs e)
        {
            listCombinacionAltas = listCombinacion.OrderByDescending(a => a.cuotaMantenimiento).Take(3).ToList();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = listCombinacionAltas;
            dataGridView2.Refresh();
        }

        private void buttonCuotasBajas_Click(object sender, EventArgs e)
        {
            listCombinacionBajas = listCombinacion.OrderByDescending(a => a.cuotaMantenimiento).TakeLast(3).ToList();
            dataGridView3.DataSource = null;
            dataGridView3.Refresh();
            dataGridView3.DataSource = listCombinacionBajas;
            dataGridView3.Refresh();
        }

        private void buttonValorAlto_Click(object sender, EventArgs e)
        {
            listCombinacionValorAlto = listCombinacion.OrderByDescending(a => a.cuotaMantenimiento).Take(1).ToList();
            dataGridView4.DataSource = null;
            dataGridView4.Refresh();
            dataGridView4.DataSource = listCombinacionValorAlto;
            dataGridView4.Refresh();
        }
    }
}