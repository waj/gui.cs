using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Terminal.Gui;
using Xunit;

// Alais Console to MockConsole so we don't accidentally use Console
using Console = Terminal.Gui.FakeConsole;

namespace Terminal.Gui {
	public class DimTests {
		[Fact]
		public void New_Works ()
		{
			var dim = new Dim ();
			Assert.Equal ("Terminal.Gui.Dim", dim.ToString ());
		}

		[Fact]
		public void Sized_SetsValue ()
		{
			var dim = Dim.Sized (0);
			Assert.Equal ("Dim.Absolute(0)", dim.ToString ());

			int testVal = 5;
			dim = Dim.Sized (testVal);
			Assert.Equal ($"Dim.Absolute({testVal})", dim.ToString ());
		}

		// TODO: Other Dim.Sized tests (e.g. Equal?)

		[Fact]
		public void Width_SetsValue ()
		{
			var dim = Dim.Width (null);
			Assert.Throws<NullReferenceException> (() => dim.ToString ());

			var testVal = Rect.Empty;
			testVal = Rect.Empty;
			dim = Dim.Width (new View (testVal));
			Assert.Equal ($"DimView(side=Width, target=View()({{X={testVal.X},Y={testVal.Y},Width={testVal.Width},Height={testVal.Height}}}))", dim.ToString ());

			testVal = new Rect (1, 2, 3, 4);
			dim = Dim.Width (new View (testVal));
			Assert.Equal ($"DimView(side=Width, target=View()({{X={testVal.X},Y={testVal.Y},Width={testVal.Width},Height={testVal.Height}}}))", dim.ToString ());
		}

		// TODO: Other Dim.Width tests (e.g. Equal?)

		[Fact]
		public void Height_SetsValue ()
		{
			var dim = Dim.Height (null);
			Assert.Throws<NullReferenceException> (() => dim.ToString ());

			var testVal = Rect.Empty;
			testVal = Rect.Empty;
			dim = Dim.Height (new View (testVal));
			Assert.Equal ($"DimView(side=Height, target=View()({{X={testVal.X},Y={testVal.Y},Width={testVal.Width},Height={testVal.Height}}}))", dim.ToString ());

			testVal = new Rect (1, 2, 3, 4);
			dim = Dim.Height (new View (testVal));
			Assert.Equal ($"DimView(side=Height, target=View()({{X={testVal.X},Y={testVal.Y},Width={testVal.Width},Height={testVal.Height}}}))", dim.ToString ());
		}

		// TODO: Other Dim.Height tests (e.g. Equal?)

		[Fact]
		public void Fill_SetsValue ()
		{
			var testMargin = 0;
			var dim = Dim.Fill ();
			Assert.Equal ($"Dim.Fill(margin={testMargin})", dim.ToString());

			testMargin = 0;
			dim = Dim.Fill (testMargin);
			Assert.Equal ($"Dim.Fill(margin={testMargin})", dim.ToString ());

			testMargin = 5;
			dim = Dim.Fill (testMargin);
			Assert.Equal ($"Dim.Fill(margin={testMargin})", dim.ToString ());
		}


		[Fact]
		public void Fill_Equal()
		{
			var margin1 = 0;
			var margin2 = 0;
			var dim1 = Dim.Fill (margin1);
			var dim2 = Dim.Fill (margin2);
			Assert.Equal (dim1, dim2);
		}

		[Fact]
		public void Percent_SetsValue ()
		{
			var dim = Dim.Percent (0);
			Assert.Equal ("Dim.Factor(0)", dim.ToString ());
			dim = Dim.Percent (0.5F);
			Assert.Equal ("Dim.Factor(0.005)", dim.ToString ());
			dim = Dim.Percent (100);
			Assert.Equal ("Dim.Factor(1)", dim.ToString ());
		}

		// TODO: Other Dim.Percent tests (e.g. Equal?)

		[Fact]
		public void Percent_ThrowsOnIvalid()
		{
			var dim = Dim.Percent (0);
			Assert.Throws<ArgumentException> (() => dim = Dim.Percent (-1));
			Assert.Throws<ArgumentException> (() => dim = Dim.Percent (101));
			Assert.Throws<ArgumentException> (() => dim = Dim.Percent (100.0001F));
			Assert.Throws<ArgumentException> (() => dim = Dim.Percent (1000001));
		}

		// TODO: Test operators
	}
}
