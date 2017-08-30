/*
 * Created by Ranorex
 * User: Mohit
 * Date: 29-08-2017
 * Time: 22:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace BusinessLayer.Modules
{
	/// <summary>
	/// Description of TestSetup.
	/// </summary>
	[TestModule("1FF76B2C-D2C4-41AC-8184-4E2E96BE7288", ModuleType.UserCode, 1)]
	public class TestSetup : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public TestSetup()
		{
			// Do not delete - a parameterless constructor is required!
		}

		/// <summary>
		/// Performs the playback of actions in this module.
		/// </summary>
		/// <remarks>You should not call this method directly, instead pass the module
		/// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
		/// that will in turn invoke this method.</remarks>
		void ITestModule.Run()
		{
			Mouse.DefaultMoveTime = 300;
			Keyboard.DefaultKeyPressTime = 100;
			Delay.SpeedFactor = 1.0;
			
			string lvUrl = TestSuite.Current.Parameters["Url"];
			string lvBrowser = TestSuite.Current.Parameters["Browser"];
			bool IsLvMaximizeBrowser = Convert.ToBoolean(TestSuite.Current.Parameters["MaximizeBrowser"]);
			LaunchBrowser(lvUrl,lvBrowser,IsLvMaximizeBrowser);
		}
		
		private void LaunchBrowser(string pUrl,string pBrowser,bool pIsMaximize=false)
		{
			Report.Log(ReportLevel.Info, "Website", "Opening web site '"+ pUrl +"' with browser '"+ pBrowser +"'  in normal mode.", new RecordItemIndex(0));
			Host.Local.OpenBrowser(pUrl , pBrowser, "", false, pIsMaximize, false, false, false);
		}
		
	}
}
