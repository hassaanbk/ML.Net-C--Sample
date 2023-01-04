using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassaan_Khalil_Exercise03
{
    public class StudentData
    {
        [LoadColumn(0)]
        public float STG;

        [LoadColumn(1)]
        public float SCG;

        [LoadColumn(2)]
        public float STR;

        [LoadColumn(3)]
        public float LPR;

        [LoadColumn(4)]
        public float PEG;

    }

    public class ClusterPrediction
    {
        [ColumnName("KnowledgeLevel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[] Distances;
    }
}
