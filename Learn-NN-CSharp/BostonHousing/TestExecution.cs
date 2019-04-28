using Deedle;
using NeuroSimple;
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

namespace BostonHousing
{
    public partial class TestExecution : Form
    {
        NeuralNet model = null;
        NDArray x = null;
        NDArray y = null;

        NDArray test = null;
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

        private void BtnTrain_Click(object sender, EventArgs e)
        {
            LoadTrain();
            LoadTest();

            iterations = 100;
            batchSize = 32;
            model = new NeuralNet(new Adam(), new MeanSquaredError(), new MeanAbsoluteError());
            model.Add(new FullyConnected(13, 26, "relu"));
            model.Add(new FullyConnected(26, 13, "relu"));
            model.Add(new FullyConnected(13, 1));

            model.BatchEnd += Model_BatchEnd;

            WorkerThread.RunWorkerAsync();
        }

        private void LoadTrain()
        {
            //Using deedle which is similar to Pandas in python
            var frame = Frame.ReadCsv("train.csv", true);
            frame.DropColumn("ID");

            //Load Deedle frame to Tensor frame
            var yData = frame["medv"].Values.ToArray();

            frame.DropColumn("medv");
            var data = frame.ToArray2D<double>().Cast<double>().ToArray();
            
            x = new NDArray(frame.RowCount, frame.ColumnCount);
            x.Load(data);

            y = new NDArray(frame.RowCount, 1);
            y.Load(yData);
        }

        private void LoadTest()
        {
            //Using deedle which is similar to Pandas in python
            var frame = Frame.ReadCsv("test.csv", true);
            frame.DropColumn("ID");

            //Load Deedle frame to Tensor frame
            var data = frame.ToArray2D<double>().Cast<double>().ToArray();
            test = new NDArray(frame.RowCount, frame.ColumnCount);
            test.Load(data);
        }

        private void Model_BatchEnd(object sender, EpochEndEventArgs e)
        {
            WorkerThread.ReportProgress(10, e);
        }

        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            model.Train(x, y, iterations, batchSize);
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

        private void BtnTest_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
            Operations K = new Operations();
            var result = model.Predict(test);
            var frame = Frame.ReadCsv("test.csv", true);
            for (int i = 0; i < 25; i++)
            {
                txtConsole.AppendText("ID: " + frame.Rows[i]["ID"] + " ->  " + Math.Round(result[i], 2) + "\n\n");
            }
        }
    }
}
