using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftMLDemo
{
    class Program
    {
        public class HouseData
        {
            public float Size { get; set; }
            public float Price { get; set; }
        }
        public class Prediction
        {
            [ColumnName("Score")]
            public float Price { get; set; }
        }

        public class HouseData2
        {
            public float Size { get; set; }
            public float Price { get; set; }

            public string AlarmDescriptoin { get; set; }

            public float Temperature { get; set; }

            public float Voltage { get; set; }
        }
        public class Prediction2
        {
            //[ColumnName("Score1")]
            //public float Price { get; set; }

            //public string AlarmDescriptoin { get; set; }

            //[ColumnName("Score2")]
            //public float Temperature { get; set; }

            [ColumnName("Score")]
            public float Voltage { get; set; }
        }


        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();
            // 1. Import or create training data
            HouseData[] houseData = {
               new HouseData() { Size = 1.1F, Price = 1.2F },
               new HouseData() { Size = 1.9F, Price = 2.3F },
               new HouseData() { Size = 2.8F, Price = 3.0F },
               new HouseData() { Size = 3.4F, Price = 3.7F } };
            IDataView trainingData = mlContext.Data.LoadFromEnumerable(houseData);
            // 2. Specify data preparation and model training pipeline
            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Size" })
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));
            // 3. Train model
            var model = pipeline.Fit(trainingData);
            // 4. Make a prediction
            var size = new HouseData() { Size = 2.5F };
            var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model).Predict(size);
            Console.WriteLine($"Predicted price for size: {size.Size * 1000} sq ft= {price.Price * 100:C}k");
            // Predicted price for size: 2500 sq ft= $261.98k


            MLContext mlContext2 = new MLContext();
            // 1. Import or create training data
            List<HouseData2> houseData2 = new List<HouseData2>();

            // {
            //new HouseData2() { Size = 1.1F, Price = 1.2F, AlarmDescriptoin="电压上限告警", Temperature = 35F, Voltage =3.5F },
            //new HouseData2() { Size = 1.9F, Price = 2.3F, AlarmDescriptoin="电压下限告警", Temperature = 35F, Voltage =1.5F },
            //new HouseData2() { Size = 2.8F, Price = 3.0F, AlarmDescriptoin="温度上限告警", Temperature = 45F, Voltage =3.5F },
            //new HouseData2() { Size = 3.4F, Price = 3.7F, AlarmDescriptoin="温度下限告警", Temperature = 15F, Voltage =2.0F } };
            houseData2.Add(new HouseData2() { Size = 1.1F, Price = 1.2F, AlarmDescriptoin = "电压上限告警", Temperature = 35F, Voltage = 3.5F });
            houseData2.Add(new HouseData2() { Size = 1.9F, Price = 2.3F, AlarmDescriptoin = "电压下限告警", Temperature = 35F, Voltage = 1.5F });
            houseData2.Add(new HouseData2() { Size = 2.8F, Price = 3.0F, AlarmDescriptoin = "温度上限告警", Temperature = 45F, Voltage = 3.5F });
            houseData2.Add(new HouseData2() { Size = 3.4F, Price = 3.7F, AlarmDescriptoin = "温度下限告警", Temperature = 15F, Voltage = 2.0F });

            Random rSize = new Random();
            Random rPrice = new Random();
            Random rTemperature = new Random();
            Random rVoltage = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var nextSize = NextDouble(rSize, 1f, 5f);
                var nextPrice = NextDouble(rPrice, 1f, 5f);
                var nextTemperature = NextDouble(rTemperature, 15f, 45f); 
                var nextVoltage = NextDouble(rVoltage, 1.5f,3.5f); 
                var newHouseDataItem = new HouseData2() { Size = (float)nextSize, Price = (float)nextPrice, Temperature = (float)nextTemperature, Voltage = (float)nextVoltage };
                houseData2.Add(newHouseDataItem);
            }

            IDataView trainingData2 = mlContext2.Data.LoadFromEnumerable(houseData2);
            // 2. Specify data preparation and model training pipeline
            var pipeline2 = mlContext2.Transforms.Concatenate("Features", new[] { "Size", nameof(HouseData2.Price), nameof(HouseData2.Temperature) })
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(HouseData2.Voltage), maximumNumberOfIterations: 5000));
            // 3. Train model
            var model2 = pipeline2.Fit(trainingData2);
            // 4. Make a prediction
            //var size2 = new HouseData2() { Size = 2.5F, Price = 1.2F, Temperature = 35F};
            var size2 = new HouseData2() { Size = 3.4F, Price = 3.7F, Temperature = 15F };
            var price2 = mlContext2.Model.CreatePredictionEngine<HouseData2, Prediction2>(model2).Predict(size2);
            Console.WriteLine($"预测的电压是：{price2.Voltage}");



            Console.ReadKey();
        }

        /// <summary>
        /// 生成设置范围内的Double的随机数
        /// eg:_random.NextDouble(1.5, 2.5)
        /// </summary>
        /// <param name="random">Random</param>
        /// <param name="miniDouble">生成随机数的最大值</param>
        /// <param name="maxiDouble">生成随机数的最小值</param>
        /// <returns>当Random等于NULL的时候返回0;</returns>
        public static double NextDouble(Random random, double miniDouble, double maxiDouble)
        {
            if (random != null)
            {
                return random.NextDouble() * (maxiDouble - miniDouble) + miniDouble;
            }
            else
            {
                return 0.0d;
            }
        }
    }
}
