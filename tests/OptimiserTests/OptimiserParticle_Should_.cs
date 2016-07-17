using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Gee.Optimiser;
using FakeItEasy;

namespace OptimiserTests
{
	public class OptimiserParticle_Should_
	{
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		public void Construct_New_Instance_With_Correct_Number_Of_Variables(int variables)
		{
			var sut = new OptimiserParticle(A.Fake<Random>(), variables);
			Assert.AreEqual(variables, sut.Variables);
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		public void Construct_New_Instance_With_Correct_Size_Of_Position_List(int variables)
		{
			var sut = new OptimiserParticle(A.Fake<Random>(), variables);
			Assert.AreEqual(variables, sut.Position.Length);
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		public void Construct_New_Instance_With_Correct_Size_Of_Speed_List(int variables)
		{
			var sut = new OptimiserParticle(A.Fake<Random>(), variables);
			Assert.AreEqual(variables, sut.Speed.Length);
		}

		[Test]
		public void Construct_New_Instance_With_Default_Constructor()
		{
			new OptimiserParticle();
		}

		[Test]
		public void Create_Copy_Of_Position_Array_When_Cloning()
		{
			var sut = new OptimiserParticle(A.Fake<Random>(), 5);
			var copy = sut.Clone();
			Assert.AreNotSame(sut.Position, copy.Position);
		}

		[Test]
		public void Create_Copy_Of_Speed_Array_When_Cloning()
		{
			var sut = new OptimiserParticle(A.Fake<Random>(), 5);
			var copy = sut.Clone();
			Assert.AreNotSame(sut.Speed, copy.Speed);
		}

		[Test]
		public void Create_Position_Array_That_Has_The_Same_Values_As_The_Source_Particle_Position_Array()
		{
			Random random = A.Fake<Random>();
			A.CallTo(() => random.NextDouble()).ReturnsNextFromSequence(0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1);
			var sut = new OptimiserParticle(random, 5);
			var copy = sut.Clone();
			Assert.AreEqual(sut.Position, copy.Position);
		}

		[Test]
		public void Create_Speed_Array_That_Has_The_Same_Values_As_The_Source_Particle_Speed_Array()
		{
			Random random = A.Fake<Random>();
			A.CallTo(() => random.NextDouble()).ReturnsNextFromSequence(0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1);
			var sut = new OptimiserParticle(random, 5);
			var copy = sut.Clone();
			Assert.AreEqual(sut.Speed, copy.Speed);
		}

		[Test]
		public void Pass_Arguments_Through_When_Using_Manual_Constructor()
		{
			var position = new double[2];
			var speed = new double[2];

			var sut = new OptimiserParticle(position, speed);

			Assert.AreSame(position, sut.Position);
			Assert.AreSame(speed, sut.Speed);
			Assert.AreEqual(2, sut.Variables);
		}

		[Test]
		public void Throw_An_Exception_If_Position_And_Speed_Parameters_Are_Different_Length_When_Using_Manual_Constructor()
		{
			var actual = Assert.Throws<ArgumentException>(() => new OptimiserParticle(new double[0], new double[] { 1, 2, 3 }));
			Assert.AreEqual("speed", actual.ParamName);
			Assert.AreEqual("Number of dimensions (3) different to position (0)" + Environment.NewLine + "Parameter name: speed", actual.Message);
		}

		[Test]
		public void Calculate_Correct_Distance_When_Using_A_Single_Variable_In_Same_Position()
		{
			var sut = new OptimiserParticle(new double[] { 1 }, new double[1]);
			var result = sut.GetDistance(new OptimiserParticle(new double[] { 1 }, new double[1]));

			Assert.AreEqual(new double[] { 0 }, result);
		}

		[Test]
		public void Calculate_Correct_Distance_When_Using_A_Single_Variable()
		{
			var sut = new OptimiserParticle(new double[] { 1 }, new double[1]);
			var result = sut.GetDistance(new OptimiserParticle(new double[] { 5 }, new double[1]));

			Assert.AreEqual(new double[] { 4 }, result);
		}

		[Test]
		public void Calculate_Correct_Crow_Distance_When_Using_A_Single_Variable_In_Same_Position()
		{
			var sut = new OptimiserParticle(new double[] { 1 }, new double[1]);
			var result = sut.GetCrowDistance(new OptimiserParticle(new double[] { 1 }, new double[1]));

			Assert.AreEqual(0, result);
		}

		[Test]
		public void Calculate_Correct_Crow_Distance_When_Using_A_Single_Variable()
		{
			var sut = new OptimiserParticle(new double[] { 1 }, new double[1]);
			var result = sut.GetCrowDistance(new OptimiserParticle(new double[] { 5 }, new double[1]));

			Assert.AreEqual(4, result);
		}



		[Test]
		public void Calculate_Correct_Distance_When_Using_Multiple_Variables_In_Same_Position()
		{
			var sut = new OptimiserParticle(new double[] { 1, 5, 4 }, new double[3]);
			var result = sut.GetDistance(new OptimiserParticle(new double[] { 1, 5, 4 }, new double[3]));

			Assert.AreEqual(new double[] { 0, 0, 0 }, result);
		}

		[Test]
		public void Calculate_Correct_Distance_When_Using_Multiple_Variables()
		{
			var sut = new OptimiserParticle(new double[] { 1, 5, 4 }, new double[3]);
			var result = sut.GetDistance(new OptimiserParticle(new double[] { 5, 3, 3 }, new double[3]));

			Assert.AreEqual(new double[] { 4, -2, -1 }, result);
		}

		[Test]
		public void Calculate_Correct_Crow_Distance_When_Using_Multiple_Variables_In_Same_Position()
		{
			var sut = new OptimiserParticle(new double[] { 1, 5, 4 }, new double[3]);
			var result = sut.GetCrowDistance(new OptimiserParticle(new double[] { 1, 5, 4 }, new double[3]));

			Assert.AreEqual(0, result);
		}

		[Test]
		public void Calculate_Correct_Crow_Distance_When_Using_Multiple_Variables()
		{
			var sut = new OptimiserParticle(new double[] { 1, 5, 4 }, new double[3]);
			var result = sut.GetCrowDistance(new OptimiserParticle(new double[] { 2, 3, Math.Sqrt(20) + 4 }, new double[3]));

			Assert.AreEqual(5, result);
		}
	}
}
