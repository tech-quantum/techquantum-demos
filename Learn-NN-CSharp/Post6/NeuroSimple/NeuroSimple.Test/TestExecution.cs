using NeuroSimple.Cost;
using NeuroSimple.Layers;
using NeuroSimple.Metrics;
using NeuroSimple.Optimizers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroSimple.Test
{
    public partial class TestExecution : Form
    {
        NeuralNet model = null;
        NDArray x = null;
        NDArray y = null;
        int iterations;
        int batchSize;

        DataTable trainingData = new DataTable();

        public TestExecution()
        {
            InitializeComponent();

            trainingData.Columns.Add("Iteration", typeof(int));
            trainingData.Columns.Add("Loss", typeof(double));
            trainingData.Columns.Add("Metric", typeof(double));

            chartTraining.DataSource = trainingData;
            chartTraining.Series["Loss"].XValueMember = "Iteration";
            chartTraining.Series["Loss"].YValueMembers = "Loss";
            chartTraining.Series["Loss"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartTraining.Series["Metric"].XValueMember = "Iteration";
            chartTraining.Series["Metric"].YValueMembers = "Metric";
            chartTraining.Series["Metric"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            
        }

        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            model.Train(x, y, iterations, batchSize);
        }

        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            EpochEndEventArgs epochEndEventArgs = (EpochEndEventArgs)e.UserState;
            txtConsole.AppendText(string.Format("Iteration: {0}, Loss: {1}, Metric: {2}"
                                , epochEndEventArgs.Epoch, epochEndEventArgs.Loss, epochEndEventArgs.Metric));
            txtConsole.AppendText("\n");

            DataRow dr = trainingData.NewRow();
            dr["Iteration"] = epochEndEventArgs.Epoch;
            dr["Loss"] = epochEndEventArgs.Loss;
            dr["Metric"] = epochEndEventArgs.Metric;
            trainingData.Rows.Add(dr);
            chartTraining.DataBind();
            chartTraining.Update();
        }

        private void BtnXORTest_Click(object sender, EventArgs e)
        {
            x = new NDArray(4, 2);
            x.Load(0, 0, 0, 1, 1, 0, 1, 1);

            y = new NDArray(4, 1);
            y.Load(0, 1, 1, 0);

            iterations = 750;
            batchSize = 2;
            model = new NeuralNet(new Adam(), new BinaryCrossEntropy(), new BinaryAccuacy());
            model.Add(new FullyConnected(2, 8, "relu"));
            model.Add(new FullyConnected(8, 4, "relu"));
            model.Add(new FullyConnected(4, 1, "sigmoid"));

            model.BatchEnd += Model_BatchEnd;

            WorkerThread.RunWorkerAsync();
        }

        private void Model_BatchEnd(object sender, EpochEndEventArgs e)
        {
            WorkerThread.ReportProgress(10, e);
        }
    }
}
