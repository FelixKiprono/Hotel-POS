using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_POS
{
    
    public partial class Sample : Form
    {
         class ChartData
        {
            public String Name { get; set; }
            public double Amount { get; set; }
        }
         List<ChartData> chartadata = new List<ChartData>();

        void FillData()
        {
            chartadata.Add(new ChartData()
            {
                Name = "Microsoft",
                Amount = 85000
            });
            chartadata.Add(new ChartData()
            {
                Name = "Aple",
                Amount = 1200
            });
            chartadata.Add(new ChartData()
            {
                Name = "Linux",
                Amount = 7890
            });
            chartadata.Add(new ChartData()
            {
                Name = "Adobe",
                Amount = 1650
            });
            chartadata.Add(new ChartData()
            {
                Name = "MySQL",
                Amount = 1400
            });
        }

        public Sample()
        {
            InitializeComponent();
            FillData();

            SeriesCollection seriesViews = new SeriesCollection() ;
            foreach (ChartData data in chartadata)
            {
                seriesViews.Add(
                new PieSeries
                {
                    Title = data.Name,
                    Values = new ChartValues<double> { data.Amount },
                    DataLabels = true
                  
                });
        


            }
            pieChart1.Series = seriesViews;

            pieChart1.LegendLocation = LegendLocation.Bottom;

            //cartesian chart




        }


        void Samples()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 1000, 1200, 1300, 500,450,900,4500,1400,1100,2500 }
                }
            };

            ////adding series will update and animate the chart automatically
            //cartesianChart1.Series.Add(
            // new ColumnSeries
            //{
            //    Title = "2016",
            //    Values = new ChartValues<double> { 11, 56, 42,20 }
            //});

           
            cartesianChart1.AxisX.Add(
                new Axis
            {
                Title = "Sales Man",
               
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" ,"Putin","Merkel","Felix","Milosevic","Lukashenko","Volodymir"}
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });

           

        }

        private void Sample_Load(object sender, EventArgs e)
        {
            Samples();
        }
    }
}
