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
	}
}
