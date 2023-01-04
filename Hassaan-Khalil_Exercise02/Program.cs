using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassaan_Khalil_Exercise02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load sample data
            var sampleData = new MedicalModel.ModelInput()
            {
                Age = 19F,
                Sex = @"female",
                Bmi = 27.9F,
                Children = 0F,
                Region = @"southwest",
            };

            //Load model and predict output
            var result = MedicalModel.Predict(sampleData);

        }
    }
}
