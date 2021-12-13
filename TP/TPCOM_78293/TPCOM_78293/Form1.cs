using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TPCOM_78293
{
    public partial class Form1 : Form
    {

        Stopwatch reloj = new Stopwatch();
        int indice1, indice3, indice4, cant = 0;
        int opc = 1;
        double tiempoSimulacion, cant_bps,tiempo1, tiempo2, tiempo3, tiempo4,tiempo5,tiempo6, frecuenciaRuido,amplitudRuido, frecuenciaSeñal, amplitudSeñal,jitter, inicio, indice2,ruido_D,jitter_D,a,amplitud,frecuencia,amplitudFinal,frecuenciaFinal;

        

        bool completo = false;
        private void btnSimularCompleto_Click(object sender, EventArgs e)
        {
            completo = true;
            btnSimular_C_Click(sender, e);
        }

      

        int cantBits, n;
        string codigo;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnContinuar_C_Click(object sender, EventArgs e)
        {
            grafico6();
        }

        private void btnLimpiar_D_Click(object sender, EventArgs e)
        {
            txtInicio.Text = "0";
            txtCodigo.Text = "001010011100101110";
            txtCantBits.Text = "3";
            txtRuido_D.Text = "0";
            txtJitter_D.Text = "0";
            cant = 0;
            indice1 = 0;
            indice3 = 0;
            indice4 = 0;
            btnContinuar.Enabled = false;
            chart1.Series.Clear();
            chart1.Series.Add("0");
            chart1.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["0"].BorderWidth = 3;
            chart3.Series.Clear();
            chart3.Series.Add("0");
            chart3.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.Series["0"].BorderWidth = 3;
            chart4.Series.Clear();
            chart4.Series.Add("0");
            chart4.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart4.Series["0"].BorderWidth = 3;
            btnSimular.Enabled = true;
            
           
        }

        private void btnLimpiar_C_Click(object sender, EventArgs e)
        {
            txtInicio_C.Text = "0";
            txtJitter_C.Text = "0";
            txtFrecuenciaRuido_C.Text = "0";
            opc = 1;
            indice2 = 0;
            txtFrecuenciaRuido_C.Text = "0";
            txtAmplitudRuido_C.Text = "0";
            
            txtTiempoSim.Text = "10";

            opc = 1;
            indice2 = 0;
            chart5.Series.Clear();
            chart5.Series.Add("0");
            chart5.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart5.Series["0"].BorderWidth = 3;
            chart5.ChartAreas.Clear();
            chart5.ChartAreas.Add("ChartArea1");
            chart6.Series.Clear();
            chart6.Series.Add("0");
            chart6.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series["0"].BorderWidth = 3;
            chart6.ChartAreas.Clear();
            chart6.ChartAreas.Add("ChartArea1");

            completo = false;
            btnSimular_C.Enabled = true;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            
            chart4.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart5.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            tabPage1.AutoScroll = true;
            btnContinuar_C.Enabled = false;
            btnContinuar.Enabled = false;
        }

        private void btnSimular_C_Click(object sender, EventArgs e)
        {
            opc = 1;
            indice2 = 0;
            chart5.Series.Clear();
            chart5.Series.Add("0");
            chart5.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart5.Series["0"].BorderWidth = 3;
            chart5.ChartAreas.Clear();
            chart5.ChartAreas.Add("ChartArea1");
            chart6.Series.Clear();
            chart6.Series.Add("0");
            chart6.Series["0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series["0"].BorderWidth = 3;
            chart6.ChartAreas.Clear();
            chart6.ChartAreas.Add("ChartArea1");

            
            
            tiempo5 = Convert.ToDouble(txtInicio_C.Text);
            tiempo6 = Convert.ToDouble(txtInicio_C.Text);
            frecuenciaRuido = Convert.ToDouble(txtFrecuenciaRuido_C.Text);
            amplitudRuido = Convert.ToDouble(txtAmplitudRuido_C.Text);
            amplitud= Convert.ToDouble(txtAmplitudRuido_C.Text);
            frecuencia= Convert.ToDouble(txtFrecuenciaRuido_C.Text);
            jitter = Convert.ToDouble(txtJitter_C.Text);
            frecuenciaSeñal = Convert.ToDouble(txtFrecuenciaSeñal.Text);
            amplitudSeñal = Convert.ToDouble(txtAmplitudSeñal.Text);
            frecuenciaSeñal = frecuenciaSeñal + ((jitter*frecuenciaSeñal)/100);
            a = tiempo6 + ((jitter * frecuenciaSeñal) / 100);
            indice2 = tiempo6 + ((jitter * frecuenciaSeñal) / 100);
            tiempoSimulacion = Convert.ToDouble(txtTiempoSim.Text);
            cant_bps= Convert.ToDouble(txtCantbps.Text);


            if (txtMaxX_1.Text.Length != 0)
            {
                chart5.ChartAreas["ChartArea1"].AxisX.Maximum = Convert.ToDouble(txtMaxX_1.Text);
            }
            if (txtMaxX_2.Text.Length != 0)
            {
                chart6.ChartAreas["ChartArea1"].AxisX.Maximum = Convert.ToDouble(txtMaxX_2.Text);
            }
            if (txtMinX_1.Text.Length != 0)
            {
                chart5.ChartAreas["ChartArea1"].AxisX.Minimum = Convert.ToDouble(txtMinX_1.Text);
            }
            if (txtMinX_2.Text.Length != 0)
            {
                chart6.ChartAreas["ChartArea1"].AxisX.Minimum = Convert.ToDouble(txtMinX_2.Text);
            }

            if (txtMaxY_1.Text.Length != 0)
            {
                chart5.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(txtMaxY_1.Text);
            }
            if (txtMaxY_2.Text.Length != 0)
            {
                chart6.ChartAreas["ChartArea1"].AxisY.Maximum = Convert.ToDouble(txtMaxY_2.Text);
            }
            if (txtMinY_1.Text.Length != 0)
            {
                chart5.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(txtMinY_1.Text);
            }
            if (txtMinY_2.Text.Length != 0)
            {
                chart6.ChartAreas["ChartArea1"].AxisY.Minimum = Convert.ToDouble(txtMinY_2.Text);
            }


            nuevaSerie();
            grafico6();
        }

      

        private void btnSimular_Click_1(object sender, EventArgs e)
        {
            btnSimular.Enabled = false;
            btnContinuar.Enabled = true;
            codigo = Convert.ToString(txtCodigo.Text);
            tiempo1 = Convert.ToDouble(txtInicio.Text);
            tiempo2 = Convert.ToDouble(txtInicio.Text);
            tiempo3 = Convert.ToDouble(txtInicio.Text);
            tiempo4 = Convert.ToDouble(txtInicio.Text);
            cantBits = Convert.ToInt32(txtCantBits.Text);
            ruido_D= Convert.ToDouble(txtRuido_D.Text);
            jitter_D= Convert.ToDouble(txtJitter_D.Text);
            n = codigo.Length;
            inicio = Convert.ToDouble(txtInicio.Text);


           
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 0.5;
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = tiempo1;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 0.5;
            chart3.ChartAreas["ChartArea1"].AxisX.Interval = 0.5;
            chart3.ChartAreas["ChartArea1"].AxisX.Minimum = tiempo3;
            chart3.ChartAreas["ChartArea1"].AxisY.Interval = 0.5;
            chart4.ChartAreas["ChartArea1"].AxisX.Interval = 0.5;
            chart4.ChartAreas["ChartArea1"].AxisX.Minimum = tiempo4;
            chart4.ChartAreas["ChartArea1"].AxisY.Interval = 0.5;

            grafico1();
            //grafico2();
            grafico3();
            grafico4();
          


        }

        public double NextDouble(double min, double max)
        {
            System.Random random = new System.Random();
            double val = (random.NextDouble() * (max - min) + min);
            return (double)val;
        }

        private void grafico6()
        {
            
            //double ciclo = (Math.PI / (frecuenciaRuido + frecuenciaSeñal));

           
            Random objRandom = new Random();
            //btnSimular_C.Enabled = false;
            btnContinuar_C.Enabled = true;
            int i = 0;
            double[] signal = new double[(int)(tiempoSimulacion / 0.01)];

            for (double x = indice2; !(x > (tiempoSimulacion)); x += 0.01)
            {
                
                //double aux2 = amplitudRuido * Math.Cos(2 * Math.PI * x * frecuencia + NextDouble(-0.9, 1));
                double aux2 = amplitudRuido * Math.Sin(2 * Math.PI * x * frecuenciaRuido);
                double aux1 = amplitudSeñal * Math.Sin(2 * Math.PI * x * frecuenciaSeñal);
                

                chart5.Series[0].Points.AddXY(x,  aux1+aux2);
               
                chart6.Series[opc].Points.AddXY(a, aux1 + aux2);
                
                a += 0.01;


                //band1 = (Math.Sin(2 * Math.PI * x * frecuenciaFinal) <= 0 && Math.Sin(2 * Math.PI * (x+0.01) * frecuenciaFinal) > 0)  || (Math.Sin(2 * Math.PI * x * frecuenciaFinal) < 0 && Math.Sin(2 * Math.PI * (x + 0.01) * frecuenciaFinal)>= 0) || (Math.Sin(2 * Math.PI * x * frecuenciaFinal) > 0 && Math.Sin(2 * Math.PI * (x + 0.01) * frecuenciaFinal) <= 0) || (Math.Sin(2 * Math.PI * x * frecuenciaFinal) >= 0 && Math.Sin(2 * Math.PI * (x + 0.01) * frecuenciaFinal) < 0)  ? true : false;
                //signal[i] = aux2 + aux1;
                //if (i > 0) band1 = signal[i] > 0 && signal[i - 1] < 0 || signal[i] < 0 && signal[i - 1] > 0 ? true : false;

                //band1 = (Math.Round(x,2)) % cant_bps == 0 ? true: false ;
                if (Math.Round(a, 2) == cant_bps)
                {

                    a = tiempo6 + ((jitter * frecuenciaSeñal) / 100);
                    opc++;
                    nuevaSerie();
                    
                    if (!completo)
                    {
                        indice2 = x + 0.01;
                        break;
                    }
                   
                    
                }

            }

            
        }

        private void nuevaSerie()
        {
            chart6.Series.Add($"{opc}");
            chart6.Series[$"{opc}"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart6.Series[$"{opc}"].BorderWidth = 3;
        }
       
        private void btnContinuar_Click_1(object sender, EventArgs e)
        {
            grafico1();
            grafico3();
            grafico4();

        }


        private void grafico4()
        {
            Random objRandom = new Random();
            for (int i = indice4; i < n; i++)
            {                

                if (codigo[i].ToString() == "1")
                {
                    double rndJitter = (objRandom.NextDouble() * ((jitter_D / 100) - (-jitter_D / 100) + (-jitter_D / 100)));
                    for (double j = tiempo4+0.05; j < tiempo4+ 0.5; j += 0.02)
                    {
                        double rndRuido = (objRandom.NextDouble() * ((ruido_D / 100) - (0) + (0)));
                        
                        chart4.Series[0].Points.AddXY(j+rndJitter, 1 + rndRuido);
                    }
                    //chart4.Series[0].Points.AddXY(tiempo4 + 0.1, 1);
                    //chart4.Series[0].Points.AddXY(tiempo4 + 0.4, 1);

                }
                else
                {
                    double rndJitter = (objRandom.NextDouble() * ((jitter_D / 100) - (-jitter_D / 100) + (-jitter_D / 100)));
                    for (double j = tiempo4 + 0.05; j < tiempo4 + 0.5; j += 0.02)
                    {
                        double rndRuido = (objRandom.NextDouble() * ((ruido_D / 100) - (0) + (0)));
                       
                        chart4.Series[0].Points.AddXY(j+rndJitter, 0+ rndRuido);
                    }
                    //chart4.Series[0].Points.AddXY(tiempo4 + 0.1, 0);
                    //chart4.Series[0].Points.AddXY(tiempo4 + 0.4, 0);

                }


                tiempo4 += 0.5;

                if ((i + 1) % cantBits == 0)
                {
                    indice4 = i + 1;
                    break;
                }
            }
        }
        private void grafico3()
        {
            Random objRandom = new Random();
            

            for (int i = indice3; i < n; i++)
            {
                if (i == n-1)
                    btnContinuar.Enabled = false;

                

                if (i % cantBits == 0)
                {                   
                    cant++;
                    tiempo3 = inicio;
                    chart3.Series.Add($"{cant}");
                    chart3.Series[$"{cant}"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart3.Series[$"{cant}"].BorderWidth = 3;   
                      
                }

                if (codigo[i].ToString() == "1")
                {
                    double rndJitter = (objRandom.NextDouble() * ((jitter_D / 100) - (-jitter_D / 100) + (-jitter_D / 100)));
                    for (double j = tiempo3 + 0.07; j < tiempo3 + 0.5; j += 0.03)
                    {
                        double rndRuido = (objRandom.NextDouble() * ((ruido_D / 100) - (0) + (0)));
                        
                        chart3.Series[cant].Points.AddXY(j+rndJitter, 1 + rndRuido);
                    }
                    //chart3.Series[cant].Points.AddXY((tiempo3 + 0.1), 1);
                    //chart3.Series[cant].Points.AddXY((tiempo3 + 0.4), 1);
                }
                else
                {
                    double rndJitter = (objRandom.NextDouble() * ((jitter_D / 100) - (-jitter_D / 100) + (-jitter_D / 100)));
                    for (double j = tiempo3 + 0.07; j < tiempo3 + 0.5; j += 0.03)
                    {
                        double rndRuido = (objRandom.NextDouble() * ((ruido_D / 100) - (0) + (0)));
                        
                        chart3.Series[cant].Points.AddXY(j+rndJitter, 0 + rndRuido);
                    }
                    //chart3.Series[cant].Points.AddXY((tiempo3 + 0.1) , 0 );                    
                    //chart3.Series[cant].Points.AddXY((tiempo3 + 0.4) , 0 );
                }


                tiempo3 += 0.5;

                if ((i+1) % cantBits == 0)
                {
                    indice3 = i + 1;
                    break;
                }
            }
        }

        

        private void grafico1()
        {
            Random objRandom = new Random();
            for (int i = indice1; i < n; i++)
            {

                if (codigo[i].ToString() == "1")
                {
                    double rndJitter = (objRandom.NextDouble() * ((jitter_D / 100) - (-jitter_D / 100) + (-jitter_D / 100)));
                    for (double j = tiempo1; j < tiempo1 + 0.5; j += 0.02)
                    {
                        double rndRuido = (objRandom.NextDouble() * ((ruido_D / 100) - (0) + (0)));
                        
                        chart1.Series[0].Points.AddXY(j + rndJitter, 1 + rndRuido);
                        
                    }
                    //chart1.Series[0].Points.AddXY(tiempo1, 1);
                    //chart1.Series[0].Points.AddXY(tiempo1 + 0.5, 1);

                }
                else
                {
                    double rndJitter = (objRandom.NextDouble() * ((jitter_D / 100) - (-jitter_D / 100) + (-jitter_D / 100)));
                    for (double j = tiempo1; j < tiempo1 + 0.5; j += 0.02)
                    {
                        double rndRuido = (objRandom.NextDouble() * ((ruido_D / 100) - (0) + (0)));
                        chart1.Series[0].Points.AddXY(j + rndJitter, 0 + rndRuido);
                        
                    }
                    //chart1.Series[0].Points.AddXY(tiempo1, 0);
                    //chart1.Series[0].Points.AddXY(tiempo1 + 0.5, 0);

                }


                tiempo1 += 0.5;

                if ((i + 1) % cantBits == 0)
                {
                    indice1 = i + 1;
                    break;
                }
            }
        }

       
    }
}


