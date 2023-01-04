using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
//using IrisFlowerClustering;

namespace Hassaan_Khalil_Exercise03
{
    public class Program
    {
        static void Main(string[] args)
        {

            string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "Student.csv");
            string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "StudentClusteringModel.zip");

            var mlContext = new MLContext(seed: 0);

            IDataView dataView = mlContext.Data.LoadFromTextFile<StudentData>(_dataPath, hasHeader: false, separatorChar: ',');

            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
                .Concatenate(featuresColumnName, "STG", "SCG", "STR", "LPR","PEG")
                .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 4));

            var model = pipeline.Fit(dataView);

            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, dataView.Schema, fileStream);
            }

            var predictor = mlContext.Model.CreatePredictionEngine<StudentData, ClusterPrediction>(model);

            var prediction = predictor.Predict(TestStudentData.very_low);
            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");

        }
    }
}
